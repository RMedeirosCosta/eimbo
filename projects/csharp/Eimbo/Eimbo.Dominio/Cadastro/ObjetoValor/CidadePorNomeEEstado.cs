using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class CidadePorNomeEEstado :Especificacao<Cidade>
    {
        private String _nome;
        private long _idEstado;


        public CidadePorNomeEEstado(String nome, Estado estado)
        {
            this._nome = nome;

            try
            {
                this._idEstado = estado.Id;
            }
            catch (NullReferenceException)
            {
                this._idEstado = 0;
            }
        }

        public override Expression<Func<Cidade, Boolean>> SatisfeitoPor()
        {
             return (c => (c.Nome.Equals(_nome) && (c.Estado.Id.Equals(this._idEstado))));
        }

    }
}
