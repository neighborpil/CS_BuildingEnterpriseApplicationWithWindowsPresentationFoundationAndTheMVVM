using System.Windows;
using CRM.Dal;
using CRM.Dal.Nhibernate;
using CRM.MVVM.WPF.TreeViews;
using CRM.MVVM.WPF.ViewModels;
using Microsoft.Practices.Unity;

namespace CRM.MVVM.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer container;

        public App()
        {
            container = new UnityContainer();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.InitializeServices();
            var navigator = container.Resolve<INavigator>();
            var region = container.Resolve<IRegionAdapter>();
            // bootstrap
            navigator.Startup<MainWindow>();
            navigator.OpenView<EmployeesTree>("EmployeesRegion", container.Resolve<EmployeesTreeViewModel>());
            navigator.OpenView<CustomersTree>("CustomersRegion", container.Resolve<CustomersTreeViewModel>());
            navigator.OpenView<ProductsTree>("ProductsRegion", container.Resolve<ProductsTreeViewModel>());
        }

        protected void InitializeServices()
        {
            // register DAL
            ISessionFactory factory = new SessionFactory();
            container.RegisterType<IRepository, Repository>(new InjectionConstructor(factory.CurrentUoW));
            // register navigation services
            container.RegisterInstance<IRegionAdapter>(new RegionAdapter(container));
            container.RegisterType<INavigator, Navigator>();
        }
    }
}