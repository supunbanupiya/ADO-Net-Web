using AspMVCwithADONet.Models;
using AspMVCwithADONet.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspMVCwithADONet.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService _studentService;
		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public IActionResult StudentList()
		{
			AllModel model = new AllModel();

			/*List<Students> StudentsList = new List<Students>();*/
			model.studentList = _studentService.GetStudentsRecord().ToList();
			return View(model);
		}
	}
}
