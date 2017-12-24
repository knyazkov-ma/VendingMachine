using System.Collections.Generic;
using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
    /// <summary>
    /// Продукт с учетом возможной (или необходимой) комбинации его с добавками 
    /// (добавки между собой не должны сочетаться в запрещенных сочетаниях)
    /// </summary>
    public class ProductDTO
    {
        public long Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование с добавками (например, хлеб + ветчина = бутерброт (хлеб + ветчина)) 
        /// </summary>
        public string TransformationName { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType ProductType { get; set; }
                
        /// <summary>
        /// Разрешенные комбинации с добавками (некоторые - обязательные)
        /// </summary>
        public IEnumerable<Combination> Combinations { get; set; }

        /// <summary>
        /// Запрещённые сочетания добавок между собой
        /// </summary>
        public IEnumerable<ForbiddenCombination> ForbiddenCombinations { get; set; }

    }
}
