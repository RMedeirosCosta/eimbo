using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoEnderecoResidencialDuplicado :Exception
    {
        public ExcecaoEnderecoResidencialDuplicado() : base("Apenas um endereço residencial é permitido!") { }
    }
}
