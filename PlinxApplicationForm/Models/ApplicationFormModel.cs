using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlinxApplicationForm.Models
{
    public class ApplicationFormModel
    {

        public ApplicationFormModel()
        {
            FirstContactDate = DateTime.Now;
        }
        #region client details

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }
        public DateTime? FirstContactDate { get; set; }

        public string CompanyName { get; set; }
        #endregion

        #region Address Details
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        public string Postcode { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        #endregion

        #region Site Details

        [Required]
        public int TemplateId { get; set; }

        [Required]
        public string PrimaryColor { get; set; }

        [Required]
        public string SecondaryColour { get; set; }
        public string Base64Logo { get; set; }
        #endregion
    }
}
