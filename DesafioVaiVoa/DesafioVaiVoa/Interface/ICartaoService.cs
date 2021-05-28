using DesafioVaiVoa.Models;
using DesafioVaiVoa.RequestResponse;
using System.Collections.Generic;

namespace DesafioVaiVoa.Interface
{
    public interface ICartaoService
    {
        Cartao SolicitarCartao(UsuarioRequest u);
        List<Cartao> Buscar(string email);
    }
}
