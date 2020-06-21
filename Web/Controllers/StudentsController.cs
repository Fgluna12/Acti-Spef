using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public StudentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsIdentity>>> Get()
        {
            return await context.Students.ToListAsync();
        }

        [HttpGet("{id}", Name = "Student")]
        public async Task<ActionResult<StudentsIdentity>> Get(int id)
        {
            var Student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Student;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentsIdentity Student)
        {
            context.Add(Student);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("Student", new { id = Student.Id }, Student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentsIdentity Value)
        {
            if (id != Value.Id)
            {
                return BadRequest();
            }
            context.Entry(Value).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<StudentsIdentity> Delete(int id)
        {
            var Student = context.Students.FirstOrDefault(x => x.Id == id);

            if (Student == null)
            {
                return NotFound();
            }

            context.Remove(Student);
            context.SaveChanges();
            return Ok(Student);
        }
    }
}