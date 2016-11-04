using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DataService
    {
        public List<Models.Album> LoadAllAlbum()
        {
            List<Models.Album> list = new List<Models.Album>();


            var item = new Models.Album();

            item.Genre = "pop";
            item.Title = "The Best Of The Men At Work";
            item.Price = 8;

            list.Add(item);

            var item2 = new Models.Album();

            item2.Genre = "Metal";
            item2.Title = "Black Light Syndrome";
            item2.Price = 20;
            list.Add(item2);
            return list;
        }

    }
}