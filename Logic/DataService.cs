using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Logic
{
    public class DataService
    {
        private DataRepository repository = new DataRepository();

        public void addBook(string title, int book_id, string author_name, BookType genre)
        {
            repository.addBook(new Books(title, book_id, author_name, genre));
        }
        public void addAllBook(string title, int book_id, string author_name, BookType genre)
        {
            repository.addAllBook(new Books(title, book_id, author_name, genre));
        }
        public void addUser(string user_name, int user_id)
        {
            repository.addUser(new Users(user_name, user_id));
        }
        public void addState(List<Books> book_list)
        {
            repository.addState(new State(book_list));
        }
        public void addEvent(State state, Users users, Books books, StateType state_type, DateTime date)
        {
            repository.addEvent(new Event(state, users, books, state_type, date));
        }

        public void removeBook(string title, int book_id, string author_name, BookType genre)
        {
            repository.removeBook(new Books(title, book_id, author_name, genre));
        }
        public void removeAllBook(string title, int book_id, string author_name, BookType genre)
        {
            repository.removeAllBook(new Books(title, book_id, author_name, genre));
        }
        public void removeUser(string user_name, int user_id)
        {
            repository.removeUser(new Users(user_name, user_id));
        }
        public void removeState(List<Books> book_list)
        {
            repository.removeState(new State(book_list));
        }
        public void removeEvent(State state, Users users, Books books, StateType state_type, DateTime date)
        {
            repository.removeEvent(new Event(state, users, books, state_type, date));
        }

        public Books getBook(string title, int book_id, string author_name, BookType genre)
        {
            return repository.getBook(new Books(title, book_id, author_name, genre));
        }
        public Books getAllBook(string title, int book_id, string author_name, BookType genre)
        {
            return repository.getAllBook(new Books(title, book_id, author_name, genre));
        }
        public Users getUser(string user_name, int user_id)
        {
            return repository.getUser(new Users(user_name, user_id));
        }
        public State getState(List<Books> book_list)
        {
            return repository.getState(new State(book_list));
        }
        public Event getEvent(State state, Users users, Books books, StateType state_type, DateTime date)
        {
            return repository.getEvent(new Event(state, users, books, state_type, date));
        }

        public List<Books> getBookList()
        {
            return repository.getBookList();
        }
        public List<Books> getAllBookList()
        {
            return repository.getAllBookList();
        }
        public List<Users> getUserList()
        {
            return repository.getUserList();
        }
        public List<State> getStateList()
        {
            return repository.getStateList();
        }
        public List<Event> getEventList()
        {
            return repository.getEventList();
        }


        public bool checkUser(Users user)
        {
            user = new Users(user.userName, user.userId);
            return getUserList().Contains(user) ? true : false; 
        }
        public bool checkUserId(Users user, Books book)
        {
            user = new Users(user.userName, user.userId);
            book = new Books(book.Title, book.BookId, book.AuthorName, book.Genre);
            if(getAllBookList().Find(b => b == book).userId == user.userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void addUserToList(Users user)
        {
            if (!checkUser(user))
            {
                addUser(user.userName, user.userId);
            }
        }
        public bool checkBook(Books book)
        {
            return getBookList().Contains(new Books(book.Title, book.BookId, book.AuthorName, book.Genre)) ? true : false;
        }
        public bool checkTakenBook(Books book)
        {
            return getAllBookList().Contains(new Books(book.Title, book.BookId, book.AuthorName, book.Genre)) ? true : false;
        }
        public void addBookToList(Books book)
        {
            if (!checkBook(book) && !(checkTakenBook(book)))
            {
                addBook(book.Title, book.BookId, book.AuthorName, book.Genre);
                addAllBook(book.Title, book.BookId, book.AuthorName, book.Genre);
                addState(getBookList());
            }
        }
        public void takeBook(Books book, Users user, DateTime time)
        {
            State state = new State(getBookList());
            book = new Books(book.Title, book.BookId, book.AuthorName, book.Genre);
            user = new Users(user.userName, user.userId);
            if (checkBook(book))
            {
                getBookList().Find(b => b == book).userId = getUserList().Find(u => u == user).userId;
                removeBook(book.Title, book.BookId, book.AuthorName, book.Genre);
                addState(getBookList());
                addEvent(state, user, book, StateType.taking, time);
            }
        }
        public void returnBook(Books book, Users user, DateTime time)
        {
            State state = new State(getBookList());
            if (!checkBook(book) && checkTakenBook(book) && checkUserId(user, book))
            {
                book = new Books(book.Title, book.BookId, book.AuthorName, book.Genre);
                user = new Users(user.userName, user.userId);
                addBook(book.Title, book.BookId, book.AuthorName, book.Genre);
                addState(getBookList());
                Event e1 = getEventList().FindLast(x => (x.Book == book && x.usersOfLibrary == user));
                addEvent(state, user, book, StateType.returning, time);
                Event e2 = getEventList().FindLast(x => (x.Book == book && x.usersOfLibrary == user));
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
        
        public bool checkIfUserExists(Users user)
        {
            if(getUserList().Any(u => u.userId == user.userId))
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
            if (getBookList().Any(b => b.BookId == book.BookId))
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
