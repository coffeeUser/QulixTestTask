using System.Collections.Generic;
using System.Linq;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Domain.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ICompanyService companyService;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            companyService = new CompanyService();
        }

        public IActionResult Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            employees = employeeService.GetAll().ToList();
            return View(employees);
        }

        public IActionResult CompanyEmployees(int? id)
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            employees = employeeService.GetCompanyEmployees(id).ToList();
            return View("Index", employees);
        }

        public IActionResult PositionEmployees(string position)
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            employees = employeeService.GetEmployeesByPosition(position).ToList();
            return View("Index", employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Companies = companyService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeViewModel employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Companies = companyService.GetAll();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]EmployeeViewModel employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeViewModel employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeViewModel employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}