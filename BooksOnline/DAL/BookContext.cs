using BooksOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BooksOnline.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookContext")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}