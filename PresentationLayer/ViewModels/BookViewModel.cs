namespace PresentationLayer
{
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
}
