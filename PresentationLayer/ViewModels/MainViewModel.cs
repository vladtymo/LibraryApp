using AutoMapper;
using BusinessLoginLayer;
using PresentationLayer.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    public class MainViewModel : ViewModelBase
    {
        private IBookService service;
        private ICollection<BookViewModel> books;
        private IMapper mapper;
        private BookViewModel selectedBook;

        private Command getBooksCommand;
        private Command createBookCommand;

        public MainViewModel()
        {
            service = new BookService();
            books = new ObservableCollection<BookViewModel>();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<BookDTO, BookViewModel>()
                        .ForMember(dst => dst.AuthorName, opt => opt.MapFrom(src => src.Author.FirstName))
                        .ForMember(dst => dst.AuthorSurname, opt => opt.MapFrom(src => src.Author.LastName))
                        .ForMember(dst => dst.AuthorBirthDate, opt => opt.MapFrom(src => src.Author.BirthDate));
                });
            mapper = new Mapper(config);

            /////////////// Create Commands
            getBooksCommand = new DelegateCommand(GetBooks);
            createBookCommand = new DelegateCommand(CreateNewBook);
        }


        public void CreateNewBook()
        {
            CreateBookWindow window = new CreateBookWindow(service);
            if (window.ShowDialog() == true)
            {
                service.CreateNewBook(window.Book);
            }
        }
        public void GetBooks()
        {
            var result = mapper.Map<IEnumerable<BookViewModel>>(service.GetAllBooks());
            books.Clear();

            foreach (var b in result)
            {
                books.Add(b);
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
