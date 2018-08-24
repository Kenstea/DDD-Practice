using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using ApplicationUser = Gnnovation.Sims.Infrastructure.Data.ApplicationUser;
using Contact = Gnnovation.Sims.Infrastructure.Entities.Contact;
using Enterprise = Gnnovation.Sims.Infrastructure.Entities.Enterprise;
using Server = Gnnovation.Sims.Infrastructure.Entities.Server;

namespace Gnnovation.Sims.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Server> Servers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}