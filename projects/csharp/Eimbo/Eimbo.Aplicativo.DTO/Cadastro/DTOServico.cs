using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.Cadastro
{
    public class DTOServico :DTOBloqueavel
    {
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
