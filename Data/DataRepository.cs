using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface DataRepository
    {
        List<Books> getBooks();
        List<Books> getAllBooks();
        List<Users> getUsers();
        List<State> getState();
        List<Event> getEvent();
    }
}
