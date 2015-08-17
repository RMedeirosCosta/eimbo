using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroServico
    {
        #region Ações
        void AdicionarServicoNoGrid(long ID, String Descricao, Decimal Valor, Boolean bloqueado);
        void AlterarServicoNoGrid(String Descricao, Decimal Valor, Boolean bloqueado);        
        #endregion

        #region Focus
        void MandarFocoNaDescricao();
        void MandarFocoNoValor();
        #endregion

        #region Get
        String GetDescricao();
        Decimal GetValor();
        #endregion

        #region Set
        void SetDescricao(String Descricao);
        void SetValor(Decimal Valor);
        #endregion
    }
}
