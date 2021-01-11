using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class RandomLogicTest
    {
        static RandomGenerator randomGenerator = new RandomGenerator();
        DataService dataService = new DataService(new DataRepository(randomGenerator.Generate()));

        [TestMethod]
        public void CheckingRandomUser()
        {
            int firstUserId = dataService.getUserList().Keys.ToList()[0].userId;

            Assert.AreEqual(dataService.getUserList().ContainsValue(firstUserId), true);
            Assert.AreEqual(dataService.getUserList().Count, 2);
        }

        [TestMethod]
        public void CheckingRandomBook()
        {
            int firstBookId = dataService.getCatalogBookList().Keys.ToList()[0].BookId;

            Assert.AreEqual(dataService.getCatalogBookList().ContainsValue(firstBookId), true);
            Assert.AreEqual(dataService.getCatalogBookList().Count, 2);
        }

        [TestMethod]
        public void LendingRandomBook()
        {
            int firstBookId = dataService.getCatalogBookList().Keys.ToList()[0].BookId;
            int firstUserId = dataService.getUserList().Keys.ToList()[0].userId;

            Book book1 = dataService.getCatalogBook(firstBookId);
            User user1 = dataService.getUser(firstUserId);

            dataService.addState(book1.BookId);
            dataService.lendBook(book1.BookId, user1.userId, new DateTime(2020, 10, 10));

            Assert.AreEqual(dataService.getStateList().ContainsValue(firstBookId), false);
            Assert.AreEqual(dataService.getStateList().Count, 0);
            Assert.AreEqual(dataService.getUserBookList(firstUserId).ContainsValue(firstBookId), true);
            Assert.AreEqual(dataService.getUserBookList(firstUserId).Count, 1);
            Assert.AreEqual(dataService.getEventList()[0].stateType, Data.StateType.lending);
            Assert.AreEqual(dataService.getEventList().Count, 1);
        }

        [TestMethod]
        public void ReturningRandomBook()
        {
            int firstBookId = dataService.getCatalogBookList().Keys.ToList()[0].BookId;
            int firstUserId = dataService.getUserList().Keys.ToList()[0].userId;

            Book book1 = dataService.getCatalogBook(firstBookId);
            User user1 = dataService.getUser(firstUserId);

            dataService.addState(book1.BookId);
            dataService.lendBook(book1.BookId, user1.userId, new DateTime(2020, 10, 10));

            Assert.AreEqual(dataService.getStateList().ContainsValue(firstBookId), false);
            Assert.AreEqual(dataService.getUserBookList(firstUserId).ContainsValue(firstBookId), true);
            Assert.AreEqual(dataService.getEventList()[0].stateType, Data.StateType.lending);
            Assert.AreEqual(dataService.getEventList()[0].User.userId, firstUserId);
            Assert.AreEqual(dataService.getEventList().Count, 1);

            dataService.returnBook(book1.BookId, user1.userId, new DateTime(2020, 11, 11));

            Assert.AreEqual(dataService.getStateList().ContainsValue(firstBookId), true);
            Assert.AreEqual(dataService.getUserBookList(firstUserId).ContainsValue(firstBookId), false);
            Assert.AreEqual(dataService.getEventList()[0].stateType, Data.StateType.lending);
            Assert.AreEqual(dataService.getEventList()[0].User.userId, firstUserId);
            Assert.AreEqual(dataService.getEventList()[0].penaltyPrice, 0);
            Assert.AreEqual(dataService.getEventList()[1].User.userId, firstUserId);
            Assert.AreEqual(dataService.getEventList()[1].stateType, Data.StateType.returning);
            Assert.AreEqual(dataService.getEventList()[1].penaltyPrice, 2);
            Assert.AreEqual(dataService.getEventList().Count, 2);
        }
    }
}
