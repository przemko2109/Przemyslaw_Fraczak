using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataRepository repository = new DataRepository();
        [TestMethod]
        public void TestMethod1()
        {
            Books book1 = new Books("aaa", 123, "Jan Kowalski", BookType.Drama);
            Books book2 = new Books("bbb", 456, "Kamil Nowak", BookType.Children);
            repository.addBook(book1);
            repository.addBook(book2);
            State state1 = new State(repository.getBookList());
            Books b1 = state1.States[0];
            Books b2 = state1.States[1];
            Assert.AreEqual(book1, b1);
            Assert.AreEqual(book2, b2);
            Assert.AreEqual(repository.getBookList().Count, 2);
            Assert.AreEqual(repository.getBook(book1).AuthorName, "Jan Kowalski");
            Assert.AreEqual(repository.getBook(book1).Title, "aaa");
            Assert.AreEqual(repository.getBook(book1).BookId, 123);
            Assert.AreEqual(repository.getBook(book1).Genre, BookType.Drama);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Users user1 = new Users("Jan Kowalski", 111);
            Users user2 = new Users("Kamil Nowak", 222);
            repository.addUser(user1);
            repository.addUser(user2);
            Assert.AreEqual(repository.getUser(user1).userName, "Jan Kowalski");
            Assert.AreEqual(repository.getUser(user1).userId, 111);
            Assert.AreEqual(repository.getUser(user2).userName, "Kamil Nowak");
            Assert.AreEqual(repository.getUser(user2).userId, 222);
            Assert.AreEqual(repository.getUserList()[0], user1);
            Assert.AreEqual(repository.getUserList()[1], user2);
            Assert.AreEqual(repository.getUserList().Count, 2);
        }
    }
}
