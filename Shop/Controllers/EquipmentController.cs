using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Abstract;
using Shop.Entities;
using Shop.Models;

namespace Shop.Controllers
{
    public class EquipmentController : Controller
    {
        private IEquipmentRepository repository;
        public int PageSize = 8;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            this.repository = equipmentRepository;
        }

        // GET: Equipment
        public ViewResult List(string category, int page = 1)
        {
            EquipmentsListViewModel model = new EquipmentsListViewModel
            {
                Equipments = repository.Equipments
                .Where(p => category == null || p.EquipCategory == category)
                .OrderBy(p => p.SharkName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Equipments.Count() :
                        repository.Equipments.Where(e => e.EquipCategory == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int equipId)
        {
            Equipment equip = repository.Equipments
                .FirstOrDefault(e => e.EquipId == equipId);
            if (equip != null)
            {
                return File(equip.ImageData, equip.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}