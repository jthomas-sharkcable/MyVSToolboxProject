using System;
using System.Collections.Generic;
using Shop.Abstract;
using Shop.Concrete;
using Shop.Entities;

namespace Shop.Concrete
{
    public class EFEquipmentRepository : IEquipmentRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return context.Equipments;
            }
        }

        public void SaveEquipment(Equipment equipment)
        {
            if (equipment.EquipId == 0)
            {
                context.Equipments.Add(equipment);
            }
            else
            {
                Equipment dbEntry = context.Equipments.Find(equipment.EquipId);
                if (dbEntry != null)
                {
                    dbEntry.SharkName = equipment.SharkName;
                    dbEntry.EquipDescription = equipment.EquipDescription;
                    dbEntry.EquipCategory = equipment.EquipCategory;
                    dbEntry.EquipColor = equipment.EquipColor;
                    dbEntry.EquipMake = equipment.EquipMake;
                    dbEntry.EquipModel = equipment.EquipModel;
                    dbEntry.EquipYear = equipment.EquipYear;
                    dbEntry.EquipVin = equipment.EquipVin;
                    dbEntry.EquipLocation = equipment.EquipLocation;
                    dbEntry.ImageData = equipment.ImageData;
                    dbEntry.ImageMimeType = equipment.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Equipment DeleteEquipment(int equipId)
        {
            Equipment dbEntry = context.Equipments.Find(equipId);
            if (dbEntry != null)
            {
                context.Equipments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
