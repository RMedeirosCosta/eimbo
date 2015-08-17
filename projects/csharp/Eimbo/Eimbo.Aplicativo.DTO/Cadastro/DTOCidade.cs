using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.Cadastro
{
    public class DTOCidade :DTOBloqueavel
    {
        public String Nome      { get; set; }
        public DTOEstado Estado { get; set; }
    }
}
