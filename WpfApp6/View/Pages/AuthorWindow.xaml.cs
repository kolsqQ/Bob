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
using WpfApp6.Model;

namespace WpfApp6.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public Author Authors { get; private set; }
        public AuthorWindow(Author author)
        {
            InitializeComponent();
            InitializeComponent();
            Authors = author;
            DataContext = Authors;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}




