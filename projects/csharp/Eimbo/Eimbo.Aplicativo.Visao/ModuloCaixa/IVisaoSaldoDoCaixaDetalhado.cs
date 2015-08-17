using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloCaixa
{
    public interface IVisaoSaldoDoCaixaDetalhado
    {
        #region Ações
        void VoltarParaTelaAnterior();
        #endregion

        #region Comportamentos

        #region Dinheiro
        void OcultarDinheiro();
        void OcultarSaldoAbertura();
        void OcultarTotalAtendimentosDinheiro();
        void OcultarTotalReforcos();
        void OcultarTotalSangrias();
        void OcultarTotalTrocos();
        #endregion 

        #region Cartão de Crédito
        void OcultarCartaoCredito();
        #endregion

        #region Cartão de Débito
        void OcultarCartaoDebito();
        #endregion

        #endregion

        #region Set
        void SetDataAbertura(DateTime DataAbertura);

        #region Dinheiro
        void SetSaldoDinheiro(Decimal SaldoDinheiro);
        void SetSaldoAbertura(Decimal SaldoAbertura);
        void SetTotalAtendimentosDinheiro(Decimal TotalAtendimentos);
        void SetTotalReforcos(Decimal TotalReforcos);
        void SetTotalSangrias(Decimal TotalSangrias);
        void SetTotalTrocos(Decimal TotalTrocos);
        #endregion

        #region Cartão de Crédito
        void SetSaldoCartaoCredito(Decimal SaldoCartaoCredito);
        void SetTotalAtendimentosCartaoCredito(Decimal TotalAtendimentosCartaoCredito);
        #endregion

        #region Cartão de Débito
        void SetSaldoCartaoDebito(Decimal SaldoCartaoDebito);
        void SetTotalAtendimentosCartaoDebito(Decimal TotalAtendimentosCartaoDebito);
        #endregion

        #endregion
    }
}
