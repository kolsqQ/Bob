using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using WpfApp6.View.Pages;

namespace WpfApp6.View
{
    public class ViewManager
    {
        private static LibraryContext database;

        private static MenuBook menuBook;

        private static AuthorMenu menuAuthor;



        public static LibraryContext Database
        {
            get
            {
                if (database == null)
                {
                    database = new LibraryContext();
                }
                return database;
            }
        }

        public static MenuBook MenuBook
        {
            get
            {
                if (menuBook == null)
                {
                    menuBook = new MenuBook(Database);
                }
                return menuBook;
            }
        }

        public static AuthorMenu MenuAuthor
        {
            get
            {
                if (menuAuthor == null)
                {
                    menuAuthor = new AuthorMenu(Database);
                }
                return menuAuthor;
            }
        }


    }
}
