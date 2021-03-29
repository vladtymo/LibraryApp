using System;

namespace PresentationLayer
{
    public class GenreViewModel : ViewModelBase
    {
        private string name;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
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
            get { return firstName; }
            set
            {
                SetProperty(ref firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get { return lastName; }
            set 
            { 
                SetProperty(ref lastName, value);
                OnPropertyChanged(nameof(FullName)); 
            }
        }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? BirthDate
        {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }
    }
    public class BookViewModel : ViewModelBase
    {
        private string title;
        private int pages;
        private AuthorViewModel author;
        private GenreViewModel genre;

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public AuthorViewModel Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }
        public GenreViewModel Genre
        {
            get { return genre; }
            set { SetProperty(ref genre, value); }
        }
        public int Pages
        {
            get { return pages; }
            set { SetProperty(ref pages, value); }
        }
    }
}
