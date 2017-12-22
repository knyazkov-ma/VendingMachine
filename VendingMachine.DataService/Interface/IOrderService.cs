using VendingMachine.DataService.DTO;

namespace VendingMachine.DataService.Interface
{
    public interface IOrderService
    {
        AssortmentDTO GetAssortment();
        decimal GetOrderCost(OrderDTO order);
    }
}
