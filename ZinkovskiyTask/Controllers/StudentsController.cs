using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using ZinkovskiyTask.ZinkovskiyTask.Services;
using ZinkovskiyTask.DTO;
using ZinkovskiyTask.DTO.Converters;

namespace ZinkovskiyTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student_DTO> GetStudentById(long id)
        {
            var student = _studentService.GetStudentById(id);
            var response = new ObjectResult(student.Data.ToStudent());
            response.StatusCode = student.StatusCode;
            return response;
        }

        [HttpPost]
        public ActionResult<Student_DTO> CreateStudent(StudentAddUpdate_DTO newSt)
        {
            var new_student = _studentService.AddStudent(newSt);
            return Ok(new_student);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(long id, StudentAddUpdate_DTO updatedStudent)
        {
            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
                return NotFound();

            _studentService.UpdateStudent(id, updatedStudent);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(long id)
        {
            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
                return NotFound();

            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
