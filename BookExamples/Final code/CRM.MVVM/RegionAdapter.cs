using System.Collections.Generic;
using System.Windows.Controls;
using AvalonDock;
using CRM.MVVM.ViewModel;
using Microsoft.Practices.Unity;

namespace CRM.MVVM
{
    public class RegionAdapter : IRegionAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUnityContainer container;

        /// <summary>
        /// 
        /// </summary>
        private readonly IDictionary<string, object> regions = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionAdapter"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public RegionAdapter(IUnityContainer container)
        {
            this.container = container;
        }

        #region Implementation of IRegionAdapter

        /// <summary>
        /// Registers the region.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        public IRegionAdapter RegisterRegion(string name, object region)
        {
            regions.Add(name, region);
            return this;
        }

        /// <summary>
        /// Adds the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public IRegionAdapter AddView<TView>(TView view, string regionName, string title = "") where TView : class
        {
            object region = regions[regionName];
            if (region is ContentControl)
            {
                ((ContentControl) region).Content = view;
            }
            if (region is DocumentPane)
            {
                var panel = new DocumentContent {Title = typeof (TView).Name, Content = view};
                panel.Title = title;
                ((DocumentPane) region).Items.Add(panel);
                panel.Activate();
            }
            return this;
        }

        #endregion
    }
}