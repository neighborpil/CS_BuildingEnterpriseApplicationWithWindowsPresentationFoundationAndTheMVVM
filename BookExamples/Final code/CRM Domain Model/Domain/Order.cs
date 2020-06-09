using System;
using System.Collections.Generic;
using CRM.Domain.Base;

namespace CRM.Domain.Domain
{
    public sealed class Order : DomainObject
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the shipment address.
        /// </summary>
        /// <value>The shipment address.</value>
        public Address ShipmentAddress { get; set; }

        /// <summary>
        /// Gets or sets the bill address.
        /// </summary>
        /// <value>The bill address.</value>
        public Address BillAddress { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        /// <value>The order lines.</value>
        public IList<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the approval.
        /// </summary>
        /// <value>The approval.</value>
        public Approval Approval { get; set; }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="discount">The discount.</param>
        public void AddProduct(Product product, int quantity, decimal discount = 0)
        {
            if (OrderLines == null)
            {
                OrderLines = new List<OrderLine>();
            }
            OrderLines.Add(new OrderLine(this, product, quantity, discount));
        }
    }
}