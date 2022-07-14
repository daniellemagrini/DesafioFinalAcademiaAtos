using System.Security.Cryptography;
using System.Text;

namespace DesafioFinalAcademiaAtos.Auxiliar
{
    public static class Cripto
    {
        public static string GerarHash(this string senha)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding(); 
            var lista = encoding.GetBytes(senha);
            lista = hash.ComputeHash(lista);
            var str = new StringBuilder();

            foreach (var item in lista)
            {
                str.Append(item.ToString("x2"));
            }

            return str.ToString();
        }
    }
}
