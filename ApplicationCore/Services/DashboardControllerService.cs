using System.Collections.Generic;
using ApplicationCore.Interfaces;
using DomainCore.Interfaces;
using DomainCore.Models;

namespace ApplicationCore.Services
{
    /// <summary>
    /// This will reflect controller from presenter as 1:1.
    /// </summary>
    /// <seealso cref="IDashboardControllerService" />
    public class DashboardControllerService : IDashboardControllerService
    {
        private readonly IEnterpriseService _enterpriseService;

        public DashboardControllerService(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        public IEnumerable<EnterpriseViewModel> GetAll()
        {
            return _enterpriseService.GetAll<EnterpriseViewModel>();
        }
    }
}
