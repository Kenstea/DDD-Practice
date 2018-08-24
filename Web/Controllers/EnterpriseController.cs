using System.Data;
using System.Net;
using System.Web.Mvc;
using ApplicationCore.Interfaces;
using DomainCore.Models;
using Mapster;

namespace Web.Controllers
{
    public class EnterpriseController : Controller
    { 
        private readonly IEnterpriseControllerService _enterpriseControllerService;

        public EnterpriseController(IEnterpriseControllerService enterpriseControllerService)
        { 
            _enterpriseControllerService = enterpriseControllerService;
        }

        // GET: Enterprise
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
          
            return View(_enterpriseControllerService.GetPagedList(pageNumber, pageSize));
        }

        // GET: Enterprise/Detail/5
        public ActionResult Detail(int id)
        {
            var enterprise = _enterpriseControllerService.GetDetail(id);

            if (enterprise == null)
            {
                return HttpNotFound();
            }

            return View(enterprise);
        }

        // GET: Student/Create 
        public ActionResult Create()
        {
            return View();
        }

        // Post: Enterprise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShortName, FullName, Address")] EnterpriseCreateViewModel enterpriseCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _enterpriseControllerService.Insert(enterpriseCreateViewModel);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(enterpriseCreateViewModel);
        }

        // GET: Enterprise/Edit/5
        public ActionResult Edit(int id)
        {
            var enterpriseViewModel = _enterpriseControllerService.GetDetail(id);
            return View(enterpriseViewModel);
        }

        // POST: Student/Edit/5 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for  
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enterpriseToUpdate = _enterpriseControllerService.GetDetail(id.Value);
            //if (TryUpdateModel(enterpriseToUpdate, string.Empty, new[] { "ShortName", "FullName", "Address" }))
            //{
            //    try
            //    {
            //        _context.SaveChanges();

            //        return RedirectToAction("Index");
            //    }
            //    catch (RetryLimitExceededException /* dex */)
            //    {
            //        // Log the error (uncomment dex variable name and add a line here to write a log. 
            //        ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //    }
            //}

            return View(enterpriseToUpdate.Adapt<EnterpriseViewModel>());
        }

        // GET: Enterprise/Delete/5
        public ActionResult Delete(int id)
        {
            //var enterprise = _context.Enterprises.Include(e => e.Servers).ProjectToType<EnterpriseViewModel>()
            //    .First(e => e.Id == id);

            //if (enterprise == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(enterprise);

            return View();
        }

        // POST: Enterprise/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            //    var enterprise = _context.Enterprises.Find(id);
            //    if (enterprise != null)
            //    {
            //        _context.Enterprises.Remove(enterprise);
            //        _context.SaveChanges();
            //    }
            //    else
            //    {
            //        ModelState.AddModelError(string.Empty, "Cannot delete.");
            //    }

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            return View();
        }
    }
}
