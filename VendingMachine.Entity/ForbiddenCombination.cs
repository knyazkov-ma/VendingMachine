namespace VendingMachine.Entity
{
    /// <summary>
    /// Запрещённая комбинация (например, "ветчина и джем") для добавок. 
    /// Отношение симметричное, но в БД хранится только одна пара. 
    /// Например, если есть (1, 2), то (2, 1) не храним
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
