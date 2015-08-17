using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public abstract class ObjetoValor
    {
        protected abstract bool ComparaValor(ObjetoValor obj);

        public abstract override int GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || (!obj.GetType().Equals(this.GetType())))
                return false;

            if (obj == this)
                return true;

            return ComparaValor((ObjetoValor)obj);
        }
    }
}
