using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfBasics;

namespace WpfMvvmWindows
{
    public class MainWindowViewModel : NotifiableBaseObject
    {
        //public event EventHandler OpenDialog;

        public delegate (string name, string email) OpenDialogHandler(string name, string email);
        public OpenDialogHandler OpenDialog { get; set; }

        public MainWindowViewModel()
        {
            this.OpenDialogCommand = new DelegateCommand((o) =>
            {
                //this.OpenDialog?.Invoke(this, EventArgs.Empty);
                (Name, Email) = OpenDialog(this.Name, this.Email);
            });
        }

        public ICommand OpenDialogCommand { get; init; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
