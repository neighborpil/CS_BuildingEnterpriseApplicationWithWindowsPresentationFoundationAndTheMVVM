using System.ComponentModel.DataAnnotations;
using CRM.Domain.Base;

namespace CRM.Domain.Domain
{
    public sealed class Product : DomainObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "The Name of a product is mandatory")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required(ErrorMessage = "The Description of a product is mandatory")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount in stock.
        /// </summary>
        /// <value>The amount in stock.</value>
        public int AmountInStock { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required(ErrorMessage = "The Code of a product is mandatory")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Required(ErrorMessage = "The Price of a product is mandatory")]
        public decimal Price { get; set; }
    }
}