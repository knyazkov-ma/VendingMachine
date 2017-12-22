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
        private readonly IBaseRepository<Composition> compositionRepository;
        public OrderService(IBaseRepository<Product> productRepository,
            IBaseRepository<Combination> combinationRepository,
            IBaseRepository<Composition> compositionRepository)
        {
            this.productRepository = productRepository;
            this.combinationRepository = combinationRepository;
            this.compositionRepository = compositionRepository;
        }

        /// <summary>
        /// Доступный для выбора ассортимент
        /// </summary>
        public AssortmentDTO GetAssortment()
        {
            IEnumerable<Product> products = productRepository
                .GetList()
                    .OrderBy(t => t.ProductType)
                    .ThenBy(t => t.Ord)
                .ToList();
            IEnumerable<Combination> combinations = combinationRepository
                .GetList()
                .ToList();

            IList<ProductDTO> list = new List<ProductDTO>();

            foreach (var p in products)
            {
                ProductDTO d = new ProductDTO
                {
                    Id = p.Id,
                    MaxCountPerOrder = p.MaxCountPerOrder,
                    Name = p.Name,
                    Price = p.Price,
                    ProductType = p.ProductType,
                    Combinations = combinations.Where(t => t.ProductFrom.Id == p.Id)
                };
                list.Add(d);
            }

            AssortmentDTO assortment = new AssortmentDTO
            {
                Composition = compositionRepository.GetList().FirstOrDefault(),
                DrinkGroup = new AssortmentGroupDTO
                {
                    Items = list.Where(t => t.ProductType == ProductType.Drink),
                    ProductType = ProductType.Drink
                },
                DrinkAdditionGroup = new AssortmentGroupDTO
                {
                    Items = list.Where(t => t.ProductType == ProductType.DrinkAddition),
                    ProductType = ProductType.DrinkAddition
                },
                FoodGroup = new AssortmentGroupDTO
                {
                    Items = list.Where(t => t.ProductType == ProductType.Food),
                    ProductType = ProductType.Food
                },
                FoodAdditionGroup = new AssortmentGroupDTO
                {
                    Items = list.Where(t => t.ProductType == ProductType.FoodAddition),
                    ProductType = ProductType.FoodAddition
                }
            }; 

            return assortment;
        }

        /// <summary>
        /// Стоимость заказа
        /// </summary>
        public decimal GetOrderCost(OrderDTO order)
        {
            if (order.Composition)
            {
                Composition composition = compositionRepository.GetList().FirstOrDefault();
                return composition.Price;
            }

            return productRepository
                .GetList(t => order.SelectedProductIds.Contains(t.Id))
                .ToList()
                .Sum(p => p.Price);

        }

    }
}
