using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

#region
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
#endregion

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class EstadoPorParteIdEUF :Especificacao<Estado>
    {
        private String _parteID;
        private String _parteUF;

        public EstadoPorParteIdEUF(String parteID, String parteUF)
        {
            this._parteID = parteID;
            this._parteUF = parteUF;
        }

        public override Expression<Func<Estado, bool>> SatisfeitoPor()
        {
            return (estado => (estado.Id.ToString().Contains(this._parteID)) || (estado.UF.Contains(this._parteUF)));
        }
    }

}
