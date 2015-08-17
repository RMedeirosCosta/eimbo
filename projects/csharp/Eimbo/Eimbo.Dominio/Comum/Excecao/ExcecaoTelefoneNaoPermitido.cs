using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoTelefoneNaoPermitido :Exception
    {
        public ExcecaoTelefoneNaoPermitido(TipoPessoa tipoPessoa, TipoTelefone tipoTelefone) : base("Não é permitido adicionar " + NomeTipoTelefone.ObtemString(tipoTelefone) + "para pessoa " + NomeTipoPessoa.Obtem(tipoPessoa) + "!") { }
    }
}
