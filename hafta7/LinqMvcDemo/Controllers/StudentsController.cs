using LinqMvcDemo.Models;
using LinqMvcDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LinqMvcDemo.Controllers;

public class StudentsController : Controller
{
    // In-memory demo verisi
    private static readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Ahmet",  Age = 22, Department = "Computer" },
        new Student { Id = 2, Name = "Ayşe",   Age = 19, Department = "Math" },
        new Student { Id = 3, Name = "Mehmet", Age = 21, Department = "Computer" },
        new Student { Id = 4, Name = "Zeynep", Age = 20, Department = "Physics" },
        new Student { Id = 5, Name = "Elif",   Age = 23, Department = "Math" },
        new Student { Id = 6, Name = "Kerem",  Age = 24, Department = "Computer" },
    };

    // 1) WHERE + ORDERBY: bölüm filtresi (opsiyonel) + isme göre sıralama
    // /Students?dept=Computer
    public IActionResult Index(string? dept)
    {
        var query = _students.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(dept))
            query = query.Where(s => s.Department.Equals(dept, StringComparison.OrdinalIgnoreCase));

        var model = query
            .OrderBy(s => s.Name)  // alfabetik
            .ToList();

        ViewBag.SelectedDept = dept;
        ViewBag.AllDepts = _students.Select(s => s.Department).Distinct().OrderBy(d => d).ToList();
        return View(model);
    }

    // 2) ORDERBYDESC + TAKE + SELECT (projeksiyon): en yaşlı N öğrenci
    // /Students/Top?count=3
    public IActionResult Top(int count = 3)
    {
        if (count <= 0) count = 3;

        var model = _students
            .OrderByDescending(s => s.Age)
            .Take(count)
            .Select(s => new { s.Name, s.Age, s.Department })
            .ToList();

        ViewBag.Count = count;
        return View(model);
    }

    // 3) GROUPBY + COUNT + AVERAGE: bölüm bazında özet
    // /Students/Summary
    public IActionResult Summary()
    {
        var model = _students
            .GroupBy(s => s.Department)
            .Select(g => new DepartmentSummaryVm
            {
                Department = g.Key,
                Count = g.Count(),
                AverageAge = g.Average(x => x.Age)
            })
            .OrderBy(x => x.Department)
            .ToList();

        return View(model);
    }
}
