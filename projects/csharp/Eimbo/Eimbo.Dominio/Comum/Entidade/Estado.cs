using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public class Estado :EntidadeBloqueavel
    {
        private String _uf;
 
        public virtual String UF
        {
            get { return _uf; }
            set
            {
                if ((String.IsNullOrWhiteSpace(value)) || (value.Length != 2))
                    throw new Excecao.ExcecaoParametroInvalido("Estado.uf");

                _uf = value;
            }
        }

        protected Estado() { }

        public Estado(String uf) :base()
        {
            this.UF = uf;
            base._status = TipoStatus.Normal;
        }
    }
}
