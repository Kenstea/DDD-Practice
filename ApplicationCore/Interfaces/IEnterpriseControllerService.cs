using DomainCore.Models;
using PagedList;

namespace ApplicationCore.Interfaces
{   
    /// <summary>
    /// Carries all methods for Enterprise Controller.
    /// </summary>
    public interface IEnterpriseControllerService
    {
        EnterpriseViewModel GetDetail(int enterpriseId);

        IPagedList<EnterpriseViewModel> GetPagedList(int? pageNumber, int? pageSize);

        bool Insert(EnterpriseCreateViewModel enterpriseCreateViewModel);
    }
}