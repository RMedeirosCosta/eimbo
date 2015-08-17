using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloCaixa
{
    public interface IVisaoExtratoDoCaixa
    {
        #region Ações
        void AdicionarLancamento(DateTime DataHora, String Descricao, Decimal ValorDinheiro, Decimal ValorCartaoCredito, Decimal ValorCartaoDebito);
        void VoltarParaTelaAnterior();
        #endregion

        #region Set
        void SetDataAbertura(DateTime DataAbertura);
        void SetTotalDinheiro(Decimal TotalDinheiro);
        void SetTotalCartaoCredito(Decimal TotalCartaoCredito);
        void SetTotalCartaoDebito(Decimal TotalCartaoDebito);
        #endregion
    }
}
