using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shop.Entities
{
    public class Equipment
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EquipId { get; set; }

        [Required(ErrorMessage = "Please enter SharkName")]
        public string SharkName { get; set; }

        [Required(ErrorMessage = "Please enter EquipDescription")]
        [DataType(DataType.MultilineText)]
        public string EquipDescription { get; set; }

        [Required(ErrorMessage = "Please enter EquipVin")]
        public string EquipVin { get; set; }

        [Required(ErrorMessage = "Please enter EquipYear")]
        public string EquipYear { get; set; }
        
        [Required(ErrorMessage = "Please enter EquipMake")]
        public string EquipMake { get; set; }

        [Required(ErrorMessage = "Please enter EquipModel")]
        public string EquipModel { get; set; }

        [Required(ErrorMessage = "Please enter EquipCategory")]
        public string EquipCategory { get; set; }

        [Required(ErrorMessage = "Please enter EquipColor")]
        public string EquipColor { get; set; }

        [Required(ErrorMessage = "Please enter EquipLocation")]
        public string EquipLocation { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
