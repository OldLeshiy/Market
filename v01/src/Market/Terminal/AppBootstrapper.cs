using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Mef;
using Terminal.View;

namespace Terminal
{
    public class AppBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            AggregateCatalog.Catalogs.Add(new ApplicationCatalog());
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}