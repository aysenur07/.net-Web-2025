using Microsoft.EntityFrameworkCore;

using mvcInterface.Data;
using mvcInterface.Models;

namespace mvcInterface.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) => _context = context;

        public IEnumerable<Student> GetAll()
            => _context.Students.Include(s => s.Course).OrderBy(s => s.Name).ToList();

        public Student? GetById(int id)
            => _context.Students.Include(s => s.Course).FirstOrDefault(s => s.Id == id);

        public IEnumerable<Student> GetByCourse(int courseId)
            => _context.Students.Where(s => s.CourseId == courseId).ToList();

        public void Add(Student s)
        {
            _context.Students.Add(s);
        }

        public void Delete(int id)
        {
            var s = _context.Students.Find(id);
            if (s != null) _context.Students.Remove(s);
        }

        public void Save() => _context.SaveChanges();
    }
}
