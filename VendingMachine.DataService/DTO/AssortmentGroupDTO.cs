using System.Collections.Generic;
using VendingMachine.DataService.Helpers;
using VendingMachine.Entity;

namespace VendingMachine.DataService.DTO
{
    public class AssortmentGroupDTO
    {
        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Наименование тип продукта
        /// </summary>
        public string ProductTypeName
        {
            get
            {
                return ProductType.GetDisplayName();
            }
        }

        /// <summary>
        /// Продукты
        /// </summary>
        public IEnumerable<ProductDTO> Items { get; set; }
    }
}
