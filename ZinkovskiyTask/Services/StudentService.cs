using Microsoft.AspNetCore.Mvc;
using ZinkovskiyTask.DTO;
using ZinkovskiyTask.DTO.Converters;
using ZinkovskiyTask.Response;

namespace ZinkovskiyTask
{
    public interface IStudentService
    {
        IEnumerable<Student_DTO> GetAllStudents();
        BaseResponse GetStudentById(long id);
        void AddStudent(StudentAddUpdate_DTO student);
        void UpdateStudent(long id, StudentAddUpdate_DTO student);
        void DeleteStudent(long id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _context_students_repository;

        public StudentService(IStudentRepository context)
        {
            _context_students_repository = context;
        }

        public IEnumerable<Student_DTO> GetAllStudents()
        {
            var list_students = _context_students_repository.GetAll();
            var list_students_dto = new List<Student_DTO>();

            foreach (var student in list_students)
            {
                list_students_dto.Add(student.ToStudentDTO());
            }

            return list_students_dto;
        }

        public BaseResponse GetStudentById(long id)
        {
            var student = _context_students_repository.GetById(id);
            if(student == null)
            {
                var response = new BaseResponse(null, 404);
                return response;
            }
            return new BaseResponse(student.ToStudentDTO(), 200);   //ToStudentDTO();
        }

        public void AddStudent(StudentAddUpdate_DTO student)
        {
            var st = student.ToStudent();
            _context_students_repository.Add(st);
            _context_students_repository.SaveChanges();
        }

        public void UpdateStudent(long id, StudentAddUpdate_DTO student)
        {
            _context_students_repository.Update(id, student.ToStudent());
            _context_students_repository.SaveChanges();
        }

        public void DeleteStudent(long id)
        {
            var studentToDelete = _context_students_repository.GetById(id);
            if (studentToDelete != null)
            {
                _context_students_repository.Delete(id);
                _context_students_repository.SaveChanges();
            }
        }

    }
}
