using VendingMachine.Data.Repository;
using VendingMachine.DataService.DTO;
using VendingMachine.DataService.Interface;
using VendingMachine.Entity;
using System.Linq;
using System.Collections.Generic;
using VendingMachine.DataService.Common;
using VendingMachine.DataService.Resources;

namespace VendingMachine.DataService
{
    public class OrderService: IOrderService
    {
        private readonly IBaseRepository<Product> productRepository;
        private readonly IBaseRepository<Combination> combinationRepository;
        private readonly IBaseRepository<Composition> compositionRepository;
        private readonly IBaseRepository<Settings> settingsRepository;
        private readonly IBaseRepository<ForbiddenCombination> forbiddenCombinationRepository;
        public OrderService(IBaseRepository<Product> productRepository,
            IBaseRepository<Combination> combinationRepository,
            IBaseRepository<Composition> compositionRepository,
            IBaseRepository<Settings> settingsRepository,
            IBaseRepository<ForbiddenCombination> forbiddenCombinationRepository)
        {
            this.productRepository = productRepository;
            this.combinationRepository = combinationRepository;
            this.compositionRepository = compositionRepository;
            this.settingsRepository = settingsRepository;
            this.forbiddenCombinationRepository = forbiddenCombinationRepository;
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
            IEnumerable<ForbiddenCombination> forbiddenCombinations = forbiddenCombinationRepository
                .GetList()
                .ToList();

            IList<ProductDTO> list = new List<ProductDTO>();

            foreach (var p in products)
            {
                ProductDTO d = new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ProductType = p.ProductType,
                    Combinations = combinations.Where(t => t.ProductFrom.Id == p.Id)
                };

                if (forbiddenCombinations != null && p.ProductType == ProductType.FoodAddition)
                {
                    /*Пусть несочетаемые пары заданы как:
                     (1, 2)
                     (1, 3)
                     (4, 1)
                     ...
                     */

                    /*строим новое отношение для 1 по прямому отношению:
                     (1, 2)
                     (1, 3)
                     */
                    d.ForbiddenCombinations = forbiddenCombinations
                        .Where(t => t.ProductFrom.Id == p.Id);

                    /*достраиваем его по обратному отношению:
                     (4, 1) -> (1, 4)*/
                    IEnumerable<ForbiddenCombination> symmetricForbiddenCombinations = forbiddenCombinations
                        .Where(t => t.ProductTo.Id == p.Id).Select(t => new ForbiddenCombination
                        {
                             ProductFrom = t.ProductTo,
                             ProductTo = t.ProductFrom
                        });
                    d.ForbiddenCombinations = d.ForbiddenCombinations.Union(symmetricForbiddenCombinations);
                }

                list.Add(d);
            }
            Settings settings = settingsRepository.GetList().FirstOrDefault();
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

            if (settings != null)
            {
                assortment.MaxSugarCount = settings.MaxSugarCount;
                assortment.SugarId = settings.Sugar.Id;
            }
            
            return assortment;
        }

        /// <summary>
        /// Подтверждение заказа
        /// </summary>
        public decimal СonfirmOrder(OrderDTO order)
        {
            IEnumerable<Product> products = productRepository
                .GetList(t => order.SelectedProductIds.Contains(t.Id))
                .ToList();

            int countProduct = products.Count(t => t.ProductType == ProductType.Drink || t.ProductType == ProductType.Food);
            if (countProduct == 0)
                throw new DataServiceException(Resource.ExceptionMsg_EmptyOrder);

            if (order.Composition)
            {
                if(countProduct < 2)
                    throw new DataServiceException(Resource.ExceptionMsg_NotCompleteComposition);

                Composition composition = compositionRepository.GetList().FirstOrDefault();
                return composition.Price;
            }

            return products.Sum(p => p.Price);

        }

    }
}
