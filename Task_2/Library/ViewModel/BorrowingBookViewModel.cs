using Presentation.Models;
using Prism.Commands;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class BorrowingBookViewModel
    {
        private User _tus;
        public User TheUser
        {
            get { return _tus; }
            set
            {
                _tus = value;
                OnPropertyChange("TheUser");
            }
        }

        List<User> users;
        public List<User> GetUsers()
        {
            users = new List<User>();
            for (int i = 1; i <= DataService.userAmount(); i++)
            {
                User u = new User(i);
                users.Add(u);
            }
            return users;
        }

        private Catalog _tb;
        public Catalog TheBook
        {
            get { return _tb; }
            set
            {
                _tb = value;
                OnPropertyChange("TheBook");
            }
        }

        List<Catalog> books;
        public List<Catalog> GetBooks()
        {
            books = new List<Catalog>();
            for (int i = 1; i <= DataService.catalogBooksAmount(); i++)
            {
                Catalog b = new Catalog(i);
                books.Add(b);
            }
            return books;
        }

        public BorrowingBookViewModel()
        {
            BorrowBookCommand = new DelegateCommand(BorrowBook);
        }
        public ICommand BorrowBookCommand
        {
            get;
            private set;
        }

        private void BorrowBook()
        {
            int _id = DataService.getLastUserBookId() + 1;
            DataService.borrowBook(_id, TheUser.UserId, TheBook.BookId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
