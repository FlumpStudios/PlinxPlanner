using System;
using System.Collections.Generic;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Response
{
    public class Sitedetails
    {
        public int SiteDetailsId { get; set; }
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColour { get; set; }
        public string Base64Logo { get; set; }
    }
}
