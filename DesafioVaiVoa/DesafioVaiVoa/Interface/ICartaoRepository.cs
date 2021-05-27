using DesafioVaiVoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Interface
{
    public interface ICartaoRepository
    {
        void Cadastrar(Cartao c);
        List<Cartao> Buscar(int id);
    }
}
