using Gnnovation.Sims.ApplicationCore.Models;
using Gnnovation.Sims.DomainCore.Services;
using Gnnovation.Sims.Infrastructure.Data;
using Gnnovation.Sims.Infrastructure.Interfaces;

namespace Gnnovation.Sims.ApplicationCore.Services
{
    public interface IEnterpriseService : IService<EnterpriseViewModel, Enterprise>
    {
    }

    public class EnterpriseService : Service<EnterpriseViewModel,Enterprise>, IEnterpriseService
    {
        public EnterpriseService(IRepository<Enterprise> entity)
            : base(entity)
        {
        }
    }
}
