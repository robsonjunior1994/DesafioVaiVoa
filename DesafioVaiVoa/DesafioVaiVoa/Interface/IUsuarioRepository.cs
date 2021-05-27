using DesafioVaiVoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Interface
{
    public interface IUsuarioRepository
    {
        void Salvar(Usuario u);
        Usuario Buscar(string email);
    }
}
