namespace VendingMachine.Entity
{
    /// <summary>
    /// Продукт (напитки, еда, и т.п.)
    /// </summary>
    public class Product: BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Для сортировки в UI
        /// </summary>
        public int Ord { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType ProductType { get; set; }

        
    }
}
