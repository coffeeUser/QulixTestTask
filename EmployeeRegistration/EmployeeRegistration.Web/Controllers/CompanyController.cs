using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Domain.Services;
using EmployeeRegistration.Domain.Services.Services;
using EmployeeRegistration.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IFormService formService;

        public CompanyController()
        {
            companyService = new CompanyService();
            formService = new FormService();
        }

        public IActionResult Index()
        {
            List<CompanyViewModel> companies = new List<CompanyViewModel>();
            companies = companyService.GetAll().ToList();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Forms = SelectHelper.GetForms();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                companyService.Add(company);
                SelectHelper.Companies = null;
                return RedirectToAction("Index");
            }
            ViewBag.Forms = SelectHelper.GetForms();
            return View(company);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CompanyViewModel company = companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Forms = SelectHelper.GetForms();
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]CompanyViewModel company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                companyService.Update(company);
                return RedirectToAction("Index");
            }
            ViewBag.Forms = SelectHelper.GetForms();
            return View(company);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CompanyViewModel company = companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CompanyViewModel company = companyService.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            companyService.Delete(id);
            SelectHelper.Companies = null;
            return RedirectToAction("Index");
        }
    }
}