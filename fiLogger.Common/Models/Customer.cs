using System;
using System.ComponentModel.DataAnnotations;

namespace PlinxPlanner.Common.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CompanyName { get; set; }             
        public CustomerAddress CustomerAddress { get; set; }
        public Sitedetails Sitedetails { get; set; }
    }
}
