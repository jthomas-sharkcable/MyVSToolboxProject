using System.Collections.Generic;
using Shop.Entities;

namespace Shop.Models
{
    public class EquipmentsListViewModel
    {
        public IEnumerable<Equipment> Equipments { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
