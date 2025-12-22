using Microsoft.AspNetCore.Mvc;
using StudentMvcApp.Models;
namespace StudentMvcApp.Controllers;
public class StudentsController : Controller
{
    private static readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Ahmet",  Age = 20 },
        new Student { Id = 2, Name = "Ayşe",   Age = 21 },
        new Student { Id = 3, Name = "Mehmet", Age = 22 }
    };
    public IActionResult Index()
    {        
        return View(_students);    
    }

    // GET: /Students/Create
[HttpGet]
public IActionResult Create()
{
     return View(new Student());
}

// POST: /Students/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Student model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    // Id vermek için 
    int newId = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
    model.Id = newId;
    _students.Add(model);
    return RedirectToAction(nameof(Index));
}

}