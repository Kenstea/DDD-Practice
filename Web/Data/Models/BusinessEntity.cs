using System;
using System.ComponentModel.DataAnnotations;

namespace Gnnovation.SIMS.Data.Models
{
    public class BusinessEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } 

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string CreatedBy { get; set; }   

        public string ModifiedBy { get; set; }

        public virtual void OnInsert()
        {
            var currentDate = DateTime.UtcNow;

            CreatedBy = "admin";
            CreatedAt = currentDate;
            ModifiedBy = "admin";
            ModifiedAt = currentDate;
        }

        public virtual void OnUpdate()
        {
            ModifiedBy = "admin";
            ModifiedAt = DateTime.UtcNow;
        }
    }
}