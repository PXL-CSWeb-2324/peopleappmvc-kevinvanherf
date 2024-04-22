using Microsoft.AspNetCore.Mvc;
using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Services.Interfaces;

namespace PeopleApp.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository _DepartmentRepository;
        public DepartmentController (IDepartmentRepository departmentRepository)
        {
            _DepartmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _DepartmentRepository.get();
            if(result.Succeeded)
            {
                return View(result.Entiteis);
            }
            return View(Enumerable.Empty<Department>());
        }
    }
}
