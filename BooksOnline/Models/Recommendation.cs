using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    //public enum Category
    //{
    //    Fiction, Mistery, Historical, Fantasy, Romance, ScienceFiction, Horror, Humor, NonFiction, Autobiography, Science, Cookbooks,
    //    GraphicNovels, Poetry, Children, Teen, Literature, StoreChoice, Week, Month, Year, Decade
    //}

    public class Recommendation
    {
        public int ID { get; set; }
        public int BookID { get; set; }

        public string Category { get; set; }
        [DisplayName("Date")]
        public string date { get; set; }

        //Recommendation to book: Each recommendation can have one book

        public virtual Book Book { get; set; }

    }
}