using AutoMapper;
//using BusinessLogicLayer;
using PresentationLayer.WcfService;
using PresentationLayer.Commands;
using System.Collections.Generic;
using System.Windows;
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
            OkCmd = new DelegateCommand((o) => { IsOK = true; ((Window)o).Close(); });
            CancelCmd = new DelegateCommand((o) => { IsOK = false; ((Window)o).Close(); });
        }

        public bool IsOK { get; set; }
        public ICommand OkCmd { get; }
        public ICommand CancelCmd { get; }
        public BookViewModel Book { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; }
        public IEnumerable<GenreViewModel> Genres { get; }
    }
}
