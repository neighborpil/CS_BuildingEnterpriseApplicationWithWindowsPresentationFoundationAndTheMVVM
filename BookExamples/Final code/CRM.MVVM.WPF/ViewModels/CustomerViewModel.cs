using CRM.Domain.Domain;
using CRM.MVVM.ViewModel;

namespace CRM.MVVM.WPF.ViewModels
{
    public sealed class CustomerViewModel : BaseViewModel<Customer>
    {
        public CustomerViewModel(Customer model)
            : base(model)
        {
        }

        public override string Title
        {
            get { return this.Model.FirstName + " " + this.Model.LastName; }
        }
    }
}