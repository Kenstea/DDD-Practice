using System.Data.Entity;

using Gnnovation.SIMS.Data.Models;
using Gnnovation.SIMS.ViewModels;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Gnnovation.SIMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Server> Servers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is BusinessEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.OnInsert();
                            break;

                        case EntityState.Modified:
                            entity.OnUpdate();
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}