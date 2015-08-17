using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.Entidade
{
    public abstract class EntidadeBloqueavel :Entidade
    {
        protected TipoStatus _status;

        public virtual TipoStatus Status { get { return _status; } }

        protected EntidadeBloqueavel() { this._status = TipoStatus.Normal;  }

        public virtual void AlteraStatus()
        {
            if (this.Status == TipoStatus.Bloqueado)
                this._status = TipoStatus.Normal;
            else
                this._status = TipoStatus.Bloqueado;
        }
    }
}
