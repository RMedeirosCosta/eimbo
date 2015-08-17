using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public abstract class Especificacao<T> : ObjetoValor
    {
        public abstract Expression<Func<T, Boolean>> SatisfeitoPor();

        protected override bool ComparaValor(ObjetoValor obj)
        {
            return this.SatisfeitoPor() == ((Especificacao<T>)obj).SatisfeitoPor();
        }

        public override int GetHashCode()
        {
            return this.SatisfeitoPor().GetHashCode();
        }
    }
}
