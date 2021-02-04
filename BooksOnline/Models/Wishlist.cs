using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    public class Wishlist
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string Notification { get; set; }

        // Wishlist to User to Book : Each wishlist entry refers to one book and is done by one user

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }


    }
}