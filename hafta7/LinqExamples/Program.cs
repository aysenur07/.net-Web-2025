using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        // Öğrenci listemiz
        List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ahmet", Age = 22, Department = "Computer" },
            new Student { Id = 2, Name = "Ayşe", Age = 19, Department = "Math" },
            new Student { Id = 3, Name = "Mehmet", Age = 21, Department = "Computer" },
            new Student { Id = 4, Name = "Zeynep", Age = 20, Department = "Physics" },
            new Student { Id = 5, Name = "Elif", Age = 23, Department = "Math" }
        };
        // LINQ örnekleri
        /*
        var all = students.ToList();
        foreach (var s in all)
            Console.WriteLine($"{s.Id} - {s.Name}");
*/
            /*
         //2. Ornek
        var csStudents = students.Where(s => s.Department == "Computer");
        Console.WriteLine("\nBilgisayar öğrencileri:");
        foreach (var s in csStudents)
            Console.WriteLine(s.Name);
        */

        //3.ornek
        /*
        var ordered = students.OrderBy(s => s.Age);
        Console.WriteLine("\nYaşa göre artan sıra:");
        foreach (var s in ordered)
            Console.WriteLine($"{s.Name} ({s.Age})");
        */
        //4 .örnek
/*
        var names = students.Select(s => s.Name);
        Console.WriteLine("\nSadece isimler:");
        foreach (var n in names)
            Console.WriteLine(n);
        */

        //5.örnek
        /*
        var firstMath = students.FirstOrDefault(s => s.Department == "Math");
        Console.WriteLine($"\nİlk Matematik öğrencisi: {firstMath?.Name}");
        */

        //6.örnek
       /*
        int count = students.Count(s => s.Department == "Computer");
        Console.WriteLine($"\nBilgisayar öğrencisi sayısı: {count}");
        */

        //7.örnek
        /*
        var grouped = students.GroupBy(s => s.Department);
        Console.WriteLine("\nBölümlere göre gruplama:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"📘 {group.Key}: {group.Count()} öğrenci");
            foreach (var s in group)
                Console.WriteLine($"  - {s.Name}");
        }
        */
        //8.örnek
        /*
        Console.WriteLine($"\nOrtalama yaş: {students.Average(s => s.Age)}");
        Console.WriteLine($"En genç yaş: {students.Min(s => s.Age)}");
        Console.WriteLine($"En yaşlı: {students.Max(s => s.Age)}");
       
        //g.key  IGrouping<TKey, TElement>
        var grouped = students.GroupBy(s => s.Department);
        foreach (var g in grouped)
        {
            Console.WriteLine($"Bölüm: {g.Key}");

            foreach (var s in g)
            {
                Console.WriteLine($"  - {s.Name}");
            }
        }
        */
        //9.örnek
        /*
        var deptNames = students
            .GroupBy(s => s.Department)
            .Select(g => new { Department = g.Key, Names = g.Select(x => x.Name).ToList() });

        Console.WriteLine("\nHer bölümün öğrencileri:");
        foreach (var d in deptNames)
        {
            Console.WriteLine($"📚 {d.Department}: {string.Join(", ", d.Names)}");
        }
        */
        //10.örnek
        /*
        List<Course> courses = new()
        {
            new Course { Id = 1, Title = "Algorithms", Department = "Computer" },
            new Course { Id = 2, Title = "Calculus", Department = "Math" },
            new Course { Id = 3, Title = "Physics 1", Department = "Physics" }
        };

        var joined = from s in students
                    join c in courses
                    on s.Department equals c.Department
                    select new { s.Name, c.Title };

        Console.WriteLine("\nÖğrencinin alabileceği bölüm dersi:");
        foreach (var item in joined)
            Console.WriteLine($"{item.Name} → {item.Title}");
        */

        //11.örnek
        /*
        var reverseList = students.OrderBy(s => s.Id).Reverse();
        Console.WriteLine("\nTers liste:");
        foreach (var s in reverseList)
            Console.WriteLine(s.Name);
        
        */
        //12.örnek
        /*
        var depts = students.Select(s => s.Department).Distinct();
        Console.WriteLine("\nTekrarsız bölümler:");
        foreach (var d in depts)
            Console.WriteLine(d);        
        */

        //13.örnek
        /*
        var result =
            from s in students
            where s.Age >= 21
            orderby s.Name
            select new { s.Name, s.Age };

        Console.WriteLine("\n21 yaş üstü öğrenciler:");
        foreach (var r in result)
            Console.WriteLine($"{r.Name} ({r.Age})");

        */
    }
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Department { get; set; } = "";
}

class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Department { get; set; } = "";
}


