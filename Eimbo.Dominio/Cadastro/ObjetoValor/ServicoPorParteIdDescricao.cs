using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class ServicoPorParteIdDescricao : Especificacao<Eimbo.Dominio.Comum.Entidade.Servico>
    {
        private String _parteId;
        private String _parteDescricao;

        public ServicoPorParteIdDescricao(String parteId, String parteDescricao)
        {
            this._parteId = parteId;
            this._parteDescricao = parteDescricao;
        }

        public override Expression<Func<Eimbo.Dominio.Comum.Entidade.Servico, bool>> SatisfeitoPor()
        {
            return (
                     s => (
                            (s.Id.ToString().Contains(this._parteId)) ||
                            (s.Descricao.Contains(this._parteDescricao))                            
                          )
                   );
        }
    }
}
