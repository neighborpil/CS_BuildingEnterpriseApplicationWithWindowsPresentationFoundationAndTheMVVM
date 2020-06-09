using System;
using System.Configuration;
using CRM.Domain.Domain;
using NUnit.Framework;

namespace CRM.Dal.EF.Fixture
{
    [TestFixture]
    public sealed class DatabaseFixture
    {
        [Test]
        public void CanCreateDatabaseSchema()
        {
            try
            {
                IUnitOfWork unitOfWork = new SessionFactory().CurrentUoW;
                Assert.That(unitOfWork, Is.Not.Null);
                Assert.That(unitOfWork.Orm, Is.Not.Null);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.ToString());
            }
        }

        [Test]
        public void CanCreateACustomer()
        {
            try
            {
                Customer customer = new Customer();
                customer.FirstName = "Raffaele";
                customer.LastName = "Garofalo";
                customer.Title = "Mr.";
                customer.BirthDate = DateTime.Now;
                Contact contact = new Contact();
                contact.ContactType = ContactType.Email;
                contact.Name = "E-mail address";
                contact.Number = "raffaeu@raffaeu.com";
                customer.AddContact(contact);
                // get the persistance 
                ISessionFactory factory = new SessionFactory();
                IUnitOfWork unitOfWork = factory.CurrentUoW;
                IRepository repository = new Repository(unitOfWork);
                unitOfWork.BeginTransaction();
                repository.AddEntity(customer);
                unitOfWork.CommitTransaction();
                Assert.That(customer, Has.Property("PrimaryKey").Not.EqualTo(Guid.Empty));
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.ToString());
            }
        }

    }
}