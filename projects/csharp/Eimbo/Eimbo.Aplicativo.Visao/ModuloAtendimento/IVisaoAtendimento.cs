using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.ModuloAtendimento
{
    public interface IVisaoAtendimento
    {
        #region Ações
        void AdicionarItem(long idServico, String descricaoServico, Decimal valorUnitario, int quantidade, Decimal valorItem);
        void VoltarParaTelaAnterior();
        void LimparValores();
        void LimparIdServico();
        void LimparDescricaoServico();
        void LimparValorUnitario();
        void LimparQuantidade();
        void LimparItens();
        void LimparAtendimento();
        Boolean ReceberNoCaixa(Decimal ValorAReceber);
        #endregion

        #region Busca
        Boolean AchouCliente(out long idCliente);
        Boolean AchouFormaPagamento(out long idFormaPagamento);
        Boolean AchouServico(out long idServico);
        #endregion

        #region Comportamento
        void HabilitarCabecalho(Boolean habilitar);
        void MostrarBotaoVoltarParaCabecalho(Boolean mostrar);
        void HabilitarValores(Boolean habilitar);
        void HabilitarBotaoConfirmarAtendimento(Boolean habilitar);
        void HabilitarEventosTotais(Boolean habilitar);
        #endregion

        #region Foco
        void MandarFocoNoCliente();
        void MandarFocoNaData();
        void MandarFocoNaEmpresa();
        void MandarFocoNaFormaPagamento();
        void MandarFocoNoServico();
        void MandarFocoNoValorUnitario();
        void MandarFocoNaQuantidade();
        #endregion

        #region Set
        void SetData(DateTime data);
        void SetIdEmpresa(long idEmpresa);
        void SetIdCliente(long idCliente);
        void SetIdFormaPagamento(long idFormaPagamento);
        void SetIdServico(long idServico);
        void SetRazaoSocialEmpresa(String razaoSocialEmpresa);
        void SetNomeCliente(String nomeCliente);
        void SetDescricaoFormaPagamento(String descricaoFormaPagamento);
        void SetDescricaoServico(String descricaoServico);
        void SetTotalValorUnitario(Decimal totalValorUnitario);
        void SetTotalQuantidade(Decimal totalQuantidade);
        void SetTotalValorItem(Decimal totalValorItem);
        void SetPercentualAcrescimo(Decimal percentualAcrescimo);
        void SetAcrescimoFormaPagamento(Decimal acrescimoFormaPagamento);
        void SetAcrescimo(Decimal acrescimo);
        void SetPercentualDesconto(Decimal percentualDesconto);
        void SetDescontoFormaPagamento(Decimal descontoFormaPagamento);
        void SetDesconto(Decimal desconto);
        void SetValorAtendimento(Decimal valorAtendimento);
        void SetValorEntrada(Decimal valorEntrada);
        void SetValorUnitario(Decimal valorUnitario);
        #endregion

        #region Get
        DateTime GetData();
        long GetIdEmpresa();
        long GetIdCliente();
        long GetIdFormaPagamento();
        long GetIdServico();
        Decimal GetValorUnitario();
        int GetQuantidade();
        long GetIdServicoSelecionado();
        Decimal GetAcrescimo();
        Decimal GetDesconto();
        #endregion
    }
}
