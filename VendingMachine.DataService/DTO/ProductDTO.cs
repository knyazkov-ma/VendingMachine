using System.Collections.Generic;
using VendingMachine.DataService.Helpers;
using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
    /// <summary>
    /// Продукт с учетом возможной (или необходимой) комбинации его с добавками
    /// </summary>
    public class ProductDTO
    {
        public long Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType ProductType { get; set; }
                
        /// <summary>
        /// Максимальное количество единиц. продукта за 1 заказ
        /// </summary>
        public int MaxCountPerOrder { get; set; }

        /// <summary>
        /// Комбинации с добавками
        /// </summary>
        public IEnumerable<Combination> Combinations { get; set; }

    }
}
