using System.ComponentModel.DataAnnotations;
using CRM.Domain.Base;

namespace CRM.Domain.Domain
{
    public class Contact : DomainObject
    {
        /// <summary>
        /// Gets or sets the type of the contact.
        /// </summary>
        /// <value>The type of the contact.</value>
        public ContactType ContactType { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>The person.</value>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "The Name is a mandatory field")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required(ErrorMessage = "The Description is a mandatory field")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required(ErrorMessage = "The Number is a mandatory field")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }
    }
}