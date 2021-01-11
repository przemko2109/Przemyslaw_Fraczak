﻿using Presentation.ViewModel;
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
    /// Logika interakcji dla klasy RemoveBookPage.xaml
    /// </summary>
    public partial class RemoveBookPage : Window, IWindow
    {
        public RemoveBookPage()
        {
            InitializeComponent();
            MainViewModel _vm = new MainViewModel();
            books.ItemsSource = _vm.GetCatalogBooks();
            DataContext = _vm;
        }
    }
}
