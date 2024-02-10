using Microsoft.EntityFrameworkCore;

namespace ZinkovskiyTask
{
    public interface IStudentRepository : IDisposable
    {
        Student GetById(long id);
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Update(long id, Student student);
        void Delete(long id);
        long Count();
        int SaveChanges();
    }

    public class StudentRepository : IStudentRepository
    {
        bool isDisposed = false;
        private SchoolDbContext _context { get; set; }

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            Student st = new Student { Age = student.Age, Name = student.Name };
            _context.Students.Add(st);
            _context.SaveChanges();

            return;
        }

        public void Delete(long id)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
                throw new Exception();

            _context.Students.Remove(existingStudent);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(long id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return null;

            return student;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(long id, Student updatedStudent)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == id);  // Single or SingleOrDefault
            if (existingStudent == null)
                throw new Exception();

            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (isDisposed == false)
            {
                _context.Dispose();
                isDisposed = true;
            }
        }
        public long Count()
        {
            return _context.Students.Count();
        }
    }
}