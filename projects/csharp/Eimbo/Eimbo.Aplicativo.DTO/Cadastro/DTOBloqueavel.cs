using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.DTO.Comum;

namespace Eimbo.Dominio.DTO.Cadastro
{
    public class DTOBloqueavel :Comum.DTO
    {
        public TipoStatus Status { get; set; }
    }
}
