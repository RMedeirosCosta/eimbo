using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroFormaPagamento
    {
        #region Ações
        void AdicionarFormaPagamentoNoGrid(long ID, String Descricao,Boolean bloqueado);
        void AlterarFormaPagamentoNoGrid(String Descricao, Boolean bloqueado);
        #endregion

        #region Comportamento
        void HabilitarGrupoParcelamento(Boolean Habilitar);
        #endregion

        #region Focus
        void MandarFocoNaDescricao();
        void MandarFocoNoAcrescimo();
        void MandarFocoNoDesconto();
        void MandarFocoNoIntervaloEntreParcelas();
        void MandarFocoNaQuantidadeDeParcelas();
        #endregion

        #region Get
        String GetDescricao();
        int GetTipo();
        Decimal GetPercentualAcrescimo();
        Decimal GetPercentualDesconto();
        int GetTipoParcelamento();
        int GetQuantidadeParcelas();
        int GetIntervaloEntreParcelas();
        #endregion

        #region Set
        void SetDescricao(String Descricao);
        void SetTipo(int Tipo);
        void SetPercentualAcrescimo(Decimal Acrescimo);
        void SetPercentualDesconto(Decimal Desconto);
        void SetTipoParcelamento(int Tipo);
        void SetQuantidadeParcelas(int QuantidadeParcelas);
        void SetIntervaloEntreParcelas(int IntervaloEntreParcelas);
        #endregion
    }
}
