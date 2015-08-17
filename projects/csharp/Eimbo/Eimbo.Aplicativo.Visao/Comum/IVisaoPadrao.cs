using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Comum
{
    public interface IVisaoPadrao
    {
        #region Caixas de Diálogo
        void Avisar(String aviso);
        void ExibirErro(String Erro, String NomeDoControle);
        void ExibirErro(String Erro);
        Boolean PedirConfirmacao(String pergunta);
        #endregion 
    }
}
