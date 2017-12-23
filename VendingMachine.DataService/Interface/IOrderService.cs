using VendingMachine.DataService.DTO;

namespace VendingMachine.DataService.Interface
{
    public interface IOrderService
    {
        AssortmentDTO GetAssortment();
        decimal СonfirmOrder(OrderDTO order);
    }
}
