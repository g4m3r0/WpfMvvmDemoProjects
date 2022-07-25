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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMvvmUserControls
{
    /// <summary>
    /// Interaction logic for MaxLengthTextBoxUserControl.xaml
    /// </summary>
    public partial class MaxLengthTextBoxUserControl : UserControl
    {
        public MaxLengthTextBoxUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Caption { get; set; }
        public int MaxLength { get; set; }
    }
}
