using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Response
{
    public class SiteStatus
    {
        public int SitesStatusId { get; set; }
        public string Name { get; set; }     
    }
}
