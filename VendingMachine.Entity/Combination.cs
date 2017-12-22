namespace VendingMachine.Entity
{
    /// <summary>
    /// Комбинация продуктов/добавок
    /// </summary>
    public class Combination : BaseEntity
    {
        /// <summary>
        /// Продукт, который комбинируется
        /// </summary>
        public Product ProductFrom { get; set; }


        /// <summary>
        /// Продукт/добавка, с которым комбинируется
        /// </summary>
        public Product ProductTo { get; set; }

        /// <summary>
        /// Обязательность комбинации (означает, что продукт состоит из обязательных частей)
        /// </summary>
        public bool Required { get; set; }
    }
}
