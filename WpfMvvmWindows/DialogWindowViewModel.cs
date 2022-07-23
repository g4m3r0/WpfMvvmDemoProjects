using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMvvmBase;

namespace WpfMvvmWindows
{
    public class DialogWindowViewModel : NotifiableBaseObject
    {
        public event EventHandler Ok;
        public event EventHandler Cancel;

        public DialogWindowViewModel()
        {
            this.OkCommand = new DelegateCommand((o) => this.Ok?.Invoke(this, EventArgs.Empty));
            this.CancelCommand = new DelegateCommand((o) => this.Cancel?.Invoke(this, EventArgs.Empty));
        }

        public ICommand OkCommand { get; init; }
        public ICommand CancelCommand { get; init; }

        private string _name = string.Empty;

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

        private string _email = string.Empty;

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
