using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataContext context = new DataContext();
        [TestMethod]
        public void TestMethod1()
        {
            Books book1 = new Books("aaa", 123, "Jan Kowalski", BookType.Drama);
            Books book2 = new Books("bbb", 456, "Kamil Nowak", BookType.Children);
            context.Books.Add(book1);
            context.Books.Add(book2);
            State state1 = new State(context.Books);
            Books b1 = state1.States[0];
            Books b2 = state1.States[1];
            Assert.AreEqual(book1, b1);
            Assert.AreEqual(book2, b2);
            Assert.AreEqual(context.Books.Count, 2);
            context.Books.Remove(book1);
            State state2 = new State(context.Books);
            Books b3 = state2.States[0];
            Assert.AreEqual(book2, b3);
            Assert.AreEqual(context.Books.Count, 1);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Users user1 = new Users("Jan Kowalski", 111);
            Users user2 = new Users("Kamil Nowak", 222);
            context.Users.Add(user1);
            context.Users.Add(user2);
            Assert.AreEqual(context.Users[0], user1);
            Assert.AreEqual(context.Users[1], user2);
            Assert.AreEqual(context.Users.Count, 2);
        }
    }
}
