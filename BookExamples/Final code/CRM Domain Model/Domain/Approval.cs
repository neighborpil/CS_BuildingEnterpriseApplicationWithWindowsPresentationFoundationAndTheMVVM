using CRM.Domain.Base;

namespace CRM.Domain.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Approval : DomainObject
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public ApprovalStatus Status { get; set; }
    }
}