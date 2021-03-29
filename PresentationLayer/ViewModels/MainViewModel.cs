using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using BusinessLogicLayer;
using PresentationLayer.Commands;

namespace PresentationLayer
{
    public class MainViewModel : ViewModelBase
    {
        private IBookService bookService = new BookService();
        private IMapper mapper;

        private Command loadBooksCmd;

        private ICollection<BookViewModel> books = new ObservableCollection<BookViewModel>();
        private BookViewModel selectedBook;

        public MainViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BookDTO, BookViewModel>();
                    cfg.CreateMap<AuthorDTO, AuthorViewModel>();

                    cfg.CreateMap<BookViewModel, BookDTO>();
                    cfg.CreateMap<AuthorViewModel, AuthorDTO>();
                });
            mapper = new Mapper(config);

            loadBooksCmd = new DelegateCommand(LoadAllBooks);
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
            set { SetProperty(ref selectedBook, value); }
        }

        public ICommand LoadBooksCmd => loadBooksCmd;
    }
}
