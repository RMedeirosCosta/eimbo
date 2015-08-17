using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Comum
{
    public interface IVisaoInicial
    {
        #region Ações
        void AbrirCadastroClientes();
        void AbrirCadastroCidades();
        void AbrirCadastroEmpresas();
        void AbrirCadastroEstados();
        void AbrirCadastroFormasPagamento();
        void AbrirCadastroServicos();
        Boolean AbriuNovoCaixa();
        void AbrirMovimentacaoSangria();
        void AbrirMovimentacaoReforco();
        void AbrirSaldoDoCaixa();
        void AbrirSaldoDetalhadoDoCaixa();
        void AbrirExtratoDoCaixa();
        void AbrirNovoAtendimento();
        void AlterarSituacaoCaixa(Boolean Aberto);
        void ExibirAvisoDataCaixaDifereDataAtual(Boolean ExibirAviso);
        void FecharAplicacacao();
        #endregion
    }
}
