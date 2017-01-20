using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Album
    {
        public string ID { get; set; }

        public string Genre { get; set; }
        
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

    }
}