using System.ComponentModel.DataAnnotations;

namespace Gnnovation.SIMS.Data.Models
{
    public class Contact : BusinessEntity
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.MiddleName} {this.LastName}";

        [Required, StringLength(100)]
        public string Email { get; set; }

        public string Phone { get; set; }
        
        public virtual Enterprise Enterprises { get; set; }

        [Required]
        public int EnterpriseID { get; set; }
    }
}