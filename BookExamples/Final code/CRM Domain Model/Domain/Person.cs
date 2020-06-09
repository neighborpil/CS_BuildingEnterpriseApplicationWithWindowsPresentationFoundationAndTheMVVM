using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CRM.Domain.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CRM.Domain.Domain
{
    public abstract class Person : DomainObject, IDataErrorInfo
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [NotNullValidator(ErrorMessage = "The First Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage = "The First Name lenght can't be greater than 50 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [NotNullValidator(ErrorMessage = "The Last Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage = "The Last Name lenght can't be greater than 50 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [NotNullValidator(ErrorMessage = "The Birth Date can't be null or empty.")]
        [RelativeDateTimeValidator(18, DateTimeUnit.Year, 100, DateTimeUnit.Year,
            ErrorMessage = "The Birth Date can't be lower than 18 years.")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        public IList<Contact> Contacts { get; set; }


        /// <summary>
        /// Gets the default contact.
        /// </summary>
        /// <value>The default contact.</value>
        public Contact DefaultContact
        {
            get
            {
                if (Contacts == null)
                {
                    return null;
                }
                return Contacts.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get { return Validate<Person>(); }
        }

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void AddContact(Contact contact)
        {
            if (Contacts == null)
            {
                Contacts = new List<Contact>();
            }

            // If there are not default address, set this one as default
            if (Contacts.Where(x => x.IsDefault).Count() < 1)
            {
                contact.IsDefault = true;
            }


            //If this is the new default address
            if (contact.IsDefault)
            {
                foreach (Contact cont in Contacts)
                {
                    cont.IsDefault = false;
                }
            }

            // If the address is not already in the list
            if (!Contacts.Any(x => x.PrimaryKey == contact.PrimaryKey))
            {
                Contacts.Add(contact);
                contact.Person = this;
            }
        }

        /// <summary>
        /// Removes the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void RemoveContact(Contact contact)
        {
            if (Contacts == null)
            {
                return;
            }

            Contacts.Remove(contact);

            if (contact.IsDefault)
            {
                Contacts.FirstOrDefault().IsDefault = true;
            }
        }

        #region Implementation of IDataErrorInfo

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>
        /// The error message for the property. The default is an empty string ("").
        /// </returns>
        /// <param name="columnName">The name of the property whose error message to get. </param>
        public string this[string columnName]
        {
            get { return "Not Valid"; }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>
        /// An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}