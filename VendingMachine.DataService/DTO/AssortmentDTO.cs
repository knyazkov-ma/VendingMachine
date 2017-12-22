using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
    /// <summary>
    /// Ассортимент
    /// </summary>
    public class AssortmentDTO
    {
        /// <summary>
        /// Еда
        /// </summary>
        public AssortmentGroupDTO FoodGroup { get; set; }

        /// <summary>
        /// Добавки к еде
        /// </summary>
        public AssortmentGroupDTO FoodAdditionGroup{ get; set; }

        /// <summary>
        /// Напитки
        /// </summary>
        public AssortmentGroupDTO DrinkGroup { get; set; }

        /// <summary>
        /// Добавки к напиткам
        /// </summary>
        public AssortmentGroupDTO DrinkAdditionGroup { get; set; }

        /// <summary>
        /// Набор
        /// </summary>
        public Composition Composition { get; set; }
    }
}