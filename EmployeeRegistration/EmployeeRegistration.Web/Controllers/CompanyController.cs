using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Domain.Services.Services;
using EmployeeRegistration.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService companyService;

        public CompanyController()
        {
            companyService = new CompanyService();
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                companyService.Add(company);
                return RedirectToAction("Index");
            }
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
            return RedirectToAction("Index");
        }
    }
}