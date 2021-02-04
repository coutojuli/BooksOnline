using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    public class Picture
    {
        public int id { get; set; }

        public int BookID { get; set; }

        [DisplayName("Book Name")]
        public string title { get; set; }
        [DisplayName("Reference Page")]
        public string page { get; set; }
        [DisplayName("Upload File")]
        public string path { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //Picture to Book: One picture can be of one book
        public virtual Book Book { get; set; }
    }
}