using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using App7;
using App7.DB;
using App7.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace App5.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Book> Books{ get; set; }

        public BookViewModel()
        {
            const string DBFILENAME = "BooksDb";
           // string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);

            using (var db = new ApplicationContext(DBFILENAME))
            {

                Books = new ObservableCollection<Book>();
                Books.Add(new Book { Name = "CLR via C#", Author = "Jeffrey Richter", Price = 2000.0 });
                Books.Add(new Book { Name = "ASP.NET CORE MVC", Author = "Adam Freeman", Price = 2500.0 });
                Books.Add(new Book { Name = "Computer Networks", Author = "Andrew Tanenbaum", Price = 1500.0 });
            }
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }

            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        private Command buyBook;
        public Command BuyBook
        {
            get
            {
                return buyBook ??
                    (buyBook = new Command(async obj =>
                    {
                        Book book = obj as Book;

                        if(book != null)
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Покупка книги", "Вы уверены, что хотите купить эту книгу?", "Да", "Нет");
                            
                            if(res)
                            {
                                string message = String.Format("Вы успешно приобрели {0} {1} за {2}", book.Author, book.Name, book.Price);
                                await App.Current.MainPage.DisplayAlert("Покупка книги", message, "Ок");
                            }
                        }
                    }));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
