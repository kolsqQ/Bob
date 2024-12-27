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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class BookWindow : Window
    {

        public Book Book { get; private set; }

        public BookWindow(Book book)
        {
            InitializeComponent();
            Book = book;
            DataContext = Book;
            AuthorList.SetBinding(ComboBox.ItemsSourceProperty, new Binding()
            {
                Source = MenuBook.Instance.Database.Authors.ToList()
            });
            if (book.Author != null)
            {
                AuthorList.SelectedIndex = book.Author.Id - 1;
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (Book.Author != null)
            {
                Book.Author = AuthorList.SelectedItem as Author;
                Book.AuthorId = Book.Author.Id;
            }
            DialogResult = true;
        }

        private void AuthorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

