using System.Collections.Generic;
using DomainCore.Models;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Carries all methods for Dashboard Controller.
    /// </summary>
    public interface IDashboardControllerService
    {
        IEnumerable<EnterpriseViewModel> GetAll();
    }
}