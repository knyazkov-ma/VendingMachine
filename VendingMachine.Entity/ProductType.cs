using System.ComponentModel.DataAnnotations;
using VendingMachine.Entity.Resources;

namespace VendingMachine.Entity
{
    /// <summary>
    /// Тип продукта
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// Напиток
        /// </summary>
        [Display(Name = "ProductType_Drink", ResourceType = typeof(Resource))]
        Drink = 0,

        /// <summary>
        /// Добавка к напитку
        /// </summary>
        [Display(Name = "ProductType_DrinkAddition", ResourceType = typeof(Resource))]
        DrinkAddition = 1,

        /// <summary>
        /// Еда
        /// </summary>
        [Display(Name = "ProductType_Food", ResourceType = typeof(Resource))]
        Food = 2,

        /// <summary>
        /// Добавка к еде
        /// </summary>
        [Display(Name = "ProductType_FoodAddition", ResourceType = typeof(Resource))]
        FoodAddition = 3

    }
}
