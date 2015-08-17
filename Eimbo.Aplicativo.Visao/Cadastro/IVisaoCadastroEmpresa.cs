using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Visao.Cadastro
{
    public interface IVisaoCadastroEmpresa
    {
        #region Busca
        Boolean AchouCidade(out long idCidade, out String nomeCidade);
        #endregion 

        #region Ações
        void AdicionarDocumentoNoGrid(String ValorDocumento, String TipoDocumento);
        void AdicionarEnderecoNoGrid(String Logradouro, String Numero, String CEP, long IDCidade, String Cidade, String TipoEndereco);
        void AdicionarTelefoneNoGrid(String Telefone, String TipoTelefone);

        void LimparCamposDocumento();
        void LimparCamposEndereco();
        void LimparCamposTelefone();

        void LimparGridDeDocumentos();
        void LimparGridDeTelefones();
        void LimparGridDeEnderecos();

        void RemoverDocumentoDoGrid(int LinhaSelecionada);
        void RemoverEnderecoDoGrid(int LinhaSelecionada);
        void RemoverTelefoneDoGrid(int LinhaSelecionada);

        void VoltarParaTelaAnterior();
        #endregion

        #region Get
        String GetCEP();
        String GetCidade();
        DateTime GetDtFundacao();
        int GetLinhaDocumentoSelecionado();
        int GetLinhaEnderecoSelecionado();
        int GetLinhaTelefoneSelecionado();
        String GetLogradouro();
        long GetID();
        long GetIDCidade();
        String GetNome();
        String GetNumero();
        String GetTelefone();
        String GetTipoDocumento();
        String GetTipoEndereco();
        String GetTipoTelefone();
        String GetValorDocumento();

        String GetCEPDoGrid(int Indice);
        String GetCidadeDoGrid(int Indice);
        String GetLogradouroDoGrid(int Indice);
        long GetIDCidadeDoGrid(int Indice);
        String GetNumeroDoGrid(int Indice);
        String GetTelefoneDoGrid(int Indice);
        String GetTipoDocumentoDoGrid(int Indice);
        String GetTipoEnderecoDoGrid(int Indice);
        String GetTipoTelefoneDoGrid(int Indice);
        int GetTotalDeDocumentosDoGrid();
        int GetTotalDeEnderecosDoGrid();
        int GetTotalDeTelefonesDoGrid();
        String GetValorDocumentoDoGrid(int Indice);
        #endregion

        #region Set
        void SetDtFundacao(DateTime dtFundacao);
        void SetID(long id);
        void SetIDCidade(long id);
        void SetNome(String nome);
        void SetNomeCidade(String nomeCidade);
        #endregion

        #region Focus
        void MandarFocoNaDtFundacao();
        void MandarFocoNoLogradouro();
        void MandarFocoNoIDCidade();
        void MandarFocoNoNome();
        void MandarFocoNoTelefone();
        void MandarFocoNoTipoEndereco();
        void MandarFocoNoValorDocumento();
        #endregion
    }
}
