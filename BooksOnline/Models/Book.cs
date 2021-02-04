using BooksOnline.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Count { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Format { get; set; }
        public string Publisher { get; set; }
        public string Pubdate { get; set; }
        public string Edition { get; set; }
        public string Pages { get; set; }
        public string Synopsis { get; set; }
        public string Availability { get; set; }

        //Book to Review: 1 book can have multiple reviews
        public virtual ICollection<Reviews> Reviews { get; set; }

        //Book to Recommendation: 1 book can be in multiple recommendations

        public virtual ICollection<Recommendation> Recommendations { get; set; }

        //Book to Wishlist: 1 book can be in multiple wishlists

        public virtual ICollection<Wishlist> Wishlists { get; set; }

        //Book to Picture: 1 book can have multiple pictures
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}