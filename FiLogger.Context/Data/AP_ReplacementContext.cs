using PlinxPlanner.Common.Models;
using PlinxPlanner.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PlinxPlanner.Context.Data
{
    public class AP_ReplacementContext : DbContext
    {      
        private readonly IOptions<AppSettings> _appSettings;


        public AP_ReplacementContext(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public AP_ReplacementContext(DbContextOptions<AP_ReplacementContext> options, IOptions<AppSettings> appSettings)
            : base(options)
        {
            _appSettings = appSettings;
        }


        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sitedetails> Sitedetails { get; set; }
        public DbSet<SiteStatus> SiteStatus { get; set; }
        public DbSet<DefaultContent> DefaultContent { get; set; }
        public DbSet<DefaultSkills> DefaultSkills { get; set; }
        public DbSet<DefaultComments> DefaultComments { get; set; }
        public DbSet<DefaultPortfolio> DefaultPortfolio { get; set; }
        public DbSet<DefaultExperiance> DefaultExperiance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed the database
           // if (_appSettings.Value.Database.SeedDbOnCreate) DBInitialiser.SeedDB(modelBuilder);
        }

    }
}


