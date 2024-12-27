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

namespace WpfApp6.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorMenu.xaml
    /// </summary>
    public partial class AuthorMenu : Page
    {
        private readonly LibraryContext database;
        public ObservableCollection<Author> Authors { get; set; }


        public AuthorMenu(LibraryContext entities)
        {
            InitializeComponent();
            database = entities;
            DataContext = this;

            database.Authors.Load();
            database.Authors.Load();

            Authors = new ObservableCollection<Author>(database.Authors.Local);
        }

        private void AddAuthor(object sender, RoutedEventArgs e)
        {
            AuthorWindow authorWindow = new AuthorWindow(new Author());
            if (authorWindow.ShowDialog() == true)
            {
                var author = authorWindow.Authors;
                if (!string.IsNullOrEmpty(author.Name))
                {
                    database.Authors.Add(author);
                    Authors.Add(author);
                    AuthorList.Items.Refresh();
                    database.SaveChanges();
                }
            }
        }

        private void UpdateAuthor(object sender, RoutedEventArgs e)
        {
            if (AuthorList.SelectedItem != null)
            {
                var author = AuthorList.SelectedItem as Author;
                AuthorWindow authorWindow = new AuthorWindow(author);
                if (authorWindow.ShowDialog() == true)
                {
                    author = authorWindow.Authors;
                    if (!string.IsNullOrEmpty(author.Name))
                    {
                        database.Authors.Update(author);
                        Authors[AuthorList.SelectedIndex] = author;
                        AuthorList.Items.Refresh();
                        database.SaveChanges();
                    }
                }
            }
        }

        private void DeleteAuthor(object sender, RoutedEventArgs e)
        {
            var author = AuthorList.SelectedItem as Author;
            if (author != null)
            {
                database.Authors.Remove(author);
                Authors.Remove(author);
                AuthorList.Items.Refresh();
                database.SaveChanges();
            }


        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
