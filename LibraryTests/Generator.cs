using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Tests
{
    public class Generator : IGenerator
    {
        public DataContext Generate()
        {
            DataContext context = new DataContext();

            Book book1 = new Book("Wiedźmin", 2109, "Andrzej Sapkowski", BookType.Fantasy);
            context.bookCatalog().Add(book1, book1.BookId);

            User user1 = new User("Jan Kowalski", 1643);
            context.Users().Add(user1, user1.userId);

            Book book2 = new Book("Gra o tron", 3561, "George R.R. Martin", BookType.Fantasy);
            context.bookCatalog().Add(book2, book2.BookId);

            User user2 = new User("Kamil Nowak", 6542);
            context.Users().Add(user2, user2.userId);

            return context;
        }
        public int RandomNumber(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            Random r = new Random();
            var builder = new StringBuilder(size); 
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)r.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public BookType RandomBookType()
        {
            Random r = new Random();
            Array values = Enum.GetValues(typeof(BookType));
            BookType bookType = (BookType)values.GetValue(r.Next(values.Length));
            return bookType;
        }
        public DataContext RandomGenerate()
        {
            DataContext context = new DataContext();

            Book book1 = new Book(RandomString(RandomNumber(5, 50), true), RandomNumber(1000, 9999), 
                RandomString(RandomNumber(5, 25), true), RandomBookType());
            context.bookCatalog().Add(book1, book1.BookId);

            User user1 = new User(RandomString(RandomNumber(5, 25), true), RandomNumber(1000, 9999));
            context.Users().Add(user1, user1.userId);

            Book book2 = new Book(RandomString(RandomNumber(5, 50), true), RandomNumber(1000, 9999),
                RandomString(RandomNumber(5, 25), true), RandomBookType());
            context.bookCatalog().Add(book2, book2.BookId);

            User user2 = new User(RandomString(RandomNumber(5, 25), true), RandomNumber(1000, 9999));
            context.Users().Add(user2, user2.userId);

            return context;
        }
    }
}
