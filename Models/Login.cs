using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFinalAcademiaAtos.Models
{
    [Keyless]
    public class Login
    {
        [Required(ErrorMessage ="Login obrigatório")]
        public string login { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(15, MinimumLength = 8)]
        public string senha { get; set; }    
    }
}
