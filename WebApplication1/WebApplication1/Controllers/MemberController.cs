using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            Service.DatabaseServiceMember db = new Service.DatabaseServiceMember();
            var list = db.LoadAllMember();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult Create(Models.Member newMember)
        {
            Service.DatabaseServiceMember db = new Service.DatabaseServiceMember();
            //newMember.ID = Guid.NewGuid().ToString();
            db.CreateMember(newMember);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            Service.DatabaseServiceMember db = new Service.DatabaseServiceMember();
            var model = db.GetMemberByID(id);
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult Update(Models.Member newMember)
        {
            Service.DatabaseServiceMember db = new Service.DatabaseServiceMember();
            db.UpdateMember(newMember);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            Service.DatabaseServiceMember db = new Service.DatabaseServiceMember();
            db.DeleteMember(id);
            return RedirectToAction("Index");
        }




    }
}