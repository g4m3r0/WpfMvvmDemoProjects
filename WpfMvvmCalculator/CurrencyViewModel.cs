using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmCalculator
{
    public class CurrencyViewModel : BaseViewModel
    {
        private decimal _value;

        public decimal Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(HasNonZeroValue));
                }
            } 
        }

        public bool HasNonZeroValue => Value != 0.0m;
    }
}
