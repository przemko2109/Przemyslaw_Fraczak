using Presentation.Models;
using Prism.Commands;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Catalog

        private Catalog book;
        private ObservableCollection<Catalog> books;
        public Catalog b
        {
            get { return book; }
            set
            {
                if (book != value)
                {
                    book = value;
                    OnPropertyChange("b");
                }
            }
        }
        public int BookId
        {
            get { return book.BookId; }
            set
            {
                if (book.BookId != value)
                {
                    book.BookId = value;
                    OnPropertyChange("BookId");
                }
            }
        }
        public string Title
        {
            get { return book.Title; }
            set
            {
                if (book.Title != value)
                {
                    book.Title = value;
                    DataService.updateTitle(value, book.BookId);
                    OnPropertyChange("Title");
                }
            }
        }
        public string AuthorName
        {
            get { return book.AuthorName; }
            set
            {
                if (book.AuthorName != value)
                {
                    book.AuthorName = value;
                    DataService.updateAuthorName(value, book.BookId);
                    OnPropertyChange("Author");
                }
            }
        }
        public string Genre
        {
            get { return book.Genre; }
            set
            {
                if (book.Genre != value)
                {
                    book.Genre = value;
                    DataService.updateGenre(value, book.BookId);
                    OnPropertyChange("Genre");
                }
            }
        }
        public ObservableCollection<Catalog> Books
        {
            get { return GetCatalogBooks(); }
            set
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i] != value[i])
                    {
                        Books[i] = value[i];
                        OnPropertyChange("Books");
                    }
                }

            }
        }

        //User

        private User user;
        private ObservableCollection<User> users;
        public User u
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChange("u");
                }
            }
        }
        public int UserId
        {
            get { return user.UserId; }
            set
            {
                if (user.UserId != value)
                {
                    user.UserId = value;
                    OnPropertyChange("UserId");
                }
            }
        }
        public string Name
        {
            get { return user.Name; }
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    DataService.updateName(value, user.UserId);
                    OnPropertyChange("Name");
                }
            }
        }
        public ObservableCollection<User> Users
        {
            get { return GetUsers(); }
            set
            {
                for (int i = 0; i < Users.Count; i++)
                {
                    if (Users[i] != value[i])
                    {
                        Users[i] = value[i];
                        OnPropertyChange("Users");
                    }
                }
            }
        }

        //User books

        private UserBook user_book;
        private ObservableCollection<UserBook> user_books;
        public UserBook ub
        {
            get { return user_book; }
            set
            {
                if (user_book != value)
                {
                    user_book = value;
                    OnPropertyChange("ub");
                }
            }
        }
        public int UserBookId
        {
            get { return user_book.UserBookId; }
            set
            {
                if (user_book.UserBookId != value)
                {
                    user_book.UserBookId = value;
                    OnPropertyChange("UserBookId");
                }
            }
        }
        public int UserBookUserId
        {
            get { return user_book.UserBookUserId; }
            set
            {
                if (user_book.UserBookUserId != value)
                {
                    user_book.UserBookUserId = value;
                    OnPropertyChange("UserBookUserId");
                }
            }
        }
        public int UserBookBookId
        {
            get { return user_book.UserBookBookId; }
            set
            {
                if (user_book.UserBookBookId != value)
                {
                    user_book.UserBookBookId = value;
                    OnPropertyChange("UserBookBookId");
                }
            }
        }
        public ObservableCollection<UserBook> UserBooks
        {
            get { return GetUserBooks(); }
            set
            {
                for (int i = 0; i < Users.Count; i++)
                {
                    if (UserBooks[i] != value[i])
                    {
                        UserBooks[i] = value[i];
                        OnPropertyChange("UserBooks");
                    }
                }

            }
        }

        //Lists

        public ObservableCollection<User> GetUsers()
        {
            users = new ObservableCollection<User>();
            for (int i = 1; i <= DataService.getLastUserId(); i++)
            {
                User u = new User(i);
                users.Add(u);
            }
            return users;
        }
        public ObservableCollection<Catalog> GetCatalogBooks()
        {
            books = new ObservableCollection<Catalog>();
            for (int i = 1; i <= DataService.getLastCatalogBookId(); i++)
            {
                Catalog b = new Catalog(i);
                books.Add(b);   
            }
            return books;
        }
        public ObservableCollection<UserBook> GetUserBooks()
        {
            user_books = new ObservableCollection<UserBook>();
            for (int i = 1; i <= DataService.getLastUserBookId(); i++)
            {
                UserBook ub = new UserBook(i);
                if (ub.UserBookUserId != -1) user_books.Add(ub);
            }
            return user_books;
        }
        public MainViewModel()
        {
            AddBookPageCommand = new DelegateCommand(AddBookPage);
            RemoveBookPageCommand = new DelegateCommand(RemoveBookPage);
            ShowCatalogPageCommand = new DelegateCommand(ShowCatalogPage);
            AddUserPageCommand = new DelegateCommand(AddUserPage);
            RemoveUserPageCommand = new DelegateCommand(RemoveUserPage);
            ShowUsersPageCommand = new DelegateCommand(ShowUsersPage);
            UserBooksPageCommand = new DelegateCommand(UserBooksPage);
            BorrowBookPageCommand = new DelegateCommand(BorrowBookPage);
            ReturnBookPageCommand = new DelegateCommand(ReturnBookPage);
            AddUserButtonCommand = new DelegateCommand(AddUserButton);
            AddCatalogBookButtonCommand = new DelegateCommand(AddCatalogBookButton);
            RemoveUserButtonCommand = new DelegateCommand(RemoveUserButton);
            RemoveCatalogBookButtonCommand = new DelegateCommand(RemoveCatalogBookButton);

            int _id = DataService.getLastUserId() + 1;
            user = new User(_id, "default");

            int _id2 = DataService.getLastCatalogBookId() + 1;
            book = new Catalog(_id2, "default", "default", "default");
        }

        public Lazy<IWindow> AddBookPageWindow { get; set; }
        public ICommand AddBookPageCommand
        {
            get;
            private set;
        }
        private void AddBookPage()
        {
            IWindow _child = AddBookPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> RemoveBookPageWindow { get; set; }
        public ICommand RemoveBookPageCommand
        {
            get;
            private set;
        }
        private void RemoveBookPage()
        {
            IWindow _child = RemoveBookPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> RemoveUserPageWindow { get; set; }
        public ICommand RemoveUserPageCommand
        {
            get;
            private set;
        }
        private void RemoveUserPage()
        {
            IWindow _child = RemoveUserPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> ShowCatalogPageWindow { get; set; }
        public ICommand ShowCatalogPageCommand
        {
            get;
            private set;
        }
        private void ShowCatalogPage()
        {
            IWindow _child = ShowCatalogPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> AddUserPageWindow { get; set; }
        public ICommand AddUserPageCommand
        {
            get;
            private set;
        }
        private void AddUserPage()
        {
            IWindow _child = AddUserPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> ShowUsersPageWindow { get; set; }
        public ICommand ShowUsersPageCommand
        {
            get;
            private set;
        }
        private void ShowUsersPage()
        {
            IWindow _child = ShowUsersPageWindow.Value;  
            _child.Show();
        }

        public Lazy<IWindow> UserBooksPageWindow { get; set; }
        public ICommand UserBooksPageCommand
        {
            get;
            private set;
        }
        private void UserBooksPage()
        {
            IWindow _child = UserBooksPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> BorrowBookPageWindow { get; set; }
        public ICommand BorrowBookPageCommand
        {
            get;
            private set;
        }
        private void BorrowBookPage()
        {
            IWindow _child = BorrowBookPageWindow.Value;
            _child.Show();
        }

        public Lazy<IWindow> ReturnBookPageWindow { get; set; }
        public ICommand ReturnBookPageCommand
        {
            get;
            private set;
        }
        private void ReturnBookPage()
        {
            IWindow _child = ReturnBookPageWindow.Value;
            _child.Show();
        }

        //====================================================================================

        public ICommand AddCatalogBookButtonCommand
        {
            get;
            private set;
        }
        private void AddCatalogBookButton()
        {
            int _id = DataService.getLastCatalogBookId() + 1;
            DataService.addCatalogBook(this.Title, _id, this.AuthorName, this.Genre);
        }

        public ICommand AddUserButtonCommand
        {
            get;
            private set;
        }
        private void AddUserButton()
        {
            int _id = DataService.getLastUserId() + 1;
            DataService.addUser(this.Name, _id);
        }

        public ICommand RemoveCatalogBookButtonCommand
        {
            get;
            private set;
        }
        private void RemoveCatalogBookButton()
        {
            DataService.removeCatalogBook(this.UserId);
        }

        public ICommand RemoveUserButtonCommand
        {
            get;
            private set;
        }
        private void RemoveUserButton()
        {
            DataService.removeUser(this.UserId);
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
