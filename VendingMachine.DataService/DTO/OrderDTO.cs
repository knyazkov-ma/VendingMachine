using System.Collections.Generic;

namespace VendingMachine.DataService.DTO
{
    public class OrderDTO
    {
        public IEnumerable<ProductDTO> Items { get; set; }
        public decimal Cost { get; set; }
    }
}
