using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroPadrao
    {
        #region Ações
        void AbrirAbaConsulta();
        void AbrirAbaDados();
        void LimparBusca();
        void LimparDados();
        void LimparGrid();
        void VoltarParaTelaAnterior();
        #endregion

        #region Comportamento
        void HabilitarComportamentoDeCadastro();
        void HabilitarComportamentoDePesquisa();
        void HabilitarDados(Boolean habilita);
        void MostrarAcoesConsulta(Boolean mostra);
        void MostrarAcoesDados(Boolean mostra);
        void MostrarID(Boolean mostra);
        void MostrarBloqueado(Boolean mostra);
        #endregion

        #region Focus
        void MandarFocoNoCampoDeBusca();
        void MandarFocoNoGrid();
        #endregion 

        #region Get
        Boolean GetBloqueado();
        long GetIDSelecionado();
        long GetID();        
        #endregion

        #region Set
        void SetBloqueado(Boolean Bloqueado);        
        void SetID(long id);
        #endregion
    }
}
