using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFinalAcademiaAtos.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        private readonly Contexto _context;

        public Usuario(Contexto context)
        {
            _context = context;
        }

        [Key]
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string nome { get; set; }

        [Column("cpf")]
        [Display(Name = "CPF")]
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string cpf { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string email { get; set; }

        [Column("cep")]
        [Display(Name = "CEP")]
        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string cep { get; set; }

        [Column("logradouro")]
        [Display(Name = "Logradouro")]
        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string logradouro { get; set; }

        [Column("numero_endereco")]
        [Display(Name = "Nº")]
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string numero_endereco { get; set; }

        [Column("complemento")]
        [Display(Name = "Complemento")]

        public string complemento { get; set; }

        [Column("bairro")]
        [Display(Name = "Bairro")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string bairro { get; set; }

        [Column("cidade")]
        [Display(Name = "Cidade")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string cidade { get; set; }

        [Column("estado")]
        [Display(Name = "Estado")]
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string estado { get; set; }

        [Column("telefone")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Column("senha")]
        [Display(Name = "Senha")]
        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string senha { get; set; }

        public bool ValidaSenha(string senha1)
        {
            return senha == senha1;
        }

        public Usuario BuscaEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(x => x.email == email.ToLower());
        }
    }
}
