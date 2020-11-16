using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    interface IDataRepository
    {
        void addBook(Books book);
        void addAllBook(Books book);
        void addUser(Users user);
        void addState(State state);
        void addEvent(Event events);
        void removeBook(Books book);
        void removeAllBook(Books book);
        void removeUser(Users user);
        void removeState(State state);
        void removeEvent(Event events);
        Books getBook(Books book);
        Books getAllBook(Books book);
        Users getUser(Users user);
        State getState(State state);
        Event getEvent(Event events);
        List<Books> getBookList();
        List<Books> getAllBookList();
        List<Users> getUserList();
        List<State> getStateList();
        List<Event> getEventList();
    }
}
