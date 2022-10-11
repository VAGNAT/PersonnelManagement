using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Model.ViewModel.Reports;
using Services.Interfaces;

namespace PersonnelManagement.Controllers
{
    public class ReportController : Controller
    {
        private readonly ICRUD<Department> _departmentService;
        private readonly IReport _reportService;

        public ReportController(ICRUD<Department> departmentService, IReport reportService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService), "Parameter can't be null");
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService), "Parameter can't be null");
        }

        [HttpGet]
        public IActionResult All()
        {
            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Generate(ParameterReportEmployeesInDepartment parameterReport)
        {
            if (parameterReport is null)
            {
                return BadRequest();
            }

            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name");
            return View("ReportEmployeesInDepartment", _reportService.GetReportEmployeesInDepartment(parameterReport));
        }
    }
}
