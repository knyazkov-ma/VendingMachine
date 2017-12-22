namespace VendingMachine.Entity
{
    /// <summary>
    /// Комбинация продукта
    /// </summary>
    public class Combination : BaseEntity
    {
        /// <summary>
        /// Продукт, который комбинируется
        /// </summary>
        public Product ProductFrom { get; set; }


        /// <summary>
        /// Продукт, с которым комбинируется
        /// </summary>
        public Product ProductTo { get; set; }

        /// <summary>
        /// Обязательность комбинации (означает, что продукт состоит из обязательных частей)
        /// </summary>
        public bool Required { get; set; }
    }
}
