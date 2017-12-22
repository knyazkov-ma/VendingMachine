using VendingMachine.Data.Repository;
using VendingMachine.DataService.DTO;
using VendingMachine.DataService.Interface;
using VendingMachine.Entity;
using System.Linq;
using System.Collections.Generic;

namespace VendingMachine.DataService
{
    public class OrderService: IOrderService
    {
        private readonly IBaseRepository<Product> productRepository;
        private readonly IBaseRepository<Combination> combinationRepository;
        
        public OrderService(IBaseRepository<Product> productRepository,
            IBaseRepository<Combination> combinationRepository)
        {
            this.productRepository = productRepository;
            this.combinationRepository = combinationRepository;            
        }

        public IEnumerable<ProductDTO> GetProductList()
        {
            IEnumerable<Product> products = productRepository.GetList().ToList();
            IEnumerable<Combination> combinations = combinationRepository.GetList().ToList();

            IList<ProductDTO> list = new List<ProductDTO>();

            foreach (var p in products)
            {
                ProductDTO dto = new ProductDTO
                {
                    Id = p.Id,
                    MaxCountPerOrder = p.MaxCountPerOrder,
                    Name = p.Name,
                    Price = p.Price,
                    ProductType = p.ProductType,
                    ProductTypeName = "",
                    Combinations = combinations.Where(t => t.ProductFrom.Id == p.Id)
                };
            }

            return list;
        }
        public void OrderCostPrepare(OrderDTO order)
        {
            order.Cost = order.Items.Sum(p => p.Price);
        }

    }
}
