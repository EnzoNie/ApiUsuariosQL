using ApiUsuarioSql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUsuarioSql.Models;
using ApiUsuarioSql.ViewModels;


namespace ApiUsuarioSql.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route(template: "usuarios/{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId([FromServices] AppDbContext context, int id)
        {
            var usuario = await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Id == id);

            if (usuario is null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost(template: "usuarios")]
        public async Task<IActionResult> CriarUsuario([FromServices] AppDbContext context, [FromBody] CriarUsuarioViewModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var usuario = new Usuario
                {
                    Nome = usuarioModel.Nome,
                    Senha = usuarioModel.Senha,
                    Email = usuarioModel.Email,
                    Idade = usuarioModel.Idade
                };
                try
                {
                    await context.Usuarios.AddAsync(usuario);
                    await context.SaveChangesAsync();

                    return Created($"v1/usuario/{usuario.Id}", usuario);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut(template:"usuarios/{id}")]
        public async Task<IActionResult> AtualizarUsuario([FromServices] AppDbContext context, CriarUsuarioViewModel usuarioModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

                if(usuario is null)
                {
                    return NotFound();
                }
                try
                {
                    usuario.Nome = usuarioModel.Nome;
                    usuario.Senha = usuarioModel.Senha;
                    usuario.Email = usuarioModel.Email;
                    usuario.Idade = usuarioModel.Idade;

                    context.Usuarios.Update(usuario);
                    await context.SaveChangesAsync();

                    return Ok(usuario);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        [HttpDelete(template:"usuarios/{id}")]
        public async Task<IActionResult> DeletarUsuario([FromServices] AppDbContext context, int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

            if(usuario is null)
            {
                return NotFound();
            }
            try
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
