using DesafioVaiVoa.Interface;
using DesafioVaiVoa.Models;
using DesafioVaiVoa.RequestResponse;
using DesafioVaiVoa.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TesteVaiVoa
{
    public class TesteServiceCartao
    {
        [Trait("CartaoService", "SolicitarCartao")]
        [Fact(DisplayName = "Deveria Cadastrar Cartao passando todas informações corretas e retornar o cartao cadastrado")]
        public void DeveriaCadastrarCartaoEretornarCartaoCadastrado()
        {
            //Arrange
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var cartaoRepositoryMock = new Mock<ICartaoRepository>();
            var cartaoService = new CartaoService(usuarioRepositoryMock.Object, cartaoRepositoryMock.Object);
            var usuarioRequest = new UsuarioRequest() { Email = "teste@mail.com" };

            //Act
            var retorno = cartaoService.SolicitarCartao(usuarioRequest);

            //Assert
            Assert.NotNull(retorno);

        }

        [Trait("CartaoService", "Buscar")]
        [Fact(DisplayName = "Deveria retornar uma lista de cartões não nula caso o usuário já tenha pelo menos um cartão cadastrado no BankVaivoa")]
        public void DeveriaRetornarUmaListaNaoNula()
        {
            //Arrange
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var cartaoRepositoryMock = new Mock<ICartaoRepository>();
            var cartaoService = new CartaoService(usuarioRepositoryMock.Object, cartaoRepositoryMock.Object);
            var usuarioRequest = new UsuarioRequest() { Email = "teste@mail.com" };
            int idDoUsuarioExistenteNoBanco = 1;
            var usuarioDoBanco = new Usuario(usuarioRequest.Email) { Id = 1 };
            Cartao cartaoDoUsuario = new Cartao(usuarioDoBanco.Email, "1234567887654321");
            List<Cartao> listaDeCartao = new List<Cartao>();
            listaDeCartao.Add(cartaoDoUsuario);

            usuarioRepositoryMock.Setup(c => c.Buscar(usuarioRequest.Email)).Returns(usuarioDoBanco);
            cartaoRepositoryMock.Setup(c => c.Buscar(idDoUsuarioExistenteNoBanco)).Returns(listaDeCartao);

            //Act
            var retorno = cartaoService.Buscar(usuarioRequest.Email);

            //Assert
            Assert.NotNull(retorno);

        }
    }
}
