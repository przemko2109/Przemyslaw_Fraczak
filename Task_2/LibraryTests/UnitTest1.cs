using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Models;
using Presentation.ViewModel;
using Service;
using System.Collections.ObjectModel;

namespace LibraryTests
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<User> users = mainViewModel.GetUsers();
            Assert.AreEqual(users.Count, DataService.userAmount());
        }
        [TestMethod]
        public void TestMethod2()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<Catalog> books = mainViewModel.GetCatalogBooks();
            Assert.AreEqual(books.Count, DataService.catalogBooksAmount());
        }
        [TestMethod]
        public void TestMethod3()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<UserBook> books = mainViewModel.GetUserBooks();
            Assert.AreEqual(books.Count, DataService.userBooksAmount());
        }

        [TestMethod]
        public void TestMethod4()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<User> users = mainViewModel.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(users[i].Name, DataService.getUser(users[i].UserId).user_name);
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<Catalog> books = mainViewModel.GetCatalogBooks();
            for (int i = 0; i < books.Count; i++)
            {
                Assert.AreEqual(books[i].Title, DataService.getCatalogBook(books[i].BookId).title);
                Assert.AreEqual(books[i].AuthorName, DataService.getCatalogBook(books[i].BookId).author_name);
            }
        }
        [TestMethod]
        public void TestMethod6()
        {
            MainViewModel mainViewModel = new MainViewModel();
            ObservableCollection<UserBook> books = mainViewModel.GetUserBooks();
            for (int i = 0; i < books.Count; i++)
            {
                Assert.AreEqual(books[i].UserBookBookId, DataService.getBookId(books[i].UserBookId));
                Assert.AreEqual(books[i].UserBookUserId, DataService.getUserId(books[i].UserBookId));
            }

        }
    }
}