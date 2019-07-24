using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Request
{
    public class SiteStatusPostRequest
    {
        public int SitesStatusId { get; set; }
        public string Name { get; set; }     
    }
}
