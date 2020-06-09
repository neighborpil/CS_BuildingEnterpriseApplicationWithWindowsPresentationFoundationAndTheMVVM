using CRM.Domain.Base;

namespace CRM.Domain.Domain
{
    public sealed class OrderLine : DomainObject
    {
        private OrderLine(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="product">The product.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="discount">The discount.</param>
        public OrderLine(Order order, Product product, int quantity, decimal discount)
        {
            Product = product;
            Quantity = quantity;
            Discount = discount;
            Order = order;
            CalculateTotal();
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public decimal Discount { get; private set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public decimal Total { get; private set; }

        /// <summary>
        /// Calculates the total.
        /// </summary>
        private void CalculateTotal()
        {
            if (Discount > 0)
            {
                Total = Product.Price*Quantity*Discount;
            }
            else
            {
                Total = Product.Price*Quantity;
            }
        }
    }
}