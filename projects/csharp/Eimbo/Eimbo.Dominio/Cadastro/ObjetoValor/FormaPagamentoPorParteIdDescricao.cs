using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class FormaPagamentoPorParteIdDescricao :Especificacao<FormaPagamento>
    {
        private String _parteId;
        private String _parteDescricao;

        public FormaPagamentoPorParteIdDescricao(String parteId, String parteDescricao)
        {
            this._parteId = parteId;
            this._parteDescricao = parteDescricao;
        }

        public override Expression<Func<FormaPagamento, Boolean>> SatisfeitoPor()
        {
            return (f => (
                          (f.Id.ToString().Contains(this._parteId)) ||
                          (f.Descricao.Contains(this._parteDescricao))
                         ));
        }
    }
}
