using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre

        public ActionResult Index(int? genreID)
        {
            List<Models.Albums> result = new List<Models.Albums>();
            Service.Database2Service db2 = new Service.Database2Service();

            var genres=db2.LoadAllGenre();

            ViewBag.Genres = genres;
            ViewBag.SelectedGenreID = genreID;

            if (genreID != null)
            {
                result = db2.LoadAlbumByGenreID(genreID.Value);
            }
            return  View(result);
        }




        public ActionResult EFIndex(int? genreID)
        {
            List<Models.Album> result = new List<Models.Album>();
            Service.EFService efDb = new Service.EFService();

            var genres = efDb.Genres.ToList();

            ViewBag.Genres = genres;
            ViewBag.SelectedGenreID = genreID;


            var selectedGenre = genres.SingleOrDefault(x => x.GenreId == genreID);

            //selectedGenre = efDb.Genres.Where(x => x.GenreId == genreID).SingleOrDefault();


            if (selectedGenre != null)
            {
                result = selectedGenre.Albums.ToList();


            }
            return View(result);
        }

    }
}