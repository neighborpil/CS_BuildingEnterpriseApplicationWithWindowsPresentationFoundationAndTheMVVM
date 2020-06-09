using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;

namespace CRM.MVVM
{
    public class Navigator : INavigator
    {
        private IUnityContainer container;

        private IRegionAdapter regionAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Navigator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionAdapter">The region adapter.</param>
        [InjectionConstructor]
        public Navigator(IUnityContainer container, IRegionAdapter regionAdapter)
        {
            this.container = container;
            this.regionAdapter = regionAdapter;
        }

        #region INavigator Members

        /// <summary>
        /// Startups this instance.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        public void Startup<TView>() where TView : class
        {
            var view = container.Resolve<TView>() as Window;

            if (view != null)
            {
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.Show();
            }
        }

        /// <summary>
        /// Startups the specified view model.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model.</param>
        public void Startup<TView>(object viewModel) where TView : class
        {
            var view = container.Resolve<TView>() as Window;
            if (view != null)
            {
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.DataContext = viewModel;
                view.Show();
            }
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="regionName">Name of the region.</param>
        public void OpenView<TView>(string regionName) where TView : class
        {
            var view = container.Resolve<TView>() as UserControl;
            if (view != null)
            {
                regionAdapter.AddView(view, regionName);
            }
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="viewModel">The view model.</param>
        public void OpenView<TView>(string regionName, object viewModel) where TView : class
        {
            var view = container.Resolve<TView>() as UserControl;
            if (view != null)
            {
                dynamic vm = viewModel;
                view.DataContext = viewModel;
                regionAdapter.AddView(view, regionName, vm.Title);
            }
        }

        #endregion
    }
}