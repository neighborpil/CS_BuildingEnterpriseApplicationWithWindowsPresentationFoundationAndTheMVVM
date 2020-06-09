using System;
using System.Windows;
using CRM.Domain.Domain;
using CRM.MVVM.WPF.DetailsView;
using CRM.MVVM.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;

namespace CRM.MVVM.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnityContainer container;

        public MainWindow()
        {
            InitializeComponent();

            this.container = container;
        }

        [InjectionConstructor]
        public MainWindow(IUnityContainer container):this()
        {
            this.container = container;
            var region = container.Resolve<IRegionAdapter>();
            var navigator = container.Resolve<INavigator>();
            region
                .RegisterRegion("EmployeesRegion", this.EmployeesContent)
                .RegisterRegion("CustomersRegion", this.CustomersContent)
                .RegisterRegion("ProductsRegion", this.ProductsContent)
                .RegisterRegion("DocumentsRegion", this.DocumentsRegion);
            Messenger.Default.Register<Customer>(this, (e) =>
                navigator.OpenView<CustomerDetails>("DocumentsRegion", new CustomerViewModel(e)));
            Messenger.Default.Register<Employee>(this, (e) =>
                navigator.OpenView<EmployeeDetails>("DocumentsRegion", new EmployeeViewModel(e)));
        }
    }
}