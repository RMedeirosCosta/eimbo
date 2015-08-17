using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.DTO.Comum
{
    public class DTOTelefone
    {
        public String Telefone { get; set; }
        public TipoTelefone Tipo { get; set; }

        public Telefone ConverteDTOParaTelefone()
        {
            return new Telefone(this.Telefone, this.Tipo);            
        }
    }
}
