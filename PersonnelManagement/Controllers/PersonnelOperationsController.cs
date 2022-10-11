using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Model.Helpers;
using Model.ViewModel;
using Services.Interfaces;

namespace PersonnelManagement.Controllers
{
    public class PersonnelOperationsController : Controller
    {
        private readonly ICRUD<Employee> _employeeService;
        private readonly ICRUD<Department> _departmentService;
        private readonly ICRUD<PersonnelMovements> _personnelMovements;
        private readonly IMapper _mapper;

        public PersonnelOperationsController(ICRUD<Employee> employeeService, ICRUD<Department> departmentService,
            ICRUD<PersonnelMovements> personnelMovements, IMapper mapper)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService), "Parameter can't be null");
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService), "Parameter can't be null");
            _personnelMovements = personnelMovements ?? throw new ArgumentNullException(nameof(personnelMovements), "Parameter can't be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Parameter can't be null");
        }

        [HttpGet]
        public IActionResult All() => View();

        [HttpGet]
        public IActionResult Recruitment()
        {
            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name");

            var employees = _employeeService.GetAll();
            ViewBag.AllEmployees = new SelectList(employees, "Id", "Presentation");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Recruitment(Recruitment recruitment)
        {
            if (recruitment is null)
            {
                return BadRequest();
            }

            var recruitingMovement = _mapper.Map<PersonnelMovements>(recruitment);
            await _personnelMovements.CreateAsync(recruitingMovement);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Dismissal()
        {
            var employees = _employeeService.GetAll();
            ViewBag.AllEmployees = new SelectList(employees, "Id", "Presentation");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Dismissal(Dismissal dismissal)
        {
            if (dismissal is null)
            {
                return BadRequest();
            }


            var dismissalMovement = _personnelMovements.GetAll().Where(p => p.EmployeeId == dismissal.EmployeeId & p.DateStart < dismissal.Date).FirstOrDefault();
            if (dismissalMovement is null)
            {
                return NotFound(); //нет сотрудника работающего
            }

            dismissalMovement.DateEnd = dismissal.Date;
            await _personnelMovements.UpdateAsync(dismissalMovement);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name");

            var employees = _employeeService.GetAll();
            ViewBag.AllEmployees = new SelectList(employees, "Id", "Presentation");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Transfer(Transfer transfer)
        {
            if (transfer is null)
            {
                return BadRequest();
            }

            var oldDepartment = _personnelMovements.GetAll().Where(p => p.EmployeeId == transfer.EmployeeId && p.DateStart < transfer.Date & p.DateEnd == DateTime.MinValue).FirstOrDefault();
            if (oldDepartment is null)
            {
                return NotFound(); //нет сотрудника работающего
            }

            oldDepartment.DateEnd = transfer.Date;
            await _personnelMovements.UpdateAsync(oldDepartment);

            var newDepartment = _mapper.Map<PersonnelMovements>(transfer);

            await _personnelMovements.CreateAsync(newDepartment);

            return RedirectToAction(nameof(All));
        }
    }
}

