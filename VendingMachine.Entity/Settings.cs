namespace VendingMachine.Entity
{
    /// <summary>
    /// Настройки
    /// </summary>
    public class Settings : BaseEntity
    {
        /// <summary>
        /// Максимальное количество кусочков сахара
        /// </summary>
        public int MaxSugarCount { get; set; }

        /// <summary>
        /// Сахар
        /// </summary>
        public Product Sugar { get; set; }
    }
}
