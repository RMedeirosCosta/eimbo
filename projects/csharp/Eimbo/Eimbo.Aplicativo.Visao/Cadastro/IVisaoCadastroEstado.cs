using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroEstado
    {
        #region Ações
        void AdicionarEstadoNoGrid(long ID, String UF, Boolean bloqueado);
        void AlterarEstadoNoGrid(String UF, Boolean bloqueado);
        #endregion

        #region Focus
        void MandarFocoNaUF();
        #endregion

        #region Get
        String GetUF();
        #endregion

        #region Set
        void SetUF(String UF);
        #endregion
    }
}
