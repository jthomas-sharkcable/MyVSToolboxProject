using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Abstract;
using Shop.Entities;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IEquipmentRepository repository;

        public AdminController(IEquipmentRepository repo)
        {
            repository = repo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Equipments);
        }

        public ViewResult Edit(int equipId)
        {
            Equipment equipment = repository.Equipments
                .FirstOrDefault(e => e.EquipId == equipId);
            return View(equipment);
        }

        [HttpPost]
        public ActionResult Edit(Equipment equipment, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    equipment.ImageMimeType = image.ContentType;
                    equipment.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(equipment.ImageData, 0, image.ContentLength);
                }
                repository.SaveEquipment(equipment);
                TempData["message"] = string.Format("{0} has been saved", equipment.SharkName);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(equipment);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Equipment());
        }

        [HttpPost]
        public ActionResult Delete(int equipId)
        {
            Equipment deletedEquipment = repository.DeleteEquipment(equipId);
            if (deletedEquipment != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedEquipment.SharkName);
            }
            return RedirectToAction("Index");
        }
    }
}