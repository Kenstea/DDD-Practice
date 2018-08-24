using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gnnovation.SIMS.Data.Models
{
    public class Enterprise : BusinessEntity
    {
        [Required, StringLength(255)]
        public string ShortName { get; set; }

        [Required, StringLength(255)]
        public string FullName { get; set; }

        [Required, StringLength(300)]
        public string Address { get; set; }
     
        public ICollection<Server> Servers { get; set; }
       
        public ICollection<Contact> Contacts { get; set; }
    }
}