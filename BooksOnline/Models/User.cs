using System.ComponentModel;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOnline.Models
{
    public enum Role
    {
        Admin, User
    }
    public class User
    {
        //[Key, ForeignKey("Login")]
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Role Role { get; set; } = Role.User;
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
 
        public string DOB { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        //User to Login: 1 user can have one login

        //public virtual Login Login { get; set; }

        //User to Review: 1 user can do multiple reviews
        public virtual ICollection<Reviews> Reviews { get; set; }

        //User to Wishlist: 1 user can have multiple wishlist entries

        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}