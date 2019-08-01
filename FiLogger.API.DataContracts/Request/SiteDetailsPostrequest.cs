using System;
using System.Collections.Generic;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Request
{
    public class SiteDetailsPostrequest
    {
        public SiteDetailsPostrequest()
        {
            SitesStatusId = 1;
        }
        public int SiteDetailsId { get; set; }
        public int CustomerId { get; set; }
        public int SitesStatusId { get; set; }
        public int TemplateId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColour { get; set; }
        public string Base64Logo { get; set; }
        public bool SuperUserCreated { get; set; }
    }
}
