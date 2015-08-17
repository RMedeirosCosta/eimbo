using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoEnderecoNaoPermitido :Exception
    {
        public ExcecaoEnderecoNaoPermitido(TipoPessoa tipoPessoa, TipoEndereco tipoEndereco) : base("Não é permitido adicionar " + NomeTipoEndereco.ObtemString(tipoEndereco) + "para pessoa " + NomeTipoPessoa.Obtem(tipoPessoa) + "!") { }
    }
}
