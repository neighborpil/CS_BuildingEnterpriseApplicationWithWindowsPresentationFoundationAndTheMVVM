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
    public sealed class EmployeesTreeViewModel : BaseViewModel<BindingList<Employee>>
    {
        private readonly IRepository repository;
        private string searchText = string.Empty;
        private Employee selectedEmployee;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesTreeViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public EmployeesTreeViewModel(BindingList<Employee> model)
            : base(model)
        {
            Initialize();
        }

        [InjectionConstructor]
        public EmployeesTreeViewModel(IRepository repository)
            : this(new BindingList<Employee>())
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets or sets the search command.
        /// </summary>
        /// <value>The search command.</value>
        public ICommand SearchCommand { get; set; }

        public ICommand SelectedEmployeeChanged { get; set; }

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

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(x => SelectedEmployee);
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
                        IQueryable<Employee> result = from e in repository.GetList<Employee>()
                                                      where e.FirstName.Contains(SearchText)
                                                            || e.LastName.Contains(SearchText)
                                                      select e;
                        Model.Clear();
                        result.ToList().ForEach(e => Model.Add(e));
                    },
                (parm) => { return true; });
            SelectedEmployeeChanged = new MvvmCommand(
                (parm) =>
                    {
                        if (parm is Employee)
                        {
                            SelectedEmployee = (Employee) parm;
                        }
                    },
                (parm) => { return true; })
                ;
        }
    }
}