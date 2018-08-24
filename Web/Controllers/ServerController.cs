using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ServerController : Controller
    {
        //private readonly SimsDbContext _context;

        //public ServerController()
        //{
        //    _context = new SimsDbContext();
        //    _context.Configuration.LazyLoadingEnabled = false;
        //}

        //// GET: Enterprise/Detail/5
        //public ActionResult Detail(int id)
        //{
        //    //var server = _context.Servers.Include(s => s.Enterprise).ProjectToType<ServerViewModel>()
        //    //    .FirstOrDefault(e => e.Id == id);
        //    //return View(server);
        //    return View();
        //}


        //// GET: Serer/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    //var server = _context.Servers.Include(s => s.Enterprise).ProjectToType<ServerEditViewModel>()
        //    //    .FirstOrDefault(s => s.Id.Equals(id));
        //    //return View(server);
        //    return View();
        //}

        //// POST: Student/Edit/5 
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for  
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598. 
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var serverToUpdate = _context.Servers.Find(id);
        //    if (TryUpdateModel(serverToUpdate, string.Empty, new string[] { "Name", "Description" }))
        //    {
        //        try
        //        {
        //            _context.SaveChanges();

        //            return RedirectToAction("Detail", "Enterprise", new { id = serverToUpdate.EnterpriseId });
        //        }
        //        catch (RetryLimitExceededException /* dex */)
        //        {
        //            // Log the error (uncomment dex variable name and add a line here to write a log. 
        //            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    return View(serverToUpdate.Adapt<ServerEditViewModel>());
        //}

        //// GET: Enterprise/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    //var server = _context.Servers.Include(e => e.Enterprise)
        //    //    .First(e => e.Id == id);

        //    //if (server == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(server.Adapt<ServerViewModel>());
        //    return View();
        //}

        //// POST: Enterprise/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        var server = _context.Servers.Find(id);
        //        if (server != null)
        //        {
        //            _context.Servers.Remove(server);
        //            _context.SaveChanges();

        //            return RedirectToAction("Detail", "Enterprise", new { id = server.EnterpriseId });
        //        }

        //        ModelState.AddModelError(string.Empty, "Cannot delete.");
        //        return View("Error");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
    }
}
