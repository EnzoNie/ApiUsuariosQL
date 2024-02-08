using ApiUsuarioSql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUsuarioSql.Models;
using ApiUsuarioSql.ViewModels;


namespace ApiUsuarioSql.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class ListaTarefasControler : ControllerBase
    {
        [HttpGet]
        [Route(template: "listaTarefas/{id}")]
        public async Task<IActionResult> BuscarListaTarefasPorId([FromServices] AppDbContext context, int id)
        {
            var listaTarefas = await context.ListaTarefas.AsNoTracking().FirstOrDefaultAsync(listaTarefas => listaTarefas.Id == id);

            if (listaTarefas is null)
            {
                return NotFound();
            }
            return Ok(listaTarefas);
        }

        [HttpPost(template: "listaTarefas")]
        public async Task<IActionResult> CriarListaTarefa([FromServices] AppDbContext context, [FromBody] CriarListaTarefasViewModel listaTarefaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var listaTarefa = new ListaTarefas
                {
                    Titulo = listaTarefaModel.Titulo,
                    UsuarioId = listaTarefaModel.UsuariosId
                };
                try
                {
                    await context.ListaTarefas.AddAsync(listaTarefa);
                    await context.SaveChangesAsync();

                    return Created($"v1/listaTarefas/{listaTarefa.Id}", listaTarefa);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        //[HttpPut(template:"usuarios/{id}")]
        //public async Task<IActionResult> AtualizarUsuario([FromServices] AppDbContext context, CriarUsuarioViewModel usuarioModel, int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        var usuario = await context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

        //        if(usuario is null)
        //        {
        //            return NotFound();
        //        }
        //        try
        //        {
        //            usuario.Nome = usuarioModel.Nome;
        //            usuario.Senha = usuarioModel.Senha;
        //            usuario.Email = usuarioModel.Email;
        //            usuario.Idade = usuarioModel.Idade;

        //            context.Usuarios.Update(usuario);
        //            await context.SaveChangesAsync();

        //            return Ok(usuario);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //}
        //[HttpDelete(template:"usuarios/{id}")]
        //public async Task<IActionResult> DeletarUsuario([FromServices] AppDbContext context, int id)
        //{
        //    var usuario = await context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

        //    if(usuario is null)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {
        //        context.Usuarios.Remove(usuario);
        //        await context.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
