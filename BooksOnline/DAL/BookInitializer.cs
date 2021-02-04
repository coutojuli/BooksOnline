using BooksOnline.DAL;
using BooksOnline.Helpers;
using BooksOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOnline.DAL
{
    public class BookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookContext>
    {
        string password = Password.GetHashValue("12345");
        protected override void Seed(BookContext context)
        {       

            var users = new List<User>
            {
                new User{id=1,Password=password, ConfirmPassword=password, Role=Role.Admin,Email="juliana@test.ca",FirstName="Juliana",LastName="Claussen",DOB="10-10-1990",Phone="999-999-999",Address="2000 Yonge Street" },
                new User{id=2,Password=password, ConfirmPassword=password, Role=Role.Admin,Email="mohit@test.ca",FirstName="Mohit",LastName="Sharma",DOB="10-10-1990",Phone="999-999-999",Address="1999 Yonge Street" },
                new User{id=3,Password=password, ConfirmPassword=password, Role=Role.User,Email="ana@test.ca",FirstName="Ana",LastName="Paula",DOB="10-10-1990",Phone="999-999-999",Address="1998 Yonge Street" },
                new User{id=4,Password=password, ConfirmPassword=password, Role=Role.User,Email="rafael@test.ca",FirstName="Rafael",LastName="Tree",DOB="10-10-1990",Phone="999-999-999",Address="1997 Yonge Street" }
            };
            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book{Title="Deacon King Kong",Description="A mystery story, a crime novel, an urban farce, a sociological portrait of late-1960s.",Subject="Fiction",Count="10",Author="James McBride",Price=25.95,Format="E-Book",Publisher="Riverhead Books",Pubdate=" 03/03/2020 ",Edition="1",Pages="371",Synopsis="In September 1969, a fumbling, cranky old church deacon known as Sportcoat shuffles...",Availability="Available"},
                new Book{Title="Hamnet",Description="A bold feat of imagination and empathy, this novel gives flesh and feeling to a historical mystery.",Subject="Fiction",Count="7",Author="Maggie O’Farrell",Price=26.95,Format="E-Book",Publisher="Generic",Pubdate=" 03/31/2020 ",Edition="1",Pages="372",Synopsis="Drawing on Maggie O'Farrell's long-term fascination with the little-known story behind Shakespeare's most enigmatic play...",Availability="Available"},
                new Book{Title="The Last Romantics",Description="The greatest works of poetry are the stories we tell about ourselves.",Subject="Fiction",Count="2",Author="Tara Conklin ",Price=14.99,Format="E-Book",Publisher=" HarperAvenue",Pubdate="02/05/2019 ",Edition="1",Pages="384",Synopsis="When the renowned poet Fiona Skinner is asked about the inspiration behind her iconic work, The Love Poem, she tells her audience a story about her family and a betrayal that reverberates through time....",Availability="Available"},
                new Book{Title="The Starless Sea",Description="From the New York Times bestselling author of The Night Circus, a timeless love story set in a secret underground world—a place of pirates, painters, lovers, liars, and ships that sail upon a starless sea.",Subject="Literature",Count="10",Author="Erin Morgenstern ",Price=15.25,Format="E-Book",Publisher="Anchor Canada",Pubdate="08/04/2020",Edition="1",Pages="592",Synopsis="Zachary Ezra Rawlins is a graduate student in Vermont when he discovers a mysterious book hidden in the stacks...",Availability="Available"},
                new Book{Title="Harry Potter",Description="A global phenomenon and cornerstone of contemporary children’s literature, J.K. Rowling’s Harry Potter series is both universally adored and critically acclaimed.",Subject="Fiction",Count="3",Author="J.K.Rowling",Price=24.00,Format="Hardcover",Publisher="Pottermore Publishing",Pubdate=" 11/20/2015 ",Edition="5",Pages="352",Synopsis="Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive...",Availability="Available"},
                new Book{Title="Sorcery of Thorns",Description="A mystery story, a crime novel, an urban farce, a sociological portrait of late-1960s.",Subject="Fiction",Count="10",Author="James McBride",Price=25.95,Format="E-Book",Publisher="Riverhead Books",Pubdate=" 03/03/2020 ",Edition="1",Pages="371",Synopsis="In September 1969, a fumbling, cranky old church deacon known as Sportcoat shuffles...",Availability="Available"},
                new Book{Title="Stormrise",Description="A bold feat of imagination and empathy, this novel gives flesh and feeling to a historical mystery.",Subject="Fiction",Count="7",Author="Maggie O’Farrell",Price=26.95,Format="E-Book",Publisher="Generic",Pubdate=" 03/31/2020 ",Edition="1",Pages="372",Synopsis="Drawing on Maggie O'Farrell's long-term fascination with the little-known story behind Shakespeare's most enigmatic play...",Availability="Available"},
                new Book{Title="Dragon Dancer",Description="The greatest works of poetry are the stories we tell about ourselves.",Subject="Fiction",Count="2",Author="Tara Conklin ",Price=14.99,Format="E-Book",Publisher=" HarperAvenue",Pubdate="02/05/2019 ",Edition="1",Pages="384",Synopsis="When the renowned poet Fiona Skinner is asked about the inspiration behind her iconic work, The Love Poem, she tells her audience a story about her family and a betrayal that reverberates through time....",Availability="Available"},
                new Book{Title="Half Blood Prince",Description="From the New York Times bestselling author of The Night Circus, a timeless love story set in a secret underground world—a place of pirates, painters, lovers, liars, and ships that sail upon a starless sea.",Subject="Literature",Count="10",Author="Erin Morgenstern ",Price=15.25,Format="E-Book",Publisher="Anchor Canada",Pubdate="08/04/2020",Edition="1",Pages="592",Synopsis="Zachary Ezra Rawlins is a graduate student in Vermont when he discovers a mysterious book hidden in the stacks...",Availability="Available"},         
            };
            books.ForEach(book => context.Books.Add(book));
            context.SaveChanges();

            var reviews = new List<Reviews>
            {
                new Reviews{BookID=5,UserID=1,Review="Really good. I will let my mum know about this, she could really make use of Harry Potter and the Sorcerer's Stone! It's all good. Harry Potter and the Sorcerer's Stone should be nominated for book of the year.",Rating=4.4},
                new Reviews{BookID=3,UserID=1,Review="Definitely worth the investment. I would also like to say thank you to all your staff. I would be lost without The Last Romantics.",Rating=5.0},
                new Reviews{BookID=1,UserID=2,Review="t's really wonderful. I just can't get enough of Deacon King Kong.",Rating=4.2},
                new Reviews{BookID=5,UserID=4,Review="Harry Potter and the Sorcerer's Stone is the most valuable book I have EVER purchased.",Rating=4.5},
                new Reviews{BookID=2,UserID=3,Review="I would be lost without Hamnet. Hamnet should be nominated for book of the year. ",Rating=4.7}

            };
            reviews.ForEach(review => context.Reviews.Add(review));
            context.SaveChanges();

            var recommendations = new List<Recommendation>
            {
                new Recommendation{BookID=1,Category="Fiction",date="03-11-2018"},
                new Recommendation{BookID=2,Category="Mistery",date="03-08-2019"},              
                new Recommendation{BookID=3,Category="Fiction",date="03-12-2020"},
                new Recommendation{BookID=4,Category="Mistery",date="03-12-2020"},
                new Recommendation{BookID=5,Category="Historical",date="03-12-2020"},
                new Recommendation{BookID=6,Category="Fantasy",date="03-12-2020"},
                new Recommendation{BookID=7,Category="Romance",date="03-12-2020"},
                new Recommendation{BookID=8,Category="Science Fiction",date="03-12-2020"},
                new Recommendation{BookID=9,Category="Horror",date="03-12-2020"},                
                new Recommendation{BookID=1,Category="Humor",date="03-12-2020"},
                new Recommendation{BookID=2,Category="Non Fiction",date="03-12-2020"},
                new Recommendation{BookID=3,Category="Autobiography",date="03-12-2020"},
                new Recommendation{BookID=4,Category="Science",date="03-12-2020"},
                new Recommendation{BookID=5,Category="Cookbooks",date="03-12-2020"},               
                new Recommendation{BookID=6,Category="Graphic Novels",date="03-12-2020"},
                new Recommendation{BookID=7,Category="Poetry",date="03-12-2020"},
                new Recommendation{BookID=8,Category="Children",date="03-12-2020"},
                new Recommendation{BookID=9,Category="Teen",date="03-12-2020"},
                new Recommendation{BookID=1,Category="Literature",date="03-12-2020"},
                new Recommendation{BookID=2,Category="Store Choice",date="03-12-2020"},
                new Recommendation{BookID=3,Category="Week",date="03-12-2020"},              
                new Recommendation{BookID=4,Category="Month",date="03-12-2020"},
                new Recommendation{BookID=5,Category="Year",date="03-12-2020"},
                new Recommendation{BookID=6,Category="Decade",date="03-12-2020"}
            };
            recommendations.ForEach(recommendation => context.Recommendations.Add(recommendation));
            context.SaveChanges();

            //var Statistics = new List<Statistics>
            //{                                                                                                                                                    
            //    new Statistics{Users="1900",SoldBooks="150",Reservations="200",Reviews="150",Ratings="90",Wishlists="50", Period=Period.Dayly,Type=Calculation.Amount,Date="03-08-2020"},
            //    new Statistics{Users="1500",SoldBooks="100",Reservations="300",Reviews="320",Ratings="120",Wishlists="65",Period=Period.Monthly,Type=Calculation.Amount,Date="02-09-2020"},
            //    new Statistics{Users="2500",SoldBooks="150",Reservations="250",Reviews="199",Ratings="223",Wishlists="97",Period=Period.Yearly,Type=Calculation.Amount,Date="12-10-2020"},
            //    new Statistics{Users="4200",SoldBooks="300",Reservations="440",Reviews="230",Ratings="112",Wishlists="83",Period=Period.Dayly,Type=Calculation.Amount,Date="11-11-2020"},
            //    new Statistics{Users="5000",SoldBooks="120",Reservations="320",Reviews="345",Ratings="46",Wishlists="112",Period=Period.Monthly,Type=Calculation.Amount,Date="04-12-2020"}

            //};
            //Statistics.ForEach(statistic => context.Statistics.Add(statistic)) ;
            //context.SaveChanges();

            var wishlists = new List<Wishlist>
            {
                new Wishlist{ID=1,BookID=1,UserID=1,Notification="Yes"},
                new Wishlist{ID=2,BookID=5,UserID=3,Notification="Yes"},
                new Wishlist{ID=3,BookID=3,UserID=4,Notification="No"},
                new Wishlist{ID=5,BookID=6,UserID=1,Notification="No"},
                new Wishlist{ID=6,BookID=7,UserID=3,Notification="Yes"},
                new Wishlist{ID=7,BookID=8,UserID=4,Notification="Yes"},
                new Wishlist{ID=8,BookID=9,UserID=1,Notification="No"},

            };
            wishlists.ForEach(wishlist => context.Wishlists.Add(wishlist));
            context.SaveChanges();

            var pictures = new List<Picture>
            {
                new Picture{id=1,BookID = 9, title="Half Blood Prince",page="Home",path="~/images/book1201654303.jpg"},
                new Picture{id=2,BookID = 1, title="Deacon King Kong",page="Home",path="~/images/DeaconKingKong200505720201718621.jpg"},
                new Picture{id=3,BookID = 2, title="Hamnet",page="Home",path="~/images/Hamnet201457481201726925.jpg"},
                new Picture{id=4,BookID = 3, title="The Last Romantics",page="Home",path="~/images/TheLastRomantics201558549201736872.jpg"},
                new Picture{id=5,BookID = 4, title="The Starless Sea",page="Home",path="~/images/TheStarlessSea201608995201750411.jpg"},
                new Picture{id=6,BookID = 5, title="Harry Potter",page="Home",path="~/images/HarryPotterandtheSorcerer'sStone201618346201805811.jpg"},
                new Picture{id=7,BookID = 6, title="Sorcery of Thorns",page="Home",path="~/images/book2201817487.jpg"},
                new Picture{id=8,BookID = 7, title="Stormrise",page="Home",path="~/images/book3201827938.jpg"},
                new Picture{id=9,BookID = 8, title="Dragon Dancer",page="Home",path="~/images/book4205618150201838180.jpg"}
            };
            pictures.ForEach(picture => context.Pictures.Add(picture));
            context.SaveChanges();
        }
    }
}