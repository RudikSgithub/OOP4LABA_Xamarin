using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App5.DB;
using App5.Models;
using App5.ViewModels;

namespace App5
{
    public partial class App : Application
    {
        public const string dbFileName = "booksApp.db";
        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(dbFileName);

            using(var db = new ApplicationContext(dbPath))
            {
                db.Database.EnsureCreated();
                if(db.Books.Count() == 0)
                {
                    db.Books.Add(new Book());
                    db.Books.Add(new Book());
                    db.Books.Add(new Book());

                    db.SaveChanges();
                }
            }
         //   DependencyService.Register<MockDataStore>();
              MainPage = new App5.Views.Main();
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
