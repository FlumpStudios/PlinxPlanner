using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.Common.Models
{
    public class SiteStatus
    {
        public SiteStatus()
        {
            Sitedetails = new HashSet<Sitedetails>();
        }
        [Key]
        public int SitesStatusId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Sitedetails> Sitedetails { get; set; }
    }
}
