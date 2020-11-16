using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataRepository : IDataRepository
    {
        private DataContext context = new DataContext();
        public void addBook(Books book)
        {
            context.Books.Add(book);
        }
        public void addAllBook(Books book)
        {
            context.AllBooks.Add(book);
        }
        public void addUser(Users user)
        {
            context.Users.Add(user);
        }
        public void addState(State state)
        {
            context.State.Add(state);
        }
        public void addEvent(Event events)
        {
            context.Event.Add(events);
        }

        public void removeBook(Books book)
        {
            context.Books.Remove(book);
        }
        public void removeAllBook(Books book)
        {
            context.AllBooks.Remove(book);
        }
        public void removeUser(Users user)
        {
            context.Users.Remove(user);
        }
        public void removeState(State state)
        {
            context.State.Remove(state);
        }
        public void removeEvent(Event events)
        {
            context.Event.Remove(events);
        }

        public Books getBook(Books book)
        {
            return context.Books.Find(b => b == book);
        }
        public Books getAllBook(Books book)
        {
            return context.AllBooks.Find(b => b == book);
        }
        public Users getUser(Users user)
        {
            return context.Users.Find(b => b == user);
        }
        public State getState(State state)
        {
            return context.State.Find(s => s == state);
        }
        public Event getEvent(Event events)
        {
            return context.Event.Find(e => e == events);
        }

        public List<Books> getBookList()
        {
            return context.Books;
        }
        public List<Books> getAllBookList()
        {
            return context.AllBooks;
        }
        public List<Users> getUserList()
        {
            return context.Users;
        }
        public List<State> getStateList()
        {
            return context.State;
        }
        public List<Event> getEventList()
        {
            return context.Event;
        }
    }
}
