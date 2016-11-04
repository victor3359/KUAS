using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public class AlbumWithCount
        {
            public Models.Album Data { get; set; }
            public int ReadCount { get; set; }
        }


        // GET: Home
        public ActionResult Index(string id,string name,string title)
        {
            ViewBag.ID = id;
            Service.DataService data = new Service.DataService();
            var list = data.LoadAllAlbum();
            var result = list.ToList().Select(x =>
              {
                  var item = new AlbumWithCount();
                  item.Data = x;
                  item.ReadCount = 100;
                  return item;
              }).ToList();

            //ViewBag.ReadCount = 0;

            return View(result);
            //return Content("<h1>hello world</h1>" + id);
        }
    }
}