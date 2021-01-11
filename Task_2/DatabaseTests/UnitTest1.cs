using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;

namespace DatabaseTest
{
    [TestClass]
    public class UnitTest1
    {
        static private string GetConnectionString()
        {
            return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\\Database.mdf; Integrated Security = True";
        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            DatabaseDataContext db = new DatabaseDataContext();

            Catalog book = new Catalog();
            book.id = 100;
            book.author_name = "Przemysław Frączak";
            book.title = "My Book";
            book.genre = "Western";

            db.Catalog.InsertOnSubmit(book);
            db.SubmitChanges();

            Catalog book1 = db.Catalog.FirstOrDefault(b => b.id.Equals(100));
            Assert.AreEqual(book1.id, 100);
            Assert.AreEqual(book1.author_name, "Przemysław Frączak");
            Assert.AreEqual(book1.title, "My Book");

            db.Catalog.DeleteOnSubmit(book);
            db.SubmitChanges();
        }

        [TestMethod]
        public void TestMethod2()
        {
            DatabaseDataContext db = new DatabaseDataContext();

            Users user = db.Users.FirstOrDefault(c => c.user_id.Equals(1));
            Assert.AreEqual(user.user_id, 1);
            Assert.AreEqual(user.user_name, "Peter");

        }
    }
}