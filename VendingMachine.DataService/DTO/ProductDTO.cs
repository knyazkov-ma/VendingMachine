using System.Collections.Generic;
using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
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
        /// Наименование тип продукта
        /// </summary>
        public string ProductTypeName { get; set; }

        /// <summary>
        /// Максимальное количество единиц. продукта за 1 заказ
        /// </summary>
        public int MaxCountPerOrder { get; set; }

        public IEnumerable<Combination> Combinations { get; set; }
    }
}
