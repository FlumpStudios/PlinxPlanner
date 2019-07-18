namespace PlinxPlanner.Common.Settings
{
    public class AppSettings : IAppSettings
    {
        public API API { get; set; }
        public Authentication Authentication { get; set; }
        public Swagger Swagger { get; set; }
        public Database Database { get; set; }
        public Caching Caching { get; set; }
    }

    public class Caching
    {
        public int MemorySizeLimit { get; set; }
    }


    public class API
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Authentication
    {
        public string DefaultScheme { get; set; }

        public string Authority { get; set; }

        public bool RequireHttpsMetadata { get; set; }

        public string ApiName { get; set; }
    }

    public class Swagger
    {
        public bool Enabled { get; set; }

        public bool RestrictSubmitMethodsToGetRequest { get; set; }

        public string XmlCommentsLocation { get; set; }

        public SwaggerAuth Auth{ get; set; }

           
    }

    public class Database
    {
        public string ConnectionString { get; set; }
        public bool UseInMemoryDatabase { get; set; }
        public bool SeedDbOnCreate { get; set; }
    }

    public class SwaggerAuth {
        public string SecurityDefinitionName { get; set; }
        public string AuthorizationUrl { get; set; }
        public string FlowType { get; set; }
        public Scopes Scopes { get; set; }
        public string OAuthClientId { get; set; }
        public string DisplayName { get; set; }
    }

    public class Scopes
    {
        public string ScopeName { get; set; }
        public string FriendlyName { get; set; }
    }




}
