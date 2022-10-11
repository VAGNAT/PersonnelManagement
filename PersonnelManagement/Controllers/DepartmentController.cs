using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Services.Interfaces;

namespace PersonnelManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ICRUD<Department> _departmentService;

        public DepartmentController(ICRUD<Department> departmentService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService), "Parameter can't be null");
        }

        [HttpGet]
        public ActionResult All() => View(_departmentService.GetAll());

        [HttpGet]
        public ActionResult Add()
        {
            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Department department)
        {
            if (department is null)
            {
                return BadRequest();
            }

            await _departmentService.CreateAsync(department);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<ActionResult> Change(int id)
        {
            Department? department = await _departmentService.GetAsync(id);
            if (department is null)
            {
                return BadRequest();
            }
            var departments = _departmentService.GetAll();
            ViewBag.AllDepartments = new SelectList(departments, "Id", "Name", department.GroupDepartmentId);
            return View(department);
        }

        [HttpPost]
        public async Task<ActionResult> Change(Department department)
        {
            if (department is null)
            {
                return BadRequest();
            }

            await _departmentService.UpdateAsync(department);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
