using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class RandomDataTest
    {
        static RandomGenerator randomGenerator = new RandomGenerator();
        DataRepository randomRepository = new DataRepository(randomGenerator.Generate());

        [TestMethod]
        public void RandomCatalogTest()
        {
            int firstBookId = randomRepository.getCatalogBookList().Keys.ToList()[0].BookId;
            int secondBookId = randomRepository.getCatalogBookList().Keys.ToList()[1].BookId;
            Book book1 = randomRepository.getCatalogBook(firstBookId);
            Book book2 = randomRepository.getCatalogBook(secondBookId);

            Assert.AreNotEqual(firstBookId, secondBookId);
            Assert.AreNotEqual(randomRepository.getCatalogBook(firstBookId).AuthorName, randomRepository.getCatalogBook(secondBookId).AuthorName);
            Assert.AreEqual(randomRepository.getCatalogBookList().Keys.ToList()[0], book1);
            Assert.AreEqual(randomRepository.getCatalogBookList().Keys.ToList()[1], book2);
            Assert.AreEqual(randomRepository.getCatalogBookList().Count, 2);
        }

        [TestMethod]
        public void RandomStateTest()
        {
            int firstBookId = randomRepository.getCatalogBookList().Keys.ToList()[0].BookId;
            int secondBookId = randomRepository.getCatalogBookList().Keys.ToList()[1].BookId;

            Book book1 = randomRepository.getCatalogBook(firstBookId);
            Book book2 = randomRepository.getCatalogBook(secondBookId);

            randomRepository.addState(book1);
            randomRepository.addState(book2);

            Assert.AreEqual(randomRepository.getState(firstBookId), book1);
            Assert.AreEqual(randomRepository.getState(secondBookId), book2);
            Assert.AreNotEqual(randomRepository.getState(firstBookId), randomRepository.getState(secondBookId));
            Assert.AreNotEqual(randomRepository.getState(firstBookId).AuthorName, randomRepository.getState(secondBookId).AuthorName);
            Assert.AreEqual(randomRepository.getStateList().Keys.ToList()[0], book1);
            Assert.AreEqual(randomRepository.getStateList().Keys.ToList()[1], book2);
            Assert.AreEqual(randomRepository.getStateList().Count, 2);

            randomRepository.removeState(book1);

            Assert.AreEqual(randomRepository.getState(secondBookId), book2);
            Assert.AreEqual(randomRepository.getStateList().Keys.ToList()[0], book2);
            Assert.AreEqual(randomRepository.getStateList().Count, 1);
        }

        [TestMethod]
        public void RandomUserTest()
        {
            int firstUserId = randomRepository.getUserList().Keys.ToList()[0].userId;
            int secondUserId = randomRepository.getUserList().Keys.ToList()[1].userId;
            User user1 = randomRepository.getUser(firstUserId);
            User user2 = randomRepository.getUser(secondUserId);

            Assert.AreNotEqual(firstUserId, secondUserId);
            Assert.AreNotEqual(randomRepository.getUser(firstUserId).userName, randomRepository.getUser(secondUserId).userName);
            Assert.AreEqual(randomRepository.getUserList().Keys.ToList()[0], user1);
            Assert.AreEqual(randomRepository.getUserList().Keys.ToList()[1], user2);
            Assert.AreEqual(randomRepository.getUserList().Count, 2);
        }

        [TestMethod]
        public void RandomUserBookTest()
        {
            int firstBookId = randomRepository.getCatalogBookList().Keys.ToList()[0].BookId;
            int secondBookId = randomRepository.getCatalogBookList().Keys.ToList()[1].BookId;
            int firstUserId = randomRepository.getUserList().Keys.ToList()[0].userId;
            int secondUserId = randomRepository.getUserList().Keys.ToList()[1].userId;

            Book book1 = randomRepository.getCatalogBook(firstBookId);
            Book book2 = randomRepository.getCatalogBook(secondBookId);
            User user1 = randomRepository.getUser(firstUserId); 
            User user2 = randomRepository.getUser(secondUserId);

            randomRepository.addUserBook(book1, user1);
            randomRepository.addUserBook(book2, user1);

            Assert.AreNotEqual(firstUserId, secondUserId);
            Assert.AreNotEqual(firstBookId, secondBookId);

            Assert.AreEqual(randomRepository.getUserBook(firstBookId, firstUserId), book1);
            Assert.AreEqual(randomRepository.getUserBook(secondBookId, firstUserId), book2);
            Assert.AreNotEqual(randomRepository.getUserBook(firstBookId, firstUserId).AuthorName, 
                randomRepository.getUserBook(secondBookId, firstUserId).AuthorName);
            Assert.AreEqual(randomRepository.getUserBookList(firstUserId).Count, 2);
            Assert.AreEqual(randomRepository.getUserBookList(secondUserId).Count, 0);

            randomRepository.removeUserBook(book1, user1);

            Assert.AreEqual(randomRepository.getUserBook(secondBookId, firstUserId), book2);
            Assert.AreEqual(randomRepository.getUserBookList(firstUserId).Count, 1);
            Assert.AreEqual(randomRepository.getUserBookList(secondUserId).Count, 0);

            randomRepository.addUserBook(book1, user2);

            Assert.AreEqual(randomRepository.getUserBook(firstBookId, secondUserId), book1);
            Assert.AreEqual(randomRepository.getUserBook(secondBookId, firstUserId), book2);
            Assert.AreNotEqual(randomRepository.getUserBook(firstBookId, secondUserId).AuthorName, 
                randomRepository.getUserBook(secondBookId, firstUserId).AuthorName);
            Assert.AreEqual(randomRepository.getUserBookList(firstUserId).Count, 1);
            Assert.AreEqual(randomRepository.getUserBookList(secondUserId).Count, 1);
        }

        [TestMethod]
        public void RandomEventTest()
        {
            int firstBookId = randomRepository.getCatalogBookList().Keys.ToList()[0].BookId;
            int secondBookId = randomRepository.getCatalogBookList().Keys.ToList()[1].BookId;
            int firstUserId = randomRepository.getUserList().Keys.ToList()[0].userId;
            int secondUserId = randomRepository.getUserList().Keys.ToList()[1].userId;

            Book book1 = randomRepository.getCatalogBook(firstBookId);
            Book book2 = randomRepository.getCatalogBook(secondBookId);
            User user1 = randomRepository.getUser(firstUserId);
            User user2 = randomRepository.getUser(secondUserId);
            Event event1 = new Event(book1, user1, StateType.lending, new System.DateTime(2020, 10, 10));
            Event event2 = new Event(book1, user1, StateType.returning, new System.DateTime(2020, 10, 10));
            Event event3 = new Event(book2, user2, StateType.lending, new System.DateTime(2020, 12, 4));
            randomRepository.addEvent(event1);
            randomRepository.addEvent(event2);
            randomRepository.addEvent(event3);

            Assert.AreEqual(randomRepository.getEventList()[0].stateType, StateType.lending);
            Assert.AreEqual(randomRepository.getEventList()[0].Book.BookId, firstBookId);
            Assert.AreEqual(randomRepository.getEventList()[0].User.userId, firstUserId);
            Assert.AreEqual(randomRepository.getEventList()[1].stateType, StateType.returning);
            Assert.AreEqual(randomRepository.getEventList()[1].Book.BookId, firstBookId);
            Assert.AreEqual(randomRepository.getEventList()[1].User.userId, firstUserId);
            Assert.AreEqual(randomRepository.getEventList()[2].stateType, StateType.lending);
            Assert.AreEqual(randomRepository.getEventList()[2].Book.BookId, secondBookId);
            Assert.AreEqual(randomRepository.getEventList()[2].User.userId, secondUserId);
            Assert.AreEqual(randomRepository.getEventList().Count, 3);
        }
    }
}
