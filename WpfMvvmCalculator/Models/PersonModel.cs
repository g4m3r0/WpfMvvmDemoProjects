using GSL.Util.WpfMvvmBase;

namespace WpfMvvmCalculator.Models
{
    public class PersonModel : NotifiableBaseObject
    {
        private string _firstName;
        private string _lastName;
        private string _department;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            } 
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public string Department
        {
            get => _department;
            set
            {
                if (value != _lastName)
                {
                    _department = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
    }
}
