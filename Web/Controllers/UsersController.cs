using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Infrastructure;
using Infrastructure.Identities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Route("AsignarUsuarioRol")]
        public async Task<ActionResult> AsignarRolUsuario(EditarRolDTO EditarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(EditarRolDTO.UserId);
            if (usuario == null) { return NotFound(); }
            await userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, EditarRolDTO.RoleName));
            await userManager.AddToRoleAsync(usuario, EditarRolDTO.RoleName);
            return Ok();
        }

        [Route("RemoverUsuarioRol")]
        public async Task<ActionResult> RemoverUsuarioRol(EditarRolDTO editarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(editarRolDTO.UserId);
            if (usuario == null) { return NotFound(); }
            await userManager.RemoveClaimAsync(usuario, new Claim(ClaimTypes.Role, editarRolDTO.RoleName));
            await userManager.RemoveFromRoleAsync(usuario, editarRolDTO.RoleName);
            return Ok();
        }
    }
}