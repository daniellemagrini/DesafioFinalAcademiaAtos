using System.ComponentModel.DataAnnotations;

namespace DesafioFinalAcademiaAtos.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite seu e-mail")]
        public string login { get; set; }
    }
}
