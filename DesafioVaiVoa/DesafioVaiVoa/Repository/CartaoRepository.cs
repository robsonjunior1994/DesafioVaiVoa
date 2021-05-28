using DesafioVaiVoa.Interface;
using DesafioVaiVoa.Models;
using DesafioVaiVoa.RequestResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.Repository
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly AplicativoContext _aplicativoContext;

        public CartaoRepository(AplicativoContext aplicativoContext)
        {
            _aplicativoContext = aplicativoContext;
        }

        public List<Cartao> Buscar(int id)
        {
            List<Cartao> cartaos = new List<Cartao>();
            var listaCompleta =  _aplicativoContext.Cartoes.Include(t => t.Titular).ToList();
            
            foreach (var cartao in listaCompleta)
            {
                if(cartao.Titular.Id == id)
                {
                    cartaos.Add(cartao);
                }
            }

            return cartaos;
        }

        public void Cadastrar(Cartao c)
        {
            _aplicativoContext.Cartoes.Add(c);
            _aplicativoContext.SaveChanges();
        }
    }
}
