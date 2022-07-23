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

namespace WpfMvvmWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = ((MainWindowViewModel)DataContext);
            vm.OpenDialog = (name, email) =>
            {
                DialogWindow dialogWindow = new DialogWindow();
                if (dialogWindow.ShowDialog() == true)
                {
                    var dialogViewModel = (DialogWindowViewModel)dialogWindow.DataContext;
                    return (dialogViewModel.Name, dialogViewModel.Email);
                }
                return (string.Empty, string.Empty);
            };
            //vm.OpenDialog += (sender, e) =>
            //{
            //    DialogWindow dialogWindow = new DialogWindow();

            //    if(dialogWindow.ShowDialog() == true) {
            //        var dialogViewModel = (DialogWindowViewModel)dialogWindow.DataContext;
            //        vm.Name = dialogViewModel.Name;
            //        vm.Email = dialogViewModel.Email;
            //    }
            //};
        }
    }
}
