namespace CRM.MVVM
{
    public interface IRegionAdapter
    {
        /// <summary>
        /// Registers the region.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        IRegionAdapter RegisterRegion(string name, object region);

        /// <summary>
        /// Adds the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        IRegionAdapter AddView<TView>(TView view, string regionName, string title = "") where TView : class;
    }
}