using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmCalculator
{
    public class CalculatorWindowViewModel : BaseViewModel
    {
        private double lastValue;
        private string operatorToExecute;

        public CalculatorWindowViewModel()
        {
            this.NumberCommand = new DelegateCommand((value) =>
            {
                int val = int.Parse((string)value);
                this.CurrentValue = this.CurrentValue * 10 + val;
            });
            this.OperatorCommand = new DelegateCommand((o) =>
            {
                string op = (string)o;

                if (op != "=")
                {
                    this.operatorToExecute = op;
                    lastValue = CurrentValue;
                    CurrentValue = 0.0;
                }
                else
                {
                    switch (operatorToExecute)
                    {
                        case "+":
                            CurrentValue += lastValue;
                            break;
                        case "-":
                            CurrentValue = lastValue - _currentValue;
                            break;
                        case "*":
                            CurrentValue *= lastValue;
                            break;
                        case "/":
                            CurrentValue = lastValue / _currentValue;
                            break;
                        default:
                            break;
                    }
                }

            });
        }

        private double _currentValue;

        public double CurrentValue
        {
            get => _currentValue;
            set
            {
                if (_currentValue != value)
                {
                    _currentValue = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DelegateCommand NumberCommand { get; set; }
        public DelegateCommand OperatorCommand { get; set; }
    }
}
