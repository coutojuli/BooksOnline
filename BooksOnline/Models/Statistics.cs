using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOnline.Models
{
    public enum Period
    {
        Dayly, Monthly, Yearly
    }
    public enum Calculation
    {
        Percentage,Amount
    }
    public class Statistics
    {
        //Percentage

        public int ID { get; set; }

        public string Users { get; set; }

        public string SoldBooks { get; set; }

        public string Reservations { get; set; }

        public string Reviews { get; set; }

        public string Ratings { get; set; }

        public string Wishlists { get; set; }

        public Period Period { get; set; }

        public Calculation Type { get; set; }

        public string Date { get; set; }

    }
}