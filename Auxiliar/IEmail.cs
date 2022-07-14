namespace DesafioFinalAcademiaAtos.Auxiliar
{
    public interface IEmail
    {
        bool EnviarEmail(string email, string assunto, string mensagem);
    }
}
