using System.Windows;

namespace Terminal
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AppBootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper = new AppBootstrapper();
            _bootstrapper.Run();
        }
    }
}