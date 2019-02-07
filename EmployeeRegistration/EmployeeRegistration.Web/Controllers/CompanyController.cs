using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Web.Controllers
{
    public class CompanyController : Controller
    {
        CompanyRepository companyRepository = new CompanyRepository();

        public IActionResult Index()
        {
            List<Company> companies = new List<Company>();
            companies = companyRepository.GetAllCompanies().ToList();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Company company)
        {
            if (ModelState.IsValid)
            {
                companyRepository.AddCompany(company);
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
            Company company = companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                companyRepository.UpdateCompany(company);
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
            Company company = companyRepository.GetCompany(id);
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
            Company company = companyRepository.GetCompany(id);
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
            companyRepository.DeleteCompany(id);
            return RedirectToAction("Index");
        }
    }
}