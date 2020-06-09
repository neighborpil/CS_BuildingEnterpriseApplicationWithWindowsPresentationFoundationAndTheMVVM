using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using CRM.Dal;
using CRM.Domain.Domain;
using CRM.MVVM.Commanding;
using CRM.MVVM.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;

namespace CRM.MVVM.WPF.ViewModels
{
    public sealed class ProductsTreeViewModel : BaseViewModel<BindingList<Product>>
    {
        private readonly IRepository repository;
        private string searchText = string.Empty;
        private Product selectedProduct;

        public ProductsTreeViewModel(BindingList<Product> model) : base(model)
        {
            Initialize();
        }

        [InjectionConstructor]
        public ProductsTreeViewModel(IRepository repository) : this(new BindingList<Product>())
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets or sets the search command.
        /// </summary>
        /// <value>The search command.</value>
        public ICommand SearchCommand { get; private set; }

        public ICommand SelectedProductChanged { get; set; }

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>The search text.</value>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(x => SearchText);
            }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(x => SelectedProduct);
                Messenger.Default.Send(value);
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            SearchCommand = new MvvmCommand(
                (parm) =>
                    {
                        IQueryable<Product> result = from p in repository.GetList<Product>()
                                                     where p.Name.Contains(SearchText)
                                                           || p.Code.Contains(SearchText)
                                                     select p;
                        Model.Clear();
                        result.ToList().ForEach(e => model.Add(e));
                    },
                (parm) => { return true; });
            SelectedProductChanged = new MvvmCommand(
                (parm) =>
                    {
                        if (parm is Product)
                        {
                            SelectedProduct = (Product) parm;
                        }
                    },
                (parm) => { return true; })
                ;
        }
    }
}