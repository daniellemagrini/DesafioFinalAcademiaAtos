using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFinalAcademiaAtos.Models
{
    [Table("Pergunta")]
    public class Pergunta
    {
        [Key]
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("pergunta")]
        [Display(Name = "Pergunta")]
        [Required]
        public string pergunta { get; set; }

        [Column("resposta")]
        [Display(Name = "Resposta")]
        [Required]
        public string resposta { get; set; }

        [Column("categoria")]
        [Display(Name = "Categoria")]
        [Required]
        public string categoria { get; set; }

        [Column("nivel")]
        [Display(Name = "Nível")]
        [Required]
        public string nivel { get; set; }

        [Column("solucao")]
        [Display(Name = "Solução")]
        [Required]
        public string solucao { get; set; }

        [Column("alternativaA")]
        [Display(Name = "Alternativa A")]
        [Required]
        public string alternativaA { get; set; }

        [Column("alternativaB")]
        [Display(Name = "Alternativa B")]
        [Required]
        public string alternativaB { get; set; }

        [Column("alternativaC")]
        [Display(Name = "Alternativa C")]
        [Required]
        public string alternativaC { get; set; }

        [Column("alternativaD")]
        [Display(Name = "Alternativa D")]
        [Required]
        public string alternativaD { get; set; }

        [Column("alternativaE")]
        [Display(Name = "Alternativa E")]
        [Required]
        public string alternativaE { get; set; }
    }
}
