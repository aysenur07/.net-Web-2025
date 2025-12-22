using System.ComponentModel.DataAnnotations;
namespace StudentMvcApp.Models;
public class Student
{
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Range(18, 100)]
    public int Age { get; set; }
}