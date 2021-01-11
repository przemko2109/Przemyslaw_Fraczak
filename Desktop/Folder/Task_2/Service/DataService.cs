using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public static class DataService
    {
        public static void addCatalogBook(string title, int book_id, string author_name, string genre)
        {
            try
            {
                Catalog book = new Catalog();
                book.author_name = author_name;
                book.id = book_id;
                book.title = title;
                book.genre = genre;

                DatabaseDataContext db = new DatabaseDataContext();
                db.Catalog.InsertOnSubmit(book);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void addUser(string user_name, int user_id)
        {
            try
            {
                Users user = new Users();
                user.user_name = user_name;
                user.user_id = user_id;

                DatabaseDataContext db = new DatabaseDataContext();
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void removeCatalogBook(int book_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Catalog book = db.Catalog.Where(p => p.id == book_id).First();
                db.Catalog.DeleteOnSubmit(book);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void removeUser(int user_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Users user = db.Users.Where(p => p.user_id == user_id).First();
                db.Users.DeleteOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void updateTitle(string title, int book_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Catalog book = db.Catalog.Where(p => p.id == book_id).First();
                book.title = title;
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void updateAuthorName(string author_name, int book_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Catalog book = db.Catalog.Where(p => p.id == book_id).First();
                book.author_name = author_name;
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void updateGenre(string genre, int book_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Catalog book = db.Catalog.Where(p => p.id == book_id).First();
                book.genre = genre;
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void updateName(string name, int user_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Users user = db.Users.Where(p => p.user_id == user_id).First();
                user.user_name = name;
                db.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }

        public static int getBookId(int _id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                UserBooks user_book = db.UserBooks.Where(p => p.user_book_id == _id).First();
                return user_book.book_id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static int getUserId(int _id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                UserBooks user_book = db.UserBooks.Where(p => p.user_book_id == _id).First();
                return user_book.user_id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static Catalog getCatalogBook(int id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Catalog book = db.Catalog.Where(p => p.id == id).First();
                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static UserBooks getUserBook(int book_id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                UserBooks book = db.UserBooks.Where(p => p.book_id == book_id).First();
                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Users getUser(int id)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                Users user = db.Users.Where(p => p.user_id == id).First();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int getLastCatalogBookId()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            if (catalogBooksAmount() == 0) return 0;
            else return db.Catalog.OrderByDescending(p => p.id).First().id;
        }
        public static int getLastUserId()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            if (userAmount() == 0) return 0;
            else return db.Users.OrderByDescending(p => p.user_id).First().user_id;
        }
        public static int getLastUserBookId()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            if (userBooksAmount() == 0) return 0;
            else return db.UserBooks.OrderByDescending(p => p.book_id).First().user_book_id;
        }

        static public int catalogBooksAmount()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            return db.Catalog.Count();
        }
        static public int userAmount()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            return db.Users.Count();
        }
        static public int userBooksAmount()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            return db.UserBooks.Count();
        }

        public static void borrowBook(int id, int book_id, int user_id)
        {
            try
            {
                Catalog book = getCatalogBook(book_id);
                Users user = getUser(user_id);
                DatabaseDataContext db = new DatabaseDataContext();
                UserBooks u_book = new UserBooks();
                u_book.user_book_id = id;
                u_book.book_id = book_id;
                u_book.user_id = user_id;
                db.UserBooks.InsertOnSubmit(u_book);
                db.SubmitChanges();
            }
            catch(Exception)
            {

            }
        }
        public static void returnBook(int _bookId)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                UserBooks user_books = db.UserBooks.Where(p => p.book_id == _bookId).First();
                db.UserBooks.DeleteOnSubmit(user_books);
                db.SubmitChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}

