using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroCidade
    {
        #region Busca
        Boolean AchouEstado(out long ID, out String UF);
        #endregion

        #region Ações
        void AdicionarCidadeNoGrid(long ID, String Nome, String UF, Boolean bloqueado);
        void AlterarCidadeNoGrid(String nome, String UF, Boolean bloqueado);
        #endregion

        #region Focus
        void MandarFocoNoNome();
        void MandarFocoNoIDEstado();
        #endregion

        #region Get
        long GetIDSelecionado();
        String GetNome();
        String GetIDEstado();
        String GetUF();
        #endregion

        #region Set
        void SetNome(String Nome);
        void SetIDEstado(long IDEstado);
        void SetUF(String UF);
        #endregion
    }
}
