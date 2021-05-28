using DesafioVaiVoa.Interface;
using DesafioVaiVoa.RequestResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ICartaoService _cartaoService;
        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioRequest usuarioExterno)
        {
            var cartao = _cartaoService.SolicitarCartao(usuarioExterno);
            if (cartao == null)
            {
                return BadRequest();
            }
            return Ok(cartao);
        }
        [Route("{email}")]
        [HttpGet]
        public IActionResult Get([FromRoute] string email)
        {
            var cartaoDoBanco = _cartaoService.Buscar(email);

            if (cartaoDoBanco == null)
            {
                return BadRequest();
            }
            return Ok(cartaoDoBanco);
        }
    }
}
