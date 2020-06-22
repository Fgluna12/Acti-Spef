using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Identities;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsContrller : ControllerBase
    {

        private readonly DataContext context;


        public StudentsContrller(DataContext context)
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
            var Student = await context.Students.FirstOrDefaultAsync(x => x.id == id);

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
            return new CreatedAtRouteResult("Student", new { id = Student.id }, Student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentsIdentity Value)
        {
            if (id != Value.id)
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
            var Student = context.Students.FirstOrDefault(x => x.id == id);

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