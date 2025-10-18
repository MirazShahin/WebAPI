using BasicStudentApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BasicStudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> student_info = new List<Student>
        {
            new Student{id = "22235103117", Name = "Md Miraz Hossain Shahin", Intake = 51, Mail = "abc@gmail.com", contactNumber = "12345678901"},
            new Student{id = "22235103118", Name = "Md Arif Khan", Intake = 51, Mail = "efg@gmail.com", contactNumber = "12345678906"},
            new Student{id = "22235103119", Name = "ancdef", Intake = 51, Mail = "xyq@gmail.com", contactNumber = "12345678905"},
            new Student{id = "22235103120", Name = "abcjasbdcfgh", Intake = 51, Mail = "efg@gmail.com", contactNumber = "12345678904"},
            new Student{id = "22235103121", Name = "Miraz Hossain Shahin", Intake = 51, Mail = "abc@gmail.com", contactNumber = "12345678903"},
            new Student{id = "22235103122", Name = "Md Arif Khan", Intake = 51, Mail = "efg@gmail.com", contactNumber = "12345678902"}
        };

        [HttpGet]
        public IActionResult seeAllData()
        {
            return Ok(student_info);
        }
        [HttpGet("id")]
        public IActionResult seeById(string ID)
        {
            var sInfo = from s in student_info where s.id == ID select s;
            if(!sInfo.Any())
            {
                return NotFound($"No student found of that id: {ID}");
            }
            return Ok(sInfo);
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            student_info.Add(newStudent);
            return Ok(newStudent.Name);
        }

        [HttpPut("id")]
        public IActionResult UpdateStudent(String ID,  Student update)
        {
            var person = (from s in student_info where s.id == ID select s).FirstOrDefault();
            if(person == null)
            {
                return NotFound($"Student not found of this id {ID}");
            }
            person.Name = update.Name;
            person.Mail = update.Mail;
            person.contactNumber = update.contactNumber;
            return Ok(person);
        }
        [HttpDelete("id")]
        public IActionResult DeleteStudent(string ID)
        {
            var person = (from s in student_info where s.id == ID select s).FirstOrDefault();
            if(person == null )
            {
                return NotFound($"No Student found of that id: {ID}");
            }
            student_info.Remove(person);
            return Ok("Deleted successfully");
        }
     }
}
