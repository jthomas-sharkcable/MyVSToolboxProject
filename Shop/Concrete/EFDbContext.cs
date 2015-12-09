using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Entities;

namespace Shop.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        
    }
}
