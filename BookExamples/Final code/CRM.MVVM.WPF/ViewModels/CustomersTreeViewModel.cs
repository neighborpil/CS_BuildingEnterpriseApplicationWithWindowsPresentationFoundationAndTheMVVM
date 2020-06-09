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
    public sealed class CustomersTreeViewModel
        : BaseViewModel<BindingList<Customer>>

    {
        private readonly IRepository repository;
        private string searchText = string.Empty;
        private Customer selectedCustomer;

        public CustomersTreeViewModel(BindingList<Customer> model) : base(model)
        {
            Initialize();
        }

        [InjectionConstructor]
        public CustomersTreeViewModel(IRepository repository) : this(new BindingList<Customer>())
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets or sets the search command.
        /// </summary>
        /// <value>The search command.</value>
        public ICommand SearchCommand { get; private set; }

        public ICommand SelectedCustomerChanged { get; private set; }

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

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(x => SelectedCustomer);
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
                        IQueryable<Customer> result = from c in repository.GetList<Customer>()
                                                      where c.FirstName.Contains(SearchText)
                                                            || c.LastName.Contains(SearchText)
                                                      select c;
                        Model.Clear();
                        result.ToList().ForEach(c => Model.Add(c));
                    },
                (parm) => true);
            SelectedCustomerChanged = new MvvmCommand(
                (parm) =>
                    {
                        if (parm is Customer)
                        {
                            SelectedCustomer = (Customer) parm;
                        }
                    },
                (parm) => { return true; })
                ;
        }
    }
}