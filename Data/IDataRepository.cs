using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataRepository
    {
        void addCatalogBook(Book book);
        void addUserBook(Book book, User user);
        void addState(Book book);
        void addUser(User user);
        void addEvent(Event events);
        void removeUserBook(Book book, User user);
        void removeState(Book book);
        Book getCatalogBook(int id);
        Book getUserBook(int book_id, int user_id);
        Book getState(int id);
        User getUser(int id);
        Dictionary<Book, int> getCatalogBookList();
        Dictionary<Book, int> getUserBookList(int id);
        Dictionary<Book, int> getStateList();
        Dictionary<User, int> getUserList();
        List<Event> getEventList();
    }
}
