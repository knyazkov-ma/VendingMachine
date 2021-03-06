﻿using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
    /// <summary>
    /// Ассортимент, который виден в UI
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
        /// Набор, идущий по фиксированной цене
        /// </summary>
        public Composition Composition { get; set; }

        /// <summary>
        /// Максимальное количество кусочков сахара
        /// </summary>
        public int MaxSugarCount { get; set; }

        /// <summary>
        /// Id продукта "сахар"
        /// </summary>
        public long SugarId { get; set; }
    }
}