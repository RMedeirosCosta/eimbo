using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class ClientePorParteIDNome :Especificacao<Pessoa>
    {
        private String _parteId;
        private String _parteNome;

        public ClientePorParteIDNome(String parteId, String parteNome)
        {
            this._parteId = parteId;
            this._parteNome = parteNome;
        }

        public override Expression<Func<Pessoa, bool>> SatisfeitoPor()
        {
            return (
                     c => (
                            (c.TipoCadastroPessoa == TipoCadastroPessoa.Cliente) &&
                            (
                             (c.Id.ToString().Contains(this._parteId)) ||
                             (c.Nome.Contains(this._parteNome)) 
                            )
                          )
                   );
        }
    }
}
