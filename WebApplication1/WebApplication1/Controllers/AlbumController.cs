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

    }
}