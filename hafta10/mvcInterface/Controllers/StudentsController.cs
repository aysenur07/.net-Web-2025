using mvcInterface.Repositories;
using mvcInterface.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class StudentsController : Controller
{
    private readonly IStudentRepository _repo;

    public StudentsController(IStudentRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var students = _repo.GetAll();

        var vm = students.Select(s => new StudentCourseVm
        {
            Name = s.Name,
            Age = s.Age,
            CourseName = s.Course?.Name ?? ""
        }).ToList();

        return View(vm);
    }

    //Öğrenci ekleme formu (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        //Form post edildiğinde (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _repo.Add(model);
            _repo.Save();

            return RedirectToAction(nameof(Index));
        }
}
