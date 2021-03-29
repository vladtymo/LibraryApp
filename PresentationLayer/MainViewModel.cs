using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a property already matches the desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            // Log.DebugFormat("{0}.{1} = {2}", this.GetType().Name, propertyName, storage);
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AuthorViewModel : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private DateTime? birthDate;

        public int Id { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? BirthDate { get => birthDate; set => SetProperty(ref birthDate, value); }
    }
    public class BookViewModel : ViewModelBase
    {
        private string title;
        private int pages;
        private string genreName;
        private AuthorViewModel author;

        public int Id { get; set; }

        public string Title { get => title; set => SetProperty(ref title, value); }
        public int Pages { get => pages; set => SetProperty(ref pages, value); }
        public string GenreName { get => genreName; set => SetProperty(ref genreName, value); }

        public AuthorViewModel Author { get => author; set => SetProperty(ref author, value); }
    }
    
    public class MainViewModel : ViewModelBase
    {
        private IBookService bookService = new BookService();
        private IMapper mapper;

        private ICollection<BookViewModel> books = new ObservableCollection<BookViewModel>();
        private BookViewModel selectedBook;
        public MainViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<BookDTO, BookViewModel>();
                    cfg.CreateMap<AuthorDTO, AuthorViewModel>();

                    cfg.CreateMap<BookViewModel, BookDTO>();
                    cfg.CreateMap<AuthorViewModel, AuthorDTO>();
                });

            mapper = new Mapper(config);
        }

        public void LoadAllBooks()
        {
            var result = mapper.Map<IEnumerable<BookViewModel>>(bookService.GetAllBooks());

            books.Clear();
            foreach (var b in result)
            {
                books.Add(b);
            }
        }

        // Binding Properties
        public IEnumerable<BookViewModel> Books => books;
        public BookViewModel SelectedBook
        {
            get { return selectedBook; }
            set
            {
                //selectedBook = value;
                //OnPropertyChanged();
                SetProperty(ref selectedBook, value);
            }
        }
    }
}
