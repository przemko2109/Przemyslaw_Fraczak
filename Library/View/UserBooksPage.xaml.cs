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
    public partial class UserBooksPage : Window, IWindow
    {
        private readonly MainViewModel _vm = new MainViewModel();
        public UserBooksPage()
        {
            InitializeComponent();
            Refresh();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = _vm;

            _vm.BorrowBookPageWindow = new Lazy<IWindow>(() => new BorrowBookPage());
            _vm.ReturnBookPageWindow = new Lazy<IWindow>(() => new ReturnBookPage());
        }
        public void Refresh()
        {
            user_books.ItemsSource = _vm.GetUserBooks();
            DataContext = _vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
