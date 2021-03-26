using AutoMapper;
using BusinessLogicLayer;
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
            CreateBookWindow window = new CreateBookWindow();
            if (window.ShowDialog().Value)
            {
                MessageBox.Show($"{window.Book.Title} {window.Book.Author.FirstName}");
            }
        }
        public void GetBooks()
        {
            var result = mapper.Map<IEnumerable<BookViewModel>>(service.GetAllBooks());
            books = new ObservableCollection<BookViewModel>(result);
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
