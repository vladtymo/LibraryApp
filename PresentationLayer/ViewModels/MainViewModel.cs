using AutoMapper;
using PresentationLayer.Commands;
//using BusinessLogicLayer;
using PresentationLayer.WcfService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    public class MainViewModel : ViewModelBase, IBookServiceCallback
    {
        private IBookService service;
        private IMapper mapper;

        private ICollection<BookViewModel> books;
        private BookViewModel selectedBook;

        private Command getBooksCommand;
        private Command createBookCommand;

        public MainViewModel()
        {
            // BLL (.dll)
            //service = new BookService();

            // WCF
            service = new BookServiceClient(new InstanceContext(this));

            service.Login();

            books = new ObservableCollection<BookViewModel>();

            IConfigurationProvider config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BookDTO, BookViewModel>();
                    cfg.CreateMap<AuthorDTO, AuthorViewModel>();
                    cfg.CreateMap<GenreDTO, GenreViewModel>();
                    //-------------------------------------
                    cfg.CreateMap<BookViewModel, BookDTO>();
                    cfg.CreateMap<AuthorViewModel, AuthorDTO>();
                    cfg.CreateMap<GenreViewModel, GenreDTO>();

                });
            mapper = new Mapper(config);

            /////////////// Create Commands
            getBooksCommand = new DelegateCommand(o => GetBooks());
            createBookCommand = new DelegateCommand(o => CreateNewBook());
        }
        ~MainViewModel()
        {
            service.Logout();
        }
        public void TakeBook(BookDTO book)
        {
            books.Add(mapper.Map<BookViewModel>(book));
        }

        public void CreateNewBook()
        {
            NewBookViewModel newBook = new NewBookViewModel(service, mapper);
            CreateBookWindow window = new CreateBookWindow(newBook);
            window.ShowDialog();
            if (newBook.IsOK)
            {
                service.CreateNewBook(mapper.Map<BookDTO>(newBook.Book));
            }
        }
        public void GetBooks()
        {
            var result = mapper.Map<IEnumerable<BookViewModel>>(service.GetAllBooks());
            books.Clear();
            foreach (var item in result)
            {
                books.Add(item);
            }
        }

        public IEnumerable<BookViewModel> Books => books;
        public BookViewModel SelectedBook
        {
            get { return selectedBook; }
            set { SetProperty(ref selectedBook, value); }
        }

        public ICommand GetBooksCommand => getBooksCommand;
        public ICommand CreateBookCommand => createBookCommand;
    }
}
