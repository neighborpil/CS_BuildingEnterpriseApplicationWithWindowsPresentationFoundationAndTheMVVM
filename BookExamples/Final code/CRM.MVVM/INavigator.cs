namespace CRM.MVVM
{
    public interface INavigator
    {
        /// <summary>
        /// Startups this instance.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        void Startup<TView>() where TView : class;

        /// <summary>
        /// Startups the specified view model.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="viewModel">The view model.</param>
        void Startup<TView>(object viewModel) where TView : class;

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="regionName">Name of the region.</param>
        void OpenView<TView>(string regionName) where TView : class;

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="viewModel">The view model.</param>
        void OpenView<TView>(string regionName, object viewModel) where TView : class;
    }
}