using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Interfaces;

namespace PersonnelManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ICRUD<Employee> _employeeService;

        public EmployeeController(ICRUD<Employee> employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService), "Parameter can't be null");
        }

        [HttpGet]
        public ActionResult All() => View(_employeeService.GetAll());

        [HttpGet]
        public ActionResult Add() => View();

        [HttpPost]
        public async Task<ActionResult> Add(Employee employee)
        {
            if (employee is null)
            {
                return BadRequest();
            }
            await _employeeService.CreateAsync(employee);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<ActionResult> Change(int id) => View(await _employeeService.GetAsync(id));

        [HttpPost]
        public async Task<ActionResult> Change(Employee employee)
        {
            if (employee is null)
            {
                return BadRequest();
            }

            await _employeeService.UpdateAsync(employee);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
