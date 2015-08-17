using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.ModuloAtendimento
{
    public class DTOItem
    {
        public long IdServico { get; set; }
        public Decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public Decimal ValorItem { get; set; }
        public String DescricaoServico { get; set; }
    }
}
