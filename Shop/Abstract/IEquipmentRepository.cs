using System.Collections.Generic;
using Shop.Entities;

namespace Shop.Abstract
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> Equipments { get; }

        void SaveEquipment(Equipment equipment);

        Equipment DeleteEquipment(int equipmentId);
    }
}
