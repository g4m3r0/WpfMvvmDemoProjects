using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmBase;
using WpfMvvmCalculator.Models;

namespace WpfMvvmListFilter
{
    public class MainWindowViewModel : NotifiableBaseObject
    {
        public MainWindowViewModel()
        {
            this.persons.CollectionChanged += (s, e) =>
            {
                DoFiltering();
            };
            this.AddNewPersonCommand = new DelegateCommand((o) => AddNewPerson());
            AddSampleData();
        }

        public DelegateCommand AddNewPersonCommand { get; set; }

        private ObservableCollection<PersonModel> persons = new ObservableCollection<PersonModel>();
        public ObservableCollection<PersonModel> FilteredPersons { get; set; } = new ObservableCollection<PersonModel>();

        private string _searchText = string.Empty;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    DoFiltering();
                    OnPropertyChanged();
                }
            }
        }

        private void DoFiltering()
        {
            this.FilteredPersons.Clear();

            string? value = this.SearchText?.ToLower() ?? string.Empty;

            foreach (var person in persons)
            {
                if (string.IsNullOrEmpty(value) ||
                    person.FullName.ToLower().Contains(value) ||
                    person.Department.ToLower().Contains(value))
                {
                    this.FilteredPersons.Add(person);
                } 
            }
        }

        private void AddNewPerson()
        {
            this.persons.Add(new PersonModel()
            {
                Department = "Sales",
                FirstName = "Max",
                LastName = "Mustermann"
            });
        }

        private void AddSampleData()
        {
            this.persons.Add(new PersonModel()
            {
                Department = "Sales",
                FirstName = "Max",
                LastName = "Mustermann"
            });
            this.persons.Add(new PersonModel()
            {
                Department = "CTO",
                FirstName = "Tom",
                LastName = "Mueller"
            });
            this.persons.Add(new PersonModel()
            {
                Department = "Management",
                FirstName = "Lara",
                LastName = "Larsmann"
            });
        }

    }
}
