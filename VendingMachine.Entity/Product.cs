namespace VendingMachine.Entity
{
    /// <summary>
    /// Тип продукта
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// Еда
        /// </summary>
        Food = 0,

        /// <summary>
        /// Добавка к еде
        /// </summary>
        FoodAddition = 1,

        /// <summary>
        /// Напиток
        /// </summary>
        Drink = 2,

        /// <summary>
        /// Добавка к напитку
        /// </summary>
        DrinkAddition = 3
    }

    /// <summary>
    /// Продукт
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

        /// <summary>
        /// Максимальное количество единиц. продукта за 1 заказ
        /// </summary>
        public int MaxCountPerOrder { get; set; }
    }
}
