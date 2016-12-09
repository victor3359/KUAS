using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebApplication1.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            Service.DatabaseService db = new Service.DatabaseService();
            var list = db.LoadAllAlbum();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult Create(Models.Album newAlbum)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            newAlbum.ID = Guid.NewGuid().ToString();
            db.CreateAlbum(newAlbum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            var model = db.GetAlbumByID(id);
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult Update(Models.Album newAlbum)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            db.UpdateAlbum(newAlbum);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            Service.DatabaseService db = new Service.DatabaseService();
            db.DeleteAlbum(id);
            return RedirectToAction("Index");
        }




    }
}