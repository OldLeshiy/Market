using System.ComponentModel.Composition;
using System.Windows;
using Terminal.ViewModel;

namespace Terminal.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class MainWindow : Window
    {
        [ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
        }

        [Import]
        public MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
            set { DataContext = value; }
        }
    }
}