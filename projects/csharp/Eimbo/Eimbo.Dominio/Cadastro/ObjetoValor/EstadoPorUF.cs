using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class EstadoPorUF :Especificacao<Estado>
    {
        private String _UF;

        public EstadoPorUF(String uf) { this._UF = uf; }

        public override Expression<Func<Estado, Boolean>> SatisfeitoPor()
        {
            return e => (e.UF == this._UF);
        }
    }
}
