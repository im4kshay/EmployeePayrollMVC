using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager EmployeeManager;
        public EmployeeController(IEmployeeManager EmployeeManager)
        {
            this.EmployeeManager = EmployeeManager;
        }
        // Show employee list
        public IActionResult ListOfEmployee()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();
            allEmployees = EmployeeManager.GetAllEmployees().ToList();
            return View(allEmployees);
        }

        // Add new employee

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeManager.AddEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }

        // Update employee details
        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeManager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                EmployeeManager.UpdateEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }

        //details of a particular employee
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeManager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Delete Employee 
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeManager.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteConfirmed(int? id)
        {
            EmployeeManager.DeleteEmployee(id);
            return RedirectToAction("ListOfEmployee");
        }
    }
}
