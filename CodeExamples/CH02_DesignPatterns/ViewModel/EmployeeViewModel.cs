using System.ComponentModel;
using System.Runtime.CompilerServices;
using CH02_DesignPatterns.Annotations;
using CH02_DesignPatterns.Model;

namespace CH02_DesignPatterns.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }



        public EmployeeViewModel()
        {
            var employee = new Employee
            {
                FirstName = "John",
                LastName = "Smith",
                Company = "Microsoft"
            };

            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Company = employee.Company;
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 

        #endregion
    }
}