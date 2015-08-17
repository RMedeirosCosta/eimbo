using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class Servico :EntidadeBloqueavel
    {
        private String _descricao;
        private Decimal _valor;

        public virtual String Descricao
        {
            get { return this._descricao.ToUpper().Trim(); }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ExcecaoParametroInvalido("Descricao");

                this._descricao = value;
            }
        }

        public virtual Decimal Valor
        {
            get { return this._valor; }
            set
            {
                if ((value.Equals(0)) || (value < 0))
                    throw new ExcecaoParametroInvalido("Valor");

                this._valor = value;
            }
        }

        protected Servico() { }

        public Servico(String Descricao, Decimal Valor)
        {
            this.Descricao = Descricao;
            this.Valor = Valor;
            base._status = TipoStatus.Normal;
        }
    }
}
