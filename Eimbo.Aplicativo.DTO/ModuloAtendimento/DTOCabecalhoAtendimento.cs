using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.ModuloAtendimento
{
    public class DTOCabecalhoAtendimento
    {
        public DateTime Data { get; set; }
        public long IdEmpresa { get; set; }
        public long IdCliente { get; set; }
        public long IdFormaPagamento { get; set; }
    }
}
