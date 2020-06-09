using System;
using System.Collections.Generic;
using System.Reflection;
using CRM.Dal.Nhibernate;
using CRM.Domain.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CRM.Dal.NHibernate.Fixture
{
    [TestFixture]
    public sealed class DatabaseFixture
    {
        [TestFixtureSetUp]
        public void CanCreateDatabaseSchema()
        {
            try
            {
                var cfg = new Configuration();
                cfg.Configure();
                cfg.AddAssembly(Assembly.Load("CRM.Dal.Nhibernate"));
                new SchemaExport(cfg).Execute(true, true, false);
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.ToString());
            }
        }

        [Test]
        public void CanGetAUnitOfWork()
        {
            try
            {
                ISessionFactory factory = new SessionFactory();
                IUnitOfWork unitOfWork = factory.CurrentUoW;
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

        [Test]
        public void PrepareDatabase()
        {
            try
            {
                // Customer
                CreateCustomer();
                CreateEmployee();
                CreateProducts();
            }
            catch (Exception exception)
            {
                Assert.Fail(exception.ToString());
            }
        }

        private void CreateEmployee()
        {
            Employee employee =
                new Employee()
                {
                    FirstName = "Mary",
                    LastName = "Mouse",
                    Title = "Mrs.",
                    BirthDate = new DateTime(1978, 06, 12),
                };
            Contact email =
                new Contact
                {
                    ContactType = ContactType.Email,
                    Name = "E-mail",
                    Number = "mary@raffaeu.com",
                    Description = "E-mail address",
                    IsDefault = true
                };
            employee.AddContact(email);
            ISessionFactory factory = new SessionFactory();
            IUnitOfWork unitOfWork = factory.CurrentUoW;
            IRepository repository = new Repository(unitOfWork);
            unitOfWork.BeginTransaction();
            repository.AddEntity(employee);
            unitOfWork.CommitTransaction();
        }

        private void CreateCustomer()
        {
            Customer customer = 
                new Customer
                    {
                        FirstName = "Raffaele",
                        LastName = "Garofalo",
                        Title = "Mr.",
                        BirthDate = new DateTime(1978,06,12),
                    };
            Contact email =
                new Contact
                    {
                        ContactType = ContactType.Email,
                        Name = "E-mail",
                        Number = "raffaeu@raffaeu.com",
                        Description = "E-mail address",
                        IsDefault = true
                    };
            customer.AddContact(email);
            Address address =
                new Address
                    {
                        AddressLine1 = "4 Henry Vale",
                        City = "Warwick",
                        Country = "Bermuda",
                        IsDefault = true,
                        State = "Bermuda",
                        Town = "Warwick",
                        ZipCode = "PG01"

                    };
            customer.AddAddress(address);
            ISessionFactory factory = new SessionFactory();
            IUnitOfWork unitOfWork = factory.CurrentUoW;
            IRepository repository = new Repository(unitOfWork);
            unitOfWork.BeginTransaction();
            repository.AddEntity(customer);
            unitOfWork.CommitTransaction();
        }

        private void CreateProducts()
        {
            Product product01 =
                new Product
                {
                    AmountInStock = 10,
                    Code = "ABC123",
                    Description = "Sample product 01",
                    Name = "ABC 123",
                    Price = new decimal(100.5)
                };
            Product product02 =
                new Product
                {
                    AmountInStock = 25,
                    Code = "CDE456",
                    Description = "Sample product 02",
                    Name = "CDE 456",
                    Price = new decimal(45)
                };
            ISessionFactory factory = new SessionFactory();
            IUnitOfWork unitOfWork = factory.CurrentUoW;
            IRepository repository = new Repository(unitOfWork);
            unitOfWork.BeginTransaction();
            repository.AddEntity(product01);
            repository.AddEntity(product02);
            unitOfWork.CommitTransaction();
        }
    }
}