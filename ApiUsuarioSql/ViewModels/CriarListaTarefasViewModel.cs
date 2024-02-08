using System.ComponentModel.DataAnnotations;

namespace ApiUsuarioSql.ViewModels
{
    public class CriarListaTarefasViewModel
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int UsuariosId { get; set;}
    }
}
