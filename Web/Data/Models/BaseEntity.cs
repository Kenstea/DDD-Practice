using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gnnovation.SIMS.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public virtual void OnInsert()
        {
        }

        public virtual void OnUpdate()
        {
        }
    }
}