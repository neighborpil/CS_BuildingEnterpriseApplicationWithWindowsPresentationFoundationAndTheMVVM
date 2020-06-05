using CH02_DesignPatterns.Model;
using CH02_DesignPatterns.ValidationCheck;
using NUnit.Framework;

namespace CH02_DesignPattens.Test
{
    [TestFixture]
    public class ValidationCheckExampleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BaseValidator<Employee> validator = new EmployeeValidator();
            var employee = new Employee
            {
                FirstName = "",
                LastName = ""
            };
            var result = validator.IsValid(employee);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}