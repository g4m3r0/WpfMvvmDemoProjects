using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmCalculator.Models;

namespace WpfMvvmCalculator.ViewModels
{
    public class PersonListWindowObject : NotifyableBaseObject
    {
        public PersonListWindowObject()
        {
            this.AddPersonCommand = new DelegateCommand((o) =>
            {
                // Will be called on button click
                this.Persons.Add(NewPerson);
                NewPerson = new PersonModel();
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
