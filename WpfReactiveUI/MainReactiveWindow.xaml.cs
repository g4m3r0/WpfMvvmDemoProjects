using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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
using ReactiveUI;

namespace WpfReactiveUI
{
    /// <summary>
    /// Interaction logic for MainReactiveWindow.xaml
    /// </summary>
    public partial class MainReactiveWindow
    {
        public MainReactiveWindow()
        {
            InitializeComponent();

            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            // We create our bindings here. These are the code behind bindings which allow 
            // type safety. The bindings will only become active when the Window is being shown.
            // We register our subscription in our disposableRegistration, this will cause 
            // the binding subscription to become inactive when the Window is closed.
            // The disposableRegistration is a CompositeDisposable which is a container of 
            // other Disposables. We use the DisposeWith() extension method which simply adds 
            // the subscription disposable to the CompositeDisposable.
            this.WhenActivated(disposableRegistration =>
            {
                // Notice we don't have to provide a converter, on WPF a global converter is
                // registered which knows how to convert a boolean into visibility.
                this.OneWayBind(ViewModel,
                    viewModel => viewModel.IsAvailable,
                    view => view.searchResultsListBox.Visibility)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.SearchResults,
                    view => view.searchResultsListBox.ItemsSource)
                    .DisposeWith(disposableRegistration);

                this.Bind(ViewModel,
                    viewModel => viewModel.SearchTerm,
                    view => view.searchTextBox.Text)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
