using System.Web.Mvc;

using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardControllerService _dashboardControllerService;

        public DashboardController(IDashboardControllerService dashboardControllerService)
        {
            _dashboardControllerService = dashboardControllerService;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var enterprises = _dashboardControllerService.GetAll();
            return View(enterprises);
        }
    }
}