using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StudentRestAPI.Model;
using System.Reflection.Metadata.Ecma335;



namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {

            var result = await _studentRepository.Search(name, gender);
            if(result.Any())
            {
                return Ok(result);
            }
            return NotFound();
            }
            catch(Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetStudent()
        {
            try
            {
                return Ok(await _studentRepository.GetStudents());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Student>> GetStudent(Guid studentId)
        {
            try
            {
                var result = await _studentRepository.GetStudent(studentId);
                if (result != null) return result;
                return NotFound();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null) return BadRequest();
                var studentEmail = await _studentRepository.GetStudentByEmail(student.Email);
                if (studentEmail != null)
                {
                    ModelState.AddModelError("Email", "Student Email already Exists.");
                    return BadRequest();
                }
                var createdStudent = await _studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.StudentId }, createdStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error executing add to database.");
            }
        }

        [HttpPost("{id:Guid}")]
        public async Task<ActionResult<Student>> UpdateStudent(Guid id, Student student)
        {
            try
            {
                if (id != null) return BadRequest("Student Id does not exists.");
                var studentUpdate = await _studentRepository.GetStudent(id);
                if (studentUpdate == null) return NotFound($"Student id {id} does not exists.");
                return await _studentRepository.UpdateStudent(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error executing update to database.");
            }
        }

        [HttpPost("{id:Guid}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var studentToDelete = await _studentRepository.GetStudent(id);
                if (studentToDelete == null) return NotFound($"Student Id {id} does not exists.");
                await _studentRepository.DeleteStudent(id);
                return Ok($"Student id {id} deleted.");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error executing delete to database.");
            }
        }
    }
}
