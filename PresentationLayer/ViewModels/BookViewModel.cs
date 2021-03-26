using System;

namespace PresentationLayer
{
    public class BookViewModel : ViewModelBase
    {
        private string title;
        private string authorName;
        private string authorSurname;
        private DateTime? authorBirthDate;
        private string genreName;
        private int pages;

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public string AuthorName
        {
            get { return authorName; }
            set { SetProperty(ref authorName, value); }
        }
        public string AuthorSurname
        {
            get { return authorSurname; }
            set { SetProperty(ref authorSurname, value); }
        }
        public DateTime? AuthorBirthDate
        {
            get { return authorBirthDate; }
            set { SetProperty(ref authorBirthDate, value); }
        }
        public string GenreName
        {
            get { return genreName; }
            set { SetProperty(ref genreName, value); }
        }
        public int Pages
        {
            get { return pages; }
            set { SetProperty(ref pages, value); }
        }
    }
}
