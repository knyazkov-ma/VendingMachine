namespace VendingMachine.Entity
{
    /// <summary>
    /// Набор
    /// </summary>
    public class Composition : BaseEntity
    {
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Note { get; set; }
    }
}
