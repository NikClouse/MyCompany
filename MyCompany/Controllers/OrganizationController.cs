using Microsoft.AspNetCore.Mvc;
using MyCompany.Interfaceis;
using MyCompany.Models;

namespace MyCompany.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganization organization;

        public OrganizationController(IOrganization organization)
        {
            this.organization = organization;
        }

        // GET: Organization
        public IActionResult Index()
        {
            var organizations = organization.GetAll();
            return View(organizations);
        }



        // Метод действия для отображения страницы добавления организации
        public IActionResult Create()
        {
            return View();
        }

        // Метод действия для обработки добавления организации
        [HttpPost]
        public IActionResult Create(Organization org)
        {
            organization.Add(org);
            return RedirectToAction("Index", "Organization");

        }

        public IActionResult Edit(Guid productId)
        {
            var product = organization.GetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Organization product)
        {
            if (!ModelState.IsValid)
            {

                return View(product);
            }

            organization.Update(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            organization.Remove(productId);
            return RedirectToAction(nameof(Index));
        }



    }

}
