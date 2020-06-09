using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Domain.Domain;

namespace CRM.BL
{
    public class CustomerFacade : BaseFacade<Customer>
    {
        public CustomerFacade(Customer customer) : base(customer)
        {

        }

        public bool CanAddOrder(Order order)
        {
            try
            {
                bool result = true;
                //run the workflow
                UnitOfWork.BeginTransaction();
                if (result)
                {

                    this.Entity.AddOrder(order);
                    UnitOfWork.CommitTransaction();
                }
                UnitOfWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                UnitOfWork.RollbackTransaction();
                throw new ApplicationException("The CanAddOrder process has thrown an exception.", ex);
            }
        }
    }
}
