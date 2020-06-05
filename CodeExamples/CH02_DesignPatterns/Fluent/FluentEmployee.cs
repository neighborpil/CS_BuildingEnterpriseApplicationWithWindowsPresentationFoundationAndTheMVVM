using CH02_DesignPatterns.Model;

namespace CH02_DesignPatterns.Fluent
{
    public interface IFluentEmployee
    {
        IFluentEmployee FirstName(string firstName);

        IFluentEmployee LastName(string lastName);

        IFluentEmployee Company(string company);

        Employee Create();
    }

    public class FluentEmployee : IFluentEmployee
    {
        private static Employee employee;

        private static IFluentEmployee fluent;

        public FluentEmployee()
        {
            fluent = new FluentEmployee();
        }

        public static IFluentEmployee Init()
        {
            employee = new Employee();
            return fluent;
        }

        public IFluentEmployee FirstName(string firstName)
        {
            employee.FirstName = firstName;
            return fluent;
        }

        public IFluentEmployee LastName(string lastName)
        {
            employee.LastName = lastName;
            return fluent;
        }

        public IFluentEmployee Company(string company)
        {
            employee.Company = company;
            return fluent;
        }

        public Employee Create()
        {
            return employee;
        }
    }

    public class Use
    {
        public Use()
        {
            var employee = FluentEmployee
                .Init()
                .FirstName("John")
                .LastName("Smith")
                .Company("Micro")
                .Create();

        }
    }
}