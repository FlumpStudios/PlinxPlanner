﻿using AutoMapper;
using PlinxPlanner.Common.Extensions;
using PlinxPlanner.Common.Settings;
using ListersDemo.API.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using PlinxPlanner.IoC.Config.Profiles;
using CryptoLib;
using DBContext = PlinxPlanner.Context.Data;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using PlinxPlanner.Service.Contracts;
using PlinxPlanner.Service.Services;
using System.Collections.Generic;
using PlinxPlanner.IoC.Config.OperationFilters;
using Microsoft.Extensions.Logging;
using PlinxPlanner.DataAccess.EntityFramework;
using PlinxPlanner.Caching;
using PlinxPlanner.Caching.MemCache;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.Caching.Memory;

namespace PlinxPlanner
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration property
        /// </summary>
        public IConfiguration _configuration { get; private set; }

        /// <summary>
        /// HostingEnvironment property
        /// </summary>
        public IHostingEnvironment HostingEnvironment { get; private set; }
        
        private AppSettings _appSettings;

        private bool appSettingsAreValid;

        private readonly ILogger<Startup> _logger;
        
        /// <summary>
        /// .NET core Startup method
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment env, ILogger<Startup> logger)
        {
            HostingEnvironment = env;
            _configuration = configuration;
            _logger = logger;
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            //API Explorer (for API Versioning)
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddMemoryCache();
            services.AddMvc();

            services.AddAuthorization();

            //App settings
            var appSettingsSection = _configuration.GetSection("AppSettings");
            if (appSettingsSection == null)
                throw new System.Exception("No appsettings section has been found");

            services.Configure<AppSettings>(appSettingsSection);

            _appSettings = appSettingsSection.Get<AppSettings>();

            //Check the appsettings are all valid
            if (_appSettings.IsValid().Item1) appSettingsAreValid = true;
            else _logger.LogError("Appsettings are invalid. Please see exception for more details", new System.Exception(_appSettings.IsValid().Item2));
            

            if (appSettingsAreValid)
            {
                if (_appSettings.Swagger.Enabled)
                {
                    // Register the Swagger generator, defining 1 or more Swagger documents
                    services.AddSwaggerGen(options =>
                    {
                        // resolve the IApiVersionDescriptionProvider service
                        // note: that we have to build a temporary service provider here because one has not been created yet
                        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                        // add a swagger document for each discovered API version
                        // note: you might choose to skip or document deprecated API versions differently
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));           
                            options.OperationFilter<AuthorizeCheckOperationFilter>();
                        }            
                        
                        //Add OAuth2 info for Swagger
                        options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                        {
                            Flow = _appSettings.Swagger.Auth.FlowType,
                            AuthorizationUrl = _appSettings.Swagger.Auth.AuthorizationUrl,
                            Scopes = new Dictionary<string, string>
                            {
                                    {
                                        _appSettings.Swagger.Auth.Scopes.ScopeName,
                                        _appSettings.Swagger.Auth.Scopes.FriendlyName
                                    }
                          }
                        });

                        // add a custom operation filter which sets default values
                        options.OperationFilter<SwaggerDefaultValues>();

                        //If an xml comments path has been specified in the app settings then add Xml comments intergration with swagger
                        //if (!string.IsNullOrEmpty(_appSettings.Swagger.XmlCommentsLocation))
                          //      options.IncludeXmlComments(_appSettings.Swagger.XmlCommentsLocation);
                    });
                }


                services.AddAuthentication(_appSettings.Authentication.DefaultScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = _appSettings.Authentication.Authority;
                    options.RequireHttpsMetadata = _appSettings.Authentication.RequireHttpsMetadata;
                    options.ApiName = _appSettings.Authentication.ApiName;
                });


                services.AddApiVersioning(
                        options =>
                        {
                            options.ReportApiVersions = true;
                            options.AssumeDefaultVersionWhenUnspecified = true;
                            options.DefaultApiVersion = new ApiVersion(1, 0);
                            options.ApiVersionReader = new UrlSegmentApiVersionReader();
                        }
                    );
            }

            //Automap settings
            services.AddAutoMapper();
            ConfigureMaps();

            //Setup the DB context
            if (_appSettings.Database.UseInMemoryDatabase)
            {
                string inMemDbName = string.Format("{0}_database", _appSettings.API.Title);

                services.AddDbContext<DBContext.AP_ReplacementContext>(options =>
                    options.UseInMemoryDatabase(inMemDbName));
            }
            else
            {
                services.AddDbContext<DBContext.AP_ReplacementContext>(options =>
                    options.UseSqlServer(_appSettings.Database.ConnectionString));
            }

            AddCustomServices(services);

        }

        private void AddCustomServices(IServiceCollection services)
        {
            //Read the encyption keys from the Secrets
            //var inputString = _configuration["EncryptionCipher:inputString"];
            //var salt = _configuration["EncryptionCipher:Salt"];

            //Add the CryptoManager service through DI and pass through the input string and salt to the contructor
            //The keys are kept in the secret folder for developement. When running for the first time you will need to add the EncryptionCipher:inputString and EncryptionCipher:sale to your secrets.
            //services.AddTransient<ICryptoManager>(s => new CryptoManager(inputString, salt));

            services.AddTransient<ICachingManager, CachingManager>();

            //Repos
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IContentRepository, ContentRepository>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Service Layer dependencies
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IContentService, ContentService>();
            
            //Singletons
            services.AddSingleton<ICustomMemCache>(new FiLoggerMemCache(_appSettings.Caching.MemorySizeLimit));
        }
    

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var checkAppsettings = _appSettings.IsValid();

            if (appSettingsAreValid)
            {
                if (_appSettings.Swagger.Enabled)
                {
                    app.UseSwagger();

                    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                    // specifying the Swagger JSON endpoint.
                    app.UseSwaggerUI(options =>
                    {
                        // build a swagger endpoint for each discovered API version
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        }

                        options.RoutePrefix = string.Empty;                      
                        options.OAuthClientId(_appSettings.Swagger.Auth.OAuthClientId);
                        options.OAuthAppName(_appSettings.Swagger.Auth.DisplayName);

                        //Restrict swagger 'Try it out' to only allow get and head methods. 
                        //As we do not want supply an open id scope with swagger-UI. The user should only be able to test methods available to all Authenticated users.                     
                        if (_appSettings.Swagger.RestrictSubmitMethodsToGetRequest) options.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
                    });
                }
            }            

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowCredentials().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }


        #region Startup helper functions
        Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"{_appSettings.API.Title} {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = _appSettings.API.Description
            };

            if (description.IsDeprecated)
            {
                string.Format("{0} This API version has been deprecated.", info.Description);
            }
            return info;
        }

        private void ConfigureMaps()
        {
            //Mapping settings
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerMappingProfile>();                
            }
         );
        }
        #endregion
    }
}


