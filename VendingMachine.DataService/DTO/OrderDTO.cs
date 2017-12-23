using System.Collections.Generic;

namespace VendingMachine.DataService.DTO
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderDTO
    {
        /// <summary>
        /// ID выбранных продуктов (еда, добавки к еде, напитки, добавки к напиткам)
        /// </summary>
        public IEnumerable<long> SelectedProductIds { get; set; }

        /// <summary>
        /// Выбран ли набор
        /// </summary>
        public bool Composition { get; set; }

        /// <summary>
        /// Выбранное количество кусочков сахара (если сахер выбран, его Id содержится в SelectedProductIds)
        /// </summary>
        public int SugarCount { get; set; }
    }
}
