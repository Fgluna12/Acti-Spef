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

    public class TeachersController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public TeachersController(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}

