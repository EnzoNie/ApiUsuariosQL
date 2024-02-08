using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuarioSql.Models
{
    public class ListaTarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
    }
}
