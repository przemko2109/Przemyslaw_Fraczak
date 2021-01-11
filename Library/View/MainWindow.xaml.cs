using Library.View;
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

namespace Library
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = _vm;

            _vm.UserBooksPageWindow = new Lazy<IWindow>(() => new UserBooksPage());
            _vm.ShowCatalogPageWindow = new Lazy<IWindow>(() => new ShowCatalogPage());
            _vm.ShowUsersPageWindow = new Lazy<IWindow>(() => new ShowUsersPage());
        }
    }
}
