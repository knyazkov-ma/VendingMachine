namespace VendingMachine.Entity
{
    /// <summary>
    /// Настройки (здесь только настройки для максимального количества кусочков сахара)
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
