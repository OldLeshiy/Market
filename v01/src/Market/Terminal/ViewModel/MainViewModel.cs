using System.ComponentModel.Composition;

namespace Terminal.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MainViewModel
    {
        [ImportingConstructor]
        public MainViewModel()
        {
        }

        [Import]
        public BarListViewModel BarListViewModel { get; set; }
    }
}