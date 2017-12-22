using System.Collections.Generic;
using VendingMachine.DataService.DTO;

namespace VendingMachine.DataService.Interface
{
    public interface IOrderService
    {
        IEnumerable<ProductDTO> GetProductList();
        void OrderCostPrepare(OrderDTO order);
    }
}
