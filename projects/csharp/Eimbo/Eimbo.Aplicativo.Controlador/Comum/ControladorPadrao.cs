using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Visao.Comum;

namespace Eimbo.Aplicativo.Controlador.Comum
{
    public abstract class ControladorPadrao<Visao> 
    {
        protected IVisaoPadrao _visaoPadrao;
        protected Visao        _visao;

        public ControladorPadrao(Visao visao)
        {
            this._visaoPadrao = (IVisaoPadrao)visao;
            this._visao = visao;
        }
    }
}
