using DomainCore.Interfaces;
using Infrastructure.Data;

namespace DomainCore.Services
{
    public class EnterpriseService : ServiceBase<Enterprise, int>, IEnterpriseService
    {
        public EnterpriseService(Enterprise entity)
            : base(entity)
        {   
        }
    }
}
