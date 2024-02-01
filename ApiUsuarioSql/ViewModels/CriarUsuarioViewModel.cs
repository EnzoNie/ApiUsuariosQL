using System.ComponentModel.DataAnnotations;

namespace ApiUsuarioSql.ViewModels
{
    public class CriarUsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        public int Idade { get; set; }
    }
}
