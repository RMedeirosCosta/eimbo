using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.ModuloAtendimento.Excecao
{
    public class ExcecaoCabecalhoNaoAdicionado :Exception
    {
        public ExcecaoCabecalhoNaoAdicionado() : base("É preciso preencher o cabeçalho antes de realizar essa operação!") { }
    }
}
