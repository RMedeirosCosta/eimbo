using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloCaixa
{
    public interface IVisaoMovimentacaoCaixa
    {
        #region Ações
        void AlterarNomeMovimentacao(String NomeMovimentacao);
        void AlterarTituloTela(String TituloFormulario);
        void VoltarParaTelaAnterior();
        #endregion

        #region Get
        Decimal GetValorMovimentacao();
        #endregion
    }
}
