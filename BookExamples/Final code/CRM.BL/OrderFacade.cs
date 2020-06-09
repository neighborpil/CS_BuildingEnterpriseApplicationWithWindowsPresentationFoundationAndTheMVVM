using CRM.Domain.Domain;

namespace CRM.BL
{
    public class OrderFacade : BaseFacade<Product>
    {
        public OrderFacade(Product entity) : base(entity)
        {
        }
    }
}