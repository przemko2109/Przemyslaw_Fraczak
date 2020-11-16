﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext : DataRepository
    {
        public List<Books> Books;
        public List<Books> AllBooks;
        public List<Users> Users;
        public List<State> State;
        public List<Event> Event;
        public DataContext()
        {
            this.Books = new List<Books>();
            this.AllBooks = new List<Books>();
            this.Users = new List<Users>();
            this.State = new List<State>();
            this.Event = new List<Event>();
        }
        public List<Books> getBooks()
        {
            return Books;
        }
        public List<Books> getAllBooks()
        {
            return AllBooks;
        }
        public List<Users> getUsers()
        {
            return Users;
        }
        public List<State> getState()
        {
            return State;
        }
        public List<Event> getEvent()
        {
            return Event;
        }
    }
}
