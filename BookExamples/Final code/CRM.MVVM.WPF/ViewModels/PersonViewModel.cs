using System.Windows.Input;
using CRM.Domain.Domain;
using CRM.MVVM.Dialog;
using CRM.MVVM.ViewModel;

namespace CRM.MVVM.WPF.ViewModels
{
    public sealed class PersonViewModel : BaseViewModel<Person>
    {
        public ICommand ShowMessage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PersonViewModel(Person model)
            : base(model)
        {
        }


        public override string this[string columnName]
        {
            get { return ViewModelValidator.ValidateField(model, columnName); }
        }

        private IDialogService dialogService;

        public ICommand SavePerson { get; private set; }

        /// <summary>
        /// Inits the commands.
        /// </summary>
        private void InitCommands()
        {
            ShowMessage = new MVVM.Commanding.MvvmCommand(
                (sender) =>
                    {
                        var result = dialogService.ShowDialogMessage("Confirm?", "This is a confirm message.");
                        if (result.HasValue && result.Value)
                        {
                            // do something
                        }
                    }, 
                (sender) =>
                {
                    return true;
                });
        }

        public override string Title
        {
            get { return this.Model.FirstName + " " + this.Model.LastName; }
        }

    }
}