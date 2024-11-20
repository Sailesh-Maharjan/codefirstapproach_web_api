using codefirst_web_api.Models;
using codefirst_web_api.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace codefirst_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        public readonly studentDbContext Context;

        public studentController(studentDbContext context) // dependency injection
        {
            Context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<student> Get()
        {
            return Context.students;
        }

        // GET api/<studentController>/5
        [HttpGet("{id}")]
        public student Get(int id)
        {
            var stu=Context.students.FirstOrDefault(item=> item.Id == id); //LINQ operation 
            return stu;
        }

        // POST api/<studentController>
        [HttpPost]
        public void Post([FromBody] student stu)
        {
            Context.students.Add(stu);
            Context.SaveChanges();


        }

        // PUT api/<studentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] student stu)
        {
            var stud = Context.students.FirstOrDefault(item => item.Id == id); //LINQ operation 
            stud.Name=stu.Name;
            stud.Department=stu.Department;
            stud.Age=stu.Age;
            Context.students.Update(stud);
            Context.SaveChanges();
        }

        // DELETE api/<studentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var stu = Context.students.FirstOrDefault(item => item.Id == id); //LINQ operation 
            Context.students.Remove(stu);
            Context.SaveChanges();

        }
    }
}
