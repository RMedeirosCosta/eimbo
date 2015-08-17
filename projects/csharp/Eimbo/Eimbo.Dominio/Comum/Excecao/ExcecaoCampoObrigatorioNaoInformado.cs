using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoCampoObrigatorioNaoInformado :Exception
    {
        public ExcecaoCampoObrigatorioNaoInformado(String nomeDoCampo) : base("Campo obrigatório "+nomeDoCampo+" não foi informado!") { }
    }
}
