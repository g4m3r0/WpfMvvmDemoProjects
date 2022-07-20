using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMvvmCalculator.ViewModels;

namespace WpfMvvmCalculator
{
    /// <summary>
    /// Interaction logic for PersonListWindow.xaml
    /// </summary>
    public partial class PersonListWindow : Window
    {
        public PersonListWindow()
        {
            InitializeComponent();
            
            ((PersonListWindowViewModel)DataContext).MissingData += (sender, eventArgs) => ShowErrorMessage();
        }

        public void ShowErrorMessage()
        {
            MessageBox.Show("Please enter a value at first name, last name and department.", "Missing Data!");
        }
    }
}
