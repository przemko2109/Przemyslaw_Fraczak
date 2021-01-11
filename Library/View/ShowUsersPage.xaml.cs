using Presentation.ViewModel;
using System;
using System.Windows;

namespace Library.View
{
    public partial class ShowUsersPage : Window, IWindow
    {
        private readonly MainViewModel _vm = new MainViewModel();
        public ShowUsersPage()
        {
            InitializeComponent();
            Refresh();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = _vm;

            _vm.AddUserPageWindow = new Lazy<IWindow>(() => new AddUserPage());
            _vm.RemoveUserPageWindow = new Lazy<IWindow>(() => new RemoveUserPage());
        }

        public void Refresh()
        {
            users.ItemsSource = _vm.GetUsers();
            DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
