using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System;

namespace LogicTests
{
    [TestClass]
    public class LogicTest
    {
        LogicGenerator generator = new LogicGenerator();

        [TestMethod]
        public void LendingBook()
        {
            DataService dataService = new DataService(new DataRepository(generator.Generate()));

            dataService.lendBook(2109, 1643, new DateTime(2020, 10, 10));

            Assert.AreEqual(dataService.getStateList().ContainsValue(2109), false);
            Assert.AreEqual(dataService.getUserBookList(1643).ContainsValue(2109), true);
            Assert.AreEqual(dataService.getEventList()[0].stateType, Data.StateType.lending);
            Assert.AreEqual(dataService.getEventList().Count, 1);
        }

        [TestMethod]
        public void ReturningBook()
        {
            DataService dataService = new DataService(new DataRepository(generator.Generate()));

            dataService.lendBook(2109, 1643, new DateTime(2020, 10, 10));

            Assert.AreEqual(dataService.getStateList().ContainsValue(2109), false);
            Assert.AreEqual(dataService.getUserBookList(1643).ContainsValue(2109), true);
            Assert.AreEqual(dataService.getEventList().Count, 1);
            Assert.AreEqual(dataService.getEventList()[0].User.userId, 1643);
            Assert.AreEqual(dataService.getEventList()[0].stateType, Data.StateType.lending);

            dataService.returnBook(2109, 1643, new DateTime(2020, 11, 11));
            
            Assert.AreEqual(dataService.getStateList().ContainsValue(2109), true);
            Assert.AreEqual(dataService.getUserBookList(1643).ContainsValue(2109), false);
            Assert.AreEqual(dataService.getEventList().Count, 2);
            Assert.AreEqual(dataService.getEventList()[1].User.userId, 1643);
            Assert.AreEqual(dataService.getEventList()[1].stateType, Data.StateType.returning);
            Assert.AreEqual(dataService.getEventList()[1].penaltyPrice, 2);
        }
    }
}
