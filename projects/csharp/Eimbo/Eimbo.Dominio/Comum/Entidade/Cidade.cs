using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class Cidade :EntidadeBloqueavel
    {
        private String _nome;
        private Estado _estado;

        public virtual String Nome
        {
            get { return _nome.ToUpper().Trim(); } 
            set 
            {
                if ((String.IsNullOrWhiteSpace(value)) || (value.Length > 300))
                    throw new ExcecaoParametroInvalido("nome");

                this._nome = value;
            } 
        }

        public virtual Estado Estado
        {
            get { return _estado; } 
            set
            {
                if (value == null)
                    throw new ExcecaoParametroInvalido("estado");

                this._estado = value;
            } 
        }

        protected Cidade() { }

        public Cidade(Estado estado, String nome) :base()
        {
            this.Nome = nome;
            this.Estado = estado;
        }
    }
}
