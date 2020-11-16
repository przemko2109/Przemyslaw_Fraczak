using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System;

namespace LogicTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataService service = new DataService();

        [TestMethod]
        public void EventMethod()
        {
            Books book1 = new Books("Book1", 123, "Author1", BookType.Drama);
            Books book2 = new Books("Book2", 456, "Author2", BookType.Children);
            Books book3 = new Books("Book2", 456, "Author2", BookType.Children);
            Users user1 = new Users("User1", 111);
            Users user2 = new Users("User2", 222);

            service.addBook(book1);
            service.addBook(book2);
            service.addUser(user1);
            service.addUser(user2);

            service.takeBook(book1, user1, new System.DateTime(2020, 10, 09));
            service.takeBook(book1, user2, new System.DateTime(2020, 10, 09));
            service.returnBook(book1, user1, new System.DateTime(2020, 11, 20));
            service.takeBook(book2, user2, new System.DateTime(2020, 05, 07));
            service.returnBook(book2, user2, new System.DateTime(2020, 06, 07));

            Assert.AreEqual(service.getEvent().Count, 4);

            Assert.AreEqual(service.getEvent()[0].Book, book1);
            Assert.AreEqual(service.getEvent()[1].Book, book1);
            Assert.AreEqual(service.getEvent()[2].Book, book2);
            Assert.AreEqual(service.getEvent()[3].Book, book2);

            Assert.AreEqual(service.getEvent()[0].usersOfLibrary, user1);
            Assert.AreEqual(service.getEvent()[1].usersOfLibrary, user1);
            Assert.AreEqual(service.getEvent()[2].usersOfLibrary, user2);
            Assert.AreEqual(service.getEvent()[3].usersOfLibrary, user2);

            Assert.AreEqual(service.getEvent()[0].penaltyPrice, 0);
            Assert.AreEqual(service.getEvent()[1].penaltyPrice, 12);
            Assert.AreEqual(service.getEvent()[2].penaltyPrice, 0);
            Assert.AreEqual(service.getEvent()[3].penaltyPrice, 1);
        }

        [TestMethod]
        public void StateMethod()
        {
            Books book1 = new Books("Book1", 123, "Author1", BookType.Drama);
            Books book2 = new Books("Book2", 456, "Author2", BookType.Children);
            Books book3 = new Books("Book2", 789, "Author2", BookType.Children);
            Users user1 = new Users("User1", 111);
            Users user2 = new Users("User2", 222);
            Users user3 = new Users("User2", 222);

            service.addBook(book3);
            service.addBook(book2);
            service.addBook(book1);

            service.addUser(user1);
            service.addUser(user2);
            service.addUser(user3);

            service.takeBook(book1, user1, new System.DateTime(2020, 10, 09));
            service.takeBook(book1, user2, new System.DateTime(2020, 10, 09));
            service.returnBook(book1, user1, new System.DateTime(2020, 11, 20));
            service.takeBook(book2, user2, new System.DateTime(2020, 05, 07));
            service.returnBook(book2, user2, new System.DateTime(2020, 06, 07));

            Assert.AreEqual(service.getState().States[0], book3);
            Assert.AreEqual(service.getState().States[1], book1);
            Assert.AreEqual(service.getState().States[2], book2);
        }
        [TestMethod]
        public void UserMethod()
        {
            Books book1 = new Books("Book1", 123, "Author1", BookType.Drama);
            Books book2 = new Books("Book2", 456, "Author2", BookType.Children);
            Books book3 = new Books("Book2", 789, "Author2", BookType.Children);
            Users user1 = new Users("User1", 111);
            Users user2 = new Users("User2", 222);
            Users user3 = new Users("User3", 333);
            Users user4 = new Users("User4", 444);

            service.addBook(book3);
            service.addBook(book2);
            service.addBook(book1);

            service.addUser(user1);
            service.addUser(user2);
            service.addUser(user3);

            service.takeBook(book1, user1, new System.DateTime(2020, 10, 09));
            service.takeBook(book1, user2, new System.DateTime(2020, 10, 09));
            service.returnBook(book1, user1, new System.DateTime(2020, 11, 20));
            service.takeBook(book2, user2, new System.DateTime(2020, 05, 07));
            service.returnBook(book2, user2, new System.DateTime(2020, 06, 07));

            Assert.AreEqual(service.getUsers()[1], user2);
            Assert.AreEqual(service.getUsers().Count, 3);
            Assert.AreEqual(service.getUsers()[2].userName, "User3");
            Assert.AreEqual(service.checkIfUserExists(user2), true);
            Assert.AreEqual(service.checkIfUserExists(user4), false);
        }
        [TestMethod]
        public void BookMethod()
        {
            Books book1 = new Books("Book1", 123, "Author1", BookType.Drama);
            Books book2 = new Books("Book2", 456, "Author2", BookType.Children);
            Books book3 = new Books("Book3", 789, "Author3", BookType.Children);
            Books book4 = new Books("Book4", 729, "Author4", BookType.Horror);
            Users user1 = new Users("User1", 111);
            Users user2 = new Users("User2", 222);
            Users user3 = new Users("User2", 333);

            service.addBook(book3);
            service.addBook(book2);
            service.addBook(book1);

            service.addUser(user1);
            service.addUser(user2);
            service.addUser(user3);

            service.takeBook(book1, user1, new System.DateTime(2020, 10, 09));
            service.takeBook(book1, user2, new System.DateTime(2020, 10, 09));
            service.returnBook(book1, user1, new System.DateTime(2020, 11, 20));
            service.takeBook(book2, user2, new System.DateTime(2020, 05, 07));
            service.returnBook(book2, user2, new System.DateTime(2020, 06, 07));

            Assert.AreEqual(service.getBooks()[1], book1);
            Assert.AreEqual(service.getBooks().Count, 3);
            Assert.AreEqual(service.getBooks()[2].Title, "Book2");
            Assert.AreEqual(service.checkIfBookExists(book3), true);
            Assert.AreEqual(service.checkIfBookExists(book4), false);
        }
    }
}
