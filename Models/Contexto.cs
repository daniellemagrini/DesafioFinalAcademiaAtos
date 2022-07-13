using Microsoft.EntityFrameworkCore;
using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Models
{
    public class Contexto : DbContext
    {
        //CONSTRUTOR
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        //MODELS QUE SERÃO GERENCIADOS -- SE NÃO EXISTIR, SERÁ CRIADO COM MIGRATION
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<DesafioFinalAcademiaAtos.Models.Login>? Login { get; set; }
    }
}
