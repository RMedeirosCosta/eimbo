using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

#region Dominio
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
#endregion

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class CidadePorParteIdNomeUF :Especificacao<Cidade>
    {
        private String _parteId;
        private String _parteNome;
        private String _parteUF;

        public CidadePorParteIdNomeUF(String parteId, String parteNome, String parteUF)
        {
            this._parteId = parteId;
            this._parteNome = parteNome;
            this._parteUF = parteUF;
        }

        public override Expression<Func<Cidade, bool>> SatisfeitoPor()
        {
            return (cidade => (cidade.Id.ToString().Contains(this._parteId) ||
                              (cidade.Nome.Contains(this._parteNome))       ||
                              (cidade.Estado.UF.Contains(this._parteUF))));
        }
    }
}
