using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using BooksOnline.Models;

namespace BooksOnline.Common
{
    public static class Email
    {
        public static async Task<Response> SendEmail()
        {
            var apiKey = ConfigurationManager.AppSettings["emailAPI"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mohitsharma3119@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("juliana.assignment8@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return await client.SendEmailAsync(msg);
        }
        
        public static async Task<Response> WishlistAlert(List<Book> booklist, User user)
        {
            String userEmail = "juliana.assignment8@gmail.com";
            //string userEmail = user.Email;
            String userName = user.FirstName + " " + user.LastName;
            String context = "Dear user " + userName + ".\n The following books are now available on Books Online:";
            String html = "<p> Dear user " + userName + ".\n The following books are now available on Books Online:</p><br><ul>";
            
            foreach (var book in booklist)
            {
                int bookid = book.ID;
                String bookName = book.Title;
                double bookPrice = book.Price;
                context = context + bookName + " for the price: " + bookPrice + ".\n";
                html = html + "<li>" + bookName + " for the price: " + bookPrice + "</li>";
            }                    
            context = context + "If  you wish to not receive this email anymore. Please access BooksOnline to change your wishlist settings. \n Regards, BooksOnlineTeam.";
            html = html + "</ul><br><p>If you wish to not receive this email anymore. Please access BooksOnline to change your wishlist settings.<br> Regards, BooksOnlineTeam. </p> ";
            
            var apiKey = ConfigurationManager.AppSettings["emailAPI"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mohitsharma3119@gmail.com", "Admin");
            var subject = "Wishlist Alert";
            var to = new EmailAddress(userEmail, "User");
            var plainTextContent = context;
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return await client.SendEmailAsync(msg);
        }

    }
}