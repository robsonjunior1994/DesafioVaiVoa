using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Models
{
    public class Cartao
    {
        public int Id { get; private set; }
        public Usuario Titular { get; set; }
        public string Numero { get; private set; }
        public DateTime DataDeCriacao { get; private set; }

        public Cartao() { }
        public Cartao(string email, string numeros)
        {
            Titular = new Usuario(email);
            Numero = numeros;
            DataDeCriacao = DateTime.Now;
        }

        public bool EhValido()
        {
            if (string.IsNullOrEmpty(Titular.Email) == true || string.IsNullOrEmpty(Numero) == true)
            {
                return false;
            }

            return true;
        }
    }
}
