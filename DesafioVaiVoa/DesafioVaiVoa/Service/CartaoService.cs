using DesafioVaiVoa.Interface;
using DesafioVaiVoa.Models;
using DesafioVaiVoa.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Service
{
    public class CartaoService : ICartaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICartaoRepository _cartaoRepository;

        public CartaoService(IUsuarioRepository usuarioRepository, ICartaoRepository cartaoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cartaoRepository = cartaoRepository;
        }
        public bool SolicitarCartao(UsuarioRequest u)
        {
            Usuario usuario = new Usuario(u.Email);
            if (usuario.EhValido())
            {
                //_usuarioRepository.Salvar(usuario);
                GerarCartao(usuario);
                return true;
            }

            return false;
        }
        private bool GerarCartao(Usuario u)
        {
            string numeros = GerarNumerosDoCartao();
            Cartao cartao = new Cartao(u.Email, numeros);

            if (cartao.EhValido())
            {
                Usuario usuario = _usuarioRepository.Buscar(u.Email);
                if (usuario != null)
                {
                    cartao.Titular = usuario;
                }
                _cartaoRepository.Cadastrar(cartao);
                return true;
            }
            return false;
        }
        private static string GerarNumerosDoCartao()
        {
            var random = new Random();
            var numeros1 = random.Next(11111111, 99999999);
            var numeros2 = random.Next(11111111, 99999999);
            string numeros = numeros2.ToString() + numeros1.ToString();
            return numeros;
        }
        public List<Cartao> Buscar(string email)
        {
            if(string.IsNullOrEmpty(email) == false)
            {
                Usuario usuario = _usuarioRepository.Buscar(email);
                List<Cartao> cartoes = _cartaoRepository.Buscar(usuario.Id);
                return cartoes;
            }
            return null;
        }
    }
}
