using mvcInterface.Models;

namespace mvcInterface.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        IEnumerable<Student> GetByCourse(int courseId);
        void Add(Student s);
        void Delete(int id);
        void Save();
    }
}
