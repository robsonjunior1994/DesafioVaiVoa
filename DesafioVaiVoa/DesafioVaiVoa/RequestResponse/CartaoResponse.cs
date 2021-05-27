using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa.RequestResponse
{
    public class CartaoResponse
    {
        public string EmailTitular { get; set; }
        public string Numero { get;  set; }
        public DateTime DataDeCriacao { get;  set; }
    }
}
