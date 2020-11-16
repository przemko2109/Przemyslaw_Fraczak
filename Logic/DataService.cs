using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Logic
{
    public class DataService
    {
        private DataRepository repository = new DataContext();
        public bool checkUser(Users user)
        {
            return repository.getUsers().Contains(user) ? true : false; 
        }
        public bool checkUserId(Books book, Users user)
        {
            if(repository.getAllBooks().Find(b => b == book).userId == user.userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void addUser(Users user)
        {
            if (!checkUser(user))
            {
                repository.getUsers().Add(user);
            }
        }
        public bool checkBook(Books book)
        {
            return repository.getBooks().Contains(book) ? true : false;
        }
        public bool checkTakenBook(Books book)
        {
            return repository.getAllBooks().Contains(book) ? true : false;
        }
        public void addBook(Books book)
        {
            State state = new State(repository.getBooks());
            if (!checkBook(book) && !(checkTakenBook(book)))
            {
                repository.getBooks().Add(book);
                repository.getAllBooks().Add(book);
                repository.getState().Add(state);
            }
        }
        public void takeBook(Books book, Users user, DateTime time)
        {
            State state = new State(repository.getBooks());
            if (checkBook(book))
            {
                repository.getAllBooks().Find(b => b == book).userId = repository.getUsers().Find(u => u == user).userId;
                repository.getBooks().Remove(book);
                repository.getState().Add(state);
                repository.getEvent().Add(new Event(state, user, book, StateType.taking, time));
            }
        }
        public void returnBook(Books book, Users user, DateTime time)
        {
            State state = new State(repository.getBooks());
            if (!checkBook(book) && checkTakenBook(book) && checkUserId(book, user))
            {
                repository.getBooks().Add(book);
                repository.getState().Add(state);
                Event e1 = repository.getEvent().FindLast(x => (x.Book == book && x.usersOfLibrary == user));
                repository.getEvent().Add(new Event(state, user, book, StateType.returning, time));
                Event e2 = repository.getEvent().FindLast(x => (x.Book == book && x.usersOfLibrary == user));
                if (e1 != null)
                {
                    double period = (e2.Day - e1.Day).TotalDays;
                    if (period > 30)
                    {
                        for (double i = 0; i < (period - 30); i++)
                        {
                            e2.penaltyPrice += 1;
                        }
                    }
                }
            }
            
        }
        public List<Books> getBooks()
        {
            return repository.getBooks();
        }
        public List<Books> getAllBooks()
        {
            return repository.getAllBooks();
        }
        public List<Users> getUsers()
        {
            return repository.getUsers();
        }
        public State getState()
        {
            int c = repository.getState().Count;
            return repository.getState()[c - 1];
        }
        public List<Event> getEvent()
        {
            return repository.getEvent();
        }
        public bool checkIfUserExists(Users user)
        {
            if(repository.getUsers().Any(u => u.userId == user.userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkIfBookExists(Books book)
        {
            if (repository.getBooks().Any(b => b.BookId == book.BookId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
