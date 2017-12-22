namespace VendingMachine.Entity
{
    /// <summary>
    /// Запрещённая комбинация (например, ветчина и джем) для добавок
    /// </summary>
    public class ForbiddenCombination : BaseEntity
    {
        /// <summary>
        /// Добавка, которая комбинируется
        /// </summary>
        public Product ProductFrom { get; set; }


        /// <summary>
        /// Добавка, с которой комбинируется
        /// </summary>
        public Product ProductTo { get; set; }
    }
}
