using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;

namespace ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Catalog book = new Catalog() { id = 21, author_name = "Stefan Zeromski", title = "Ludzie bezdomni", genre = "Classic" };
            DataService.addCatalogBook(book.title, book.id, book.author_name, book.genre);
            Assert.AreEqual(DataService.getCatalogBook(book.id).author_name, "Stefan Zeromski");
            Assert.AreEqual(DataService.getCatalogBook(book.id).title, "Ludzie bezdomni");
            Assert.AreEqual(DataService.getCatalogBook(book.id).genre, "Classic");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Catalog book = new Catalog() { id = 14, title = "Wolanie do yeti", author_name = "Wislawa Szymborska", genre = "Poetry" };
            DataService.addCatalogBook(book.title, book.id, book.author_name, book.genre);
            Catalog book1 = DataService.getCatalogBook(book.id);
            Assert.AreEqual(book.id, book1.id);
            Assert.AreEqual(book.title, book1.title);
            Assert.AreEqual(book.author_name, book1.author_name);
            Assert.AreEqual(book.genre, book1.genre);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Catalog book = new Catalog() { id = 28, author_name = "Adam Mickiewicz", title = "Pan Tadeusz", genre = "Classic" };
            DataService.addCatalogBook(book.title, book.id, book.author_name, book.genre);
            int x1 = DataService.catalogBooksAmount();
            DataService.removeCatalogBook(book.id);
            int x2 = DataService.catalogBooksAmount();
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Catalog book = new Catalog() { id = 35, author_name = "Henryk Sienkiewicz", title = "Krzyżacy", genre = "History" };
            DataService.addCatalogBook(book.title, book.id, book.author_name, book.genre);
            DataService.updateTitle("Lalka", book.id);
            DataService.updateAuthorName("Boleslaw Prus", book.id);
            DataService.updateGenre("Classic", book.id);
            book = DataService.getCatalogBook(book.id);
            Assert.AreEqual(book.title, "Lalka");
            Assert.AreEqual(book.author_name, "Boleslaw Prus");
            Assert.AreEqual(book.genre, "Classic");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Users user = new Users() { user_id = 42, user_name = "Stefan" };
            DataService.addUser(user.user_name, user.user_id);
            Assert.AreEqual(DataService.getUser(user.user_id).user_name, "Stefan");
        }

        [TestMethod]
        public void TestMethod6()
        {
            Users user = new Users() { user_id = 49, user_name = "Dobrawa" };
            DataService.addUser(user.user_name, user.user_id);
            Users user1 = DataService.getUser(user.user_id);
            Assert.AreEqual(user.user_id, user1.user_id);
            Assert.AreEqual(user.user_name, user1.user_name);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Users user = new Users() { user_id = 56, user_name = "Zygmunt" };
            DataService.addUser(user.user_name, user.user_id);
            int x1 = DataService.userAmount();
            DataService.removeUser(user.user_id);
            int x2 = DataService.userAmount();
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Users user = new Users() { user_id = 63, user_name = "Horacy" };
            DataService.addUser(user.user_name, user.user_id);
            DataService.updateName("Felicja", user.user_id);
            user = DataService.getUser(user.user_id);
            Assert.AreEqual(user.user_name, "Felicja");
        }

        [TestMethod]
        public void TestMethod9()
        {
            Catalog book = new Catalog() { id = 70, author_name = "Dan Brown", title = "Da Vinci Code", genre = "Thriller" };
            DataService.addCatalogBook(book.title, book.id, book.author_name, book.genre);
            Users user = new Users() { user_id = 70, user_name = "Paweł" };
            DataService.addUser(user.user_name, user.user_id);
            DataService.borrowBook(101, book.id, user.user_id);
            Assert.AreEqual(DataService.getUserBook(book.id).user_id, user.user_id);
        }
    }
}
