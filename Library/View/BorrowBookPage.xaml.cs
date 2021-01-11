using Library.ViewModel;
using Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.View
{
    /// <summary>
    /// Logika interakcji dla klasy BorrowBookPage.xaml
    /// </summary>
    public partial class BorrowBookPage : Window, IWindow
    {

        public BorrowBookPage()
        {
            InitializeComponent();
            BorrowingBookViewModel _vm = new BorrowingBookViewModel();
            users.ItemsSource = _vm.GetUsers();
            books.ItemsSource = _vm.GetBooks();
            DataContext = _vm;
        }
    }
}
