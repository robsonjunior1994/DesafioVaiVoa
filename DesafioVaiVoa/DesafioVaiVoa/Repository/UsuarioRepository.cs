using DesafioVaiVoa.Interface;
using DesafioVaiVoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicativoContext _aplicativoContext;

        public UsuarioRepository(AplicativoContext aplicativoContext)
        {
            _aplicativoContext = aplicativoContext;
        }

        public Usuario Buscar(string email)
        {
            return _aplicativoContext.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Salvar(Usuario u)
        {
            _aplicativoContext.Usuarios.Add(u);
            _aplicativoContext.SaveChanges();
        }
    }
}
