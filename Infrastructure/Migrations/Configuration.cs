using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using Gnnovation.Sims.Infrastructure.Data;

namespace Gnnovation.Sims.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = " Gnnovation.Sims.Infrastructure.Data.SimsDbContext";
        }

        //public ApplicationUserManager _userManager { get; set; }

        protected override void Seed(SimsDbContext context)
        {
            var currentDateTime = DateTime.UtcNow;

            var enterprises = new List<Enterprise>
                                  {
                                      new Enterprise
                                          {
                                              Address = "1st Dallas, TX 75287",
                                              FullName = "Testing Company",
                                              ShortName = "Test CO.",
                                              CreatedAt = currentDateTime,
                                              CreatedBy = "admin",
                                              ModifiedAt = currentDateTime,
                                              ModifiedBy = "admin"
                                          },
                                      new Enterprise
                                          {
                                              Address = "2nd Dallas, TX 75287",
                                              FullName = "Quality Company",
                                              ShortName = "Quality CO.",
                                              CreatedAt = currentDateTime,
                                              CreatedBy = "admin",
                                              ModifiedAt = currentDateTime,
                                              ModifiedBy = "admin"
                                          },
                                      new Enterprise
                                          {
                                              Address = "3rd Dallas, TX 75287",
                                              FullName = "Orange Company",
                                              ShortName = "Orange CO.",
                                              CreatedAt = currentDateTime,
                                              CreatedBy = "admin",
                                              ModifiedAt = currentDateTime,
                                              ModifiedBy = "admin"
                                          },
                                      new Enterprise
                                          {
                                              Address = "4th Dallas, TX 75287",
                                              FullName = "Apple Company",
                                              ShortName = "Apple CO.",
                                              CreatedAt = currentDateTime,
                                              CreatedBy = "admin",
                                              ModifiedAt = currentDateTime,
                                              ModifiedBy = "admin"
                                          }
                                  };

            enterprises.ForEach(e => context.Enterprises.AddOrUpdate(r => r.Id, e));
            context.SaveChanges();

            var contacts = new List<Contact>
                               {
                                   new Contact
                                       {
                                           FirstName = "Alex",
                                           Email = "alex@mail.com",
                                           LastName = "Sander",
                                           MiddleName = "M",
                                           Phone = "9723520302",
                                           CreatedAt = currentDateTime,
                                           CreatedBy = "admin",
                                           ModifiedAt = currentDateTime,
                                           ModifiedBy = "admin",
                                           //IsActive = true,
                                           EnterpriseId = enterprises.Single(e => e.ShortName == "Apple CO.").Id
                                       },
                                   new Contact
                                       {
                                           FirstName = "John",
                                           Email = "John@mail.com",
                                           LastName = "Ken",
                                           MiddleName = "M",
                                           Phone = "9723520303",
                                           CreatedAt = currentDateTime,
                                           CreatedBy = "admin",
                                           ModifiedAt = currentDateTime,
                                           ModifiedBy = "admin",
                                           //IsActive = true,
                                           EnterpriseId = enterprises.Single(e => e.ShortName == "Orange CO.").Id
                                       }
                               };

            contacts.ForEach(c => context.Contacts.AddOrUpdate(e => e.Id, c));
            context.SaveChanges();

            var severs = new List<Server>
                               {
                                   new Server
                                       {
                                           Name = "DevServer",
                                           Description = "Development server",
                                           StatusId = 1,
                                           CreatedAt = currentDateTime,
                                           CreatedBy = "admin",
                                           ModifiedAt = currentDateTime,
                                           ModifiedBy = "admin",
                                           //IsActive = true,
                                           EnterpriseId = enterprises.Single(e => e.ShortName == "Apple CO.").Id
                                       },
                                   new Server
                                   {
                                       Name = "StagServer",
                                       Description = "Staging server",
                                       StatusId = 2,
                                       CreatedAt = currentDateTime,
                                       CreatedBy = "admin",
                                       ModifiedAt = currentDateTime,
                                       ModifiedBy = "admin",
                                       //IsActive = true,
                                       EnterpriseId = enterprises.Single(e => e.ShortName == "Apple CO.").Id
                                   },
                                   new Server
                                       {
                                           Name = "ProdServer",
                                           Description = "Production server",
                                           StatusId = 1,
                                           CreatedAt = currentDateTime,
                                           CreatedBy = "admin",
                                           ModifiedAt = currentDateTime,
                                           ModifiedBy = "admin",
                                           //IsActive = true,
                                           EnterpriseId = enterprises.Single(e => e.ShortName == "Orange CO.").Id
                                       } ,
                                   new Server
                                   {
                                       Name = "TestServer",
                                       Description = "Test server",
                                       StatusId = 3,
                                       CreatedAt = currentDateTime,
                                       CreatedBy = "admin",
                                       ModifiedAt = currentDateTime,
                                       ModifiedBy = "admin",
                                       //IsActive = true,
                                       EnterpriseId = enterprises.Single(e => e.ShortName == "Quality CO.").Id
                                   }

                               };

            severs.ForEach(c => context.Servers.AddOrUpdate(e => e.Id, c));
            context.SaveChanges();

            var user = new ApplicationUser
            {
                Email = "",
                UserName = ""
            };
        }
    }
}
