using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloCaixa
{
    public interface IVisaoNovoCaixa
    {
        #region Ações
        void VoltarParaTelaAnterior();
        void FecharAposAbrirCaixa();        
        #endregion

        #region Get
        Decimal GetSaldoAbertura();
        #endregion
    }
}
