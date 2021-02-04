using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    public class Reviews
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        public string Review { get; set; }

        public double Rating { get; set; }

        //User to Review to Book : Each review refers to one book and is done by one user

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }


    }
}