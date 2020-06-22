using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Infrastructure.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class TeachersController : ControllerBase
    {

        private readonly DataContext context;


        public TeachersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachersIdentity>>> Get()
        {
            return await context.Teachers.ToListAsync();
        }

        [HttpGet("{id}", Name = "Teacher")]
        public async Task<ActionResult<TeachersIdentity>> Get(int id)
        {
            var Teacher = await context.Teachers.FirstOrDefaultAsync(x => x.id == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Teacher;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TeachersIdentity Teacher)
        {
            context.Add(Teacher);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("Teacher", new { id = Teacher.id }, Teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeachersIdentity Value)
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
        public ActionResult<TeachersIdentity> Delete(int id)
        {
            var Teacher = context.Teachers.FirstOrDefault(x => x.id == id);

            if (Teacher == null)
            {
                return NotFound();
            }

            context.Remove(Teacher);
            context.SaveChanges();
            return Ok(Teacher);
        }


    }
}