using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmBase;
using WpfMvvmCalculator.Models;

namespace WpfMvvmCalculator.ViewModels
{
    public class PersonListWindowViewModel : NotifiableBaseObject
    {
        public event EventHandler? MissingData;

        public PersonListWindowViewModel()
        {
            this.AddPersonCommand = new DelegateCommand((o) =>
            {
                // Will be called on button click
                if (string.IsNullOrEmpty(NewPerson.FirstName) || string.IsNullOrEmpty(NewPerson.LastName) || string.IsNullOrEmpty(NewPerson.Department))
                {
                    MissingData?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    this.Persons.Add(NewPerson);
                    NewPerson = new PersonModel();
                }
            });

            AddSampleData();
        }

        public void AddSampleData()
        {
            this.Persons.Add(new PersonModel()
            {
                Department = "Sales",
                FirstName = "Max",
                LastName = "Mustermann"
            });
            this.Persons.Add(new PersonModel()
            {
                Department = "CTO",
                FirstName = "Tom",
                LastName = "Mueller"
            });
            this.Persons.Add(new PersonModel()
            {
                Department = "Management",
                FirstName = "Lara",
                LastName = "Larsmann"
            });
        }

        private ObservableCollection<PersonModel> _persons = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> Persons
        {
            get => _persons;
            set
            {
                if (value != _persons)
                {
                    _persons = value;
                    OnPropertyChanged();
                }
            }
        }

        private PersonModel _newPerson = new PersonModel();

        public PersonModel NewPerson
        {
            get { return _newPerson; }
            set
            {
                if (value != _newPerson)
                {
                    _newPerson = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand AddPersonCommand { get; set; }

    }
}
