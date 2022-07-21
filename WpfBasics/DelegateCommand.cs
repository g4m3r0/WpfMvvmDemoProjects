using System.Windows.Input;

namespace WpfBasics
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute) => (this.canExecute, this.execute) = (canExecute, execute);

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => this.canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => this.execute?.Invoke(parameter);

        public event EventHandler? CanExecuteChanged;
    }
}
