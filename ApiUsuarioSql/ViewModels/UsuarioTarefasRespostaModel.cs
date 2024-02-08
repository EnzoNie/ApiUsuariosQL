using ApiUsuarioSql.Models;

namespace ApiUsuarioSql.ViewModels
{
    public class UsuarioTarefasRespostaModel
    {
        public string Nome { get; set; }
        public ICollection<ListaTarefas> Tarefas { get; set; }
    }
}
