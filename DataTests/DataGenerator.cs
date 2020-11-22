using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace DataTests
{
    public class DataGenerator : IGenerator
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

            Event event1 = new Event(book1, user1, StateType.lending, new System.DateTime(2020, 10, 10));
            context.Events().Add(event1);

            Event event2 = new Event(book1, user1, StateType.returning, new System.DateTime(2020, 10, 10));
            context.Events().Add(event2);

            return context;
        }
    }
}
