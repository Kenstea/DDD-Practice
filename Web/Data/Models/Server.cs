using System.ComponentModel.DataAnnotations;

namespace Gnnovation.SIMS.Data.Models
{
    public class Server : BusinessEntity
    {   
        [Required, StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int StatusId { get; set; }

        public virtual Enterprise Enterprise { get; set; }

        [Required]
        public int EnterpriseId { get; set; }
    }
}