using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI_Swagger.Model;

namespace RestfulAPI_Swagger.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = Guid.NewGuid(), Name = "A", Age = 18
            },
            new Student()
            {
                Id = Guid.NewGuid(), Name = "B", Age = 20
            },
            new Student()
            {
                Id = Guid.NewGuid(), Name = "C", Age = 59
            }
        };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(String id)
        {
            var student = students.SingleOrDefault(x => x.Id.ToString() == id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                var stu = new Student
                {
                    Age = student.Age,
                    Id = Guid.NewGuid(),
                    Name = student.Name
                };
                students.Add(stu);
                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            var student = students.SingleOrDefault(x => x.Id.ToString() == id);
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                return Ok(students.Remove(student));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Student student)
        {
            var foundstu = students.SingleOrDefault(x => x.Id.ToString() == id);
            try
            {
                if (foundstu == null)
                {
                    return BadRequest();
                }
                foundstu.Age = student.Age;
                foundstu.Name = student.Name;
                throw new InvalidOperationException();
                return Ok(foundstu);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        private readonly string[] AllowImage = new[] { ".jpg", ".jpeg", ".png" };
        [HttpPost("upload")]
        public IActionResult UploadImage(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return BadRequest("Tập tin không được gửi");
            }
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowImage.Contains(fileExtension))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Định dạng tập tin không được hỗ trợ");
            }
            return NoContent();
        }
    }
}
