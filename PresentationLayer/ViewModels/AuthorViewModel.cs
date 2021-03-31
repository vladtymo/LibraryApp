using System;

namespace PresentationLayer
{
    public class AuthorViewModel : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private DateTime? birthDate;

        public int Id { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? BirthDate { get => birthDate; set => SetProperty(ref birthDate, value); }
    }
}
