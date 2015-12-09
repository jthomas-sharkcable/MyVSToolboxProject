using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Abstract;

namespace Shop.Controllers
{
    public class NavController : Controller
    {
        private IEquipmentRepository repository;

        public NavController(IEquipmentRepository repo)
        {
            repository = repo;
        }

        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Equipments
                 .Select(x => x.EquipCategory)
                 .Distinct()
                 .OrderBy(x => x);

            return PartialView(categories);           
        }
    }
}