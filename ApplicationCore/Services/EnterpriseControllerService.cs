using ApplicationCore.Interfaces;
using DomainCore.Interfaces;
using DomainCore.Models;
using PagedList;

namespace ApplicationCore.Services
{
    /// <summary>
    /// This will reflect controller from presenter as 1:1.
    /// </summary>
    /// <seealso cref="IDashboardControllerService" />
    public class EnterpriseControllerService : IEnterpriseControllerService
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseControllerService(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        public EnterpriseViewModel GetDetail(int enterpriseId)
        { 
            //var result = _enterpriseService.Entity.GetQuery().ProjectToType<EnterpriseViewModel>()
            //    .FirstOrDefault(e => e.Id.Equals(enterpriseId));
            var result = _enterpriseService.GetById<EnterpriseViewModel>(enterpriseId);
            return result;
        }

        public IPagedList<EnterpriseViewModel> GetPagedList(int? pageNumber, int? pageSize)
        {   
            return _enterpriseService.GetPagedList<EnterpriseViewModel>(pageNumber, pageSize);
        }

        public bool Insert(EnterpriseCreateViewModel enterpriseCreateViewModel)
        {
            return _enterpriseService.Insert(enterpriseCreateViewModel);
        }
    }
}
