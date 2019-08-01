using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.Common.Models
{
    public class Sitedetails
    {
        [Key]
        public int SiteDetailsId { get; set; }
        public int CustomerId { get; set; }
        public int SitesStatusId { get; set; }
        public int TemplateId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColour { get; set; }
        public string Base64Logo { get; set; }
        public bool SuperUserCreated { get; set; }
        public SiteStatus SiteStatus { get; set; }
    }
}
