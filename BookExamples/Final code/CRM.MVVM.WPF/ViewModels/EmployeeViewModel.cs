using CRM.Domain.Domain;
using CRM.MVVM.ViewModel;

namespace CRM.MVVM.WPF.ViewModels
{
    public sealed class EmployeeViewModel : BaseViewModel<Employee>
    {
        public EmployeeViewModel(Employee model)
            : base(model)
        {
        }

        public override string Title
        {
            get { return this.Model.FirstName + " " + this.Model.LastName; }
        }
    }
}