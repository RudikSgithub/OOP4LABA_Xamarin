using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App7.Views;
using App7.DB;
using System.Linq;
using App7.Models;

namespace App7
{
    public partial class App : Application
    {
        public const string DBFILENAME = "Booksapp.db";

        public App()
        {
            InitializeComponent();

            //   string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
          /*  string dbPath = "BooksDb";
            using (var db = new ApplicationContext(dbPath))
            {
                db.Database.EnsureCreated();  // Создаем бд, если она отсутствует
                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book { Name = "CLR via C#", Author = "Jeffrey Richter", Price = 2000.0 });
                    db.Books.Add(new Book { Name = "ASP.NET CORE MVC", Author = "Adam Freeman", Price = 2500.0 });
                    db.Books.Add(new Book { Name = "Computer Networks", Author = "Andrew Tanenbaum", Price = 1500.0 });
                    
                    db.SaveChanges();
                }
            }*/

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
