using AutoMapper;
using BusinessLogicLayer;
using PresentationLayer.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace PresentationLayer
{
    public class NewBookViewModel : ViewModelBase
    {
        public NewBookViewModel(IBookService service, IMapper mapper)
        {
            Genres = mapper.Map<IEnumerable<GenreViewModel>>(service.GetAllGenres());
            Authors = mapper.Map<IEnumerable<AuthorViewModel>>(service.GetAllAuthors());

            Book = new BookViewModel();
            OkCmd = new DelegateCommand(() => IsOK = true);
        }

        public bool IsOK { get; set; }
        public ICommand OkCmd { get; }
        public BookViewModel Book { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; }
        public IEnumerable<GenreViewModel> Genres { get; }
    }
}
