using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloCaixa
{
    public interface IVisaoSaldoDoCaixa
    {
        #region Ações
        void VoltarParaTelaAnterior();
        #endregion

        #region Comportamento
        void MostrarSaldoDinheiro(Boolean Mostrar);
        void MostrarSaldoCartaoCredito(Boolean Mostrar);
        void MostrarSaldoCartaoDebito(Boolean Mostrar);
        #endregion

        #region Set
        void SetDataAbertura(DateTime DataAbertura);
        void SetSaldoDinheiro(Decimal SaldoDinheiro);
        void SetSaldoCartaoCredito(Decimal SaldoCartaoCredito);
        void SetSaldoCartaoDebito(Decimal SaldoCartaoDebito);
        #endregion
    }
}
