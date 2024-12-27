using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace WpfApp6.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuBook.xaml
    /// </summary>
    public partial class MenuBook : Page
    {
        private readonly LibraryContext database;
        public ObservableCollection<Book> Books { get; set; }

        public static MenuBook Instance { get; private set; }
        public LibraryContext Database { get { return database; } }


        public MenuBook(LibraryContext entities)
        {
            InitializeComponent();

            database = entities;
            DataContext = this;
            Instance = this;
            database.Books.Load();
            database.Authors.Load();
            Books = new ObservableCollection<Book>(database.Books.Local);

        }


        private void Remove(object sender, RoutedEventArgs e)
        {
            Book? book = BookList.SelectedItem as Book;
            if (book == null) return;
            Books.Remove(book);
            database.Books.Remove(book);
            database.SaveChanges();
        }



        private void AddBook(object sender, RoutedEventArgs e)
        {
            BookWindow bookWindow = new BookWindow(new Book());
            if (bookWindow.ShowDialog() == true) 
            {
                Book book = bookWindow.Book;
                if (!string.IsNullOrEmpty(book.Title) && book.Author != null)
                {
                    database.Books.Add(book);
                    Books.Add(book);
                    BookList.Items.Refresh();
                    database.SaveChanges();
                }
            }

            }



        private void Edit(object sender, RoutedEventArgs e)
        {
            if (BookList.SelectedItem != null)
            {
                var book = BookList.SelectedItem as Book;
                BookWindow bookWindow = new BookWindow(book);
                if (bookWindow.ShowDialog() == true)
                {
                    book = bookWindow.Book;
                    if (!string.IsNullOrEmpty(book.Title) && book.Author != null)
                    {
                        database.Books.Update(book);
                        Books[BookList.SelectedIndex] = book;
                        BookList.Items.Refresh();
                        database.SaveChanges();
                    }
                }
            }
        }

        private void Author(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.MenuAuthor);
        }
    }
    }

