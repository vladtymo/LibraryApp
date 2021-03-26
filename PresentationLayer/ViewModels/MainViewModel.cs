using AutoMapper;
using BusinessLogicLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLayer
{
    public class MainViewModel : ViewModelBase
    {
        private IBookService service;
        private ICollection<BookViewModel> books;
        private IMapper mapper;
        private BookViewModel selectedBook;

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

            books = new ObservableCollection<BookViewModel>(mapper.Map<IEnumerable<BookViewModel>>(service.GetAllBooks()));
        }

        public IEnumerable<BookViewModel> Books => books;
        public BookViewModel SelectedBook
        {
            get { return selectedBook; }
            set { SetProperty(ref selectedBook, value); }
        }
    }
}
