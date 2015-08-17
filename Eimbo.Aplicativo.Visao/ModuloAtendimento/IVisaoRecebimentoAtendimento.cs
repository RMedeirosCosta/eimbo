using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloAtendimento
{
    public interface IVisaoRecebimentoAtendimento
    {
        #region Comportamento
        void AlterarParaFaltam();
        void AlterarParaTroco();
        void HabilitarBotoesRestante(Boolean habilitar);
        void HabilitarBotaoReceber(Boolean habilitar);
        #endregion

        #region Ações
        void CancelarRecebimento();
        void FinalizarRecebimento();
        #endregion

        #region Get
        Decimal GetValorReceber();
        Decimal GetValorDinheiro();
        Decimal GetValorCartaoCredito();
        Decimal GetValorCartaoDebito();
        #endregion 

        #region Set
        void SetValorAReceber(Decimal valorAReceber);
        void SetValorDinheiro(Decimal valorDinheiro);
        void SetValorCartaoCredito(Decimal valorDinheiro);
        void SetValorCartaoDebito(Decimal valorCartaoDebito);
        void SetValorSoma(Decimal valorSoma);
        void SetValorTroco(Decimal valorTroco);
        void SetValorRestante(Decimal valorRestante);
        #endregion
    }
}
