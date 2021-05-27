using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Models
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }

        public Usuario() { }
        public Usuario(string email)
        {
            Email = email;
        }
        public bool EhValido()
        {
            if(string.IsNullOrEmpty(Email) == false)
            {
                return true;
            }

            return false;
        }
    }
}
