using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Aplicativo.Controlador.Cadastro;
using Eimbo.IU.Telas.Comum;

namespace Eimbo.IU.Telas.Cadastro
{
    public partial class TelaCadastroEmpresa : TelaPadrao, IVisaoCadastroEmpresa
    {
        private ControladorCadastroEmpresa _controlador;
        private TelaCadastroCidade _telaCidade;

        public TelaCadastroEmpresa()
        {
            InitializeComponent();
            this._controlador = new ControladorCadastroEmpresa(this);
            this._telaCidade = new TelaCadastroCidade();
            this._telaCidade.EmBusca = true;
        }

        #region IVisaoCadastroEmpresa
        #region Busca
        public Boolean AchouCidade(out long idCidade, out String nomeCidade)
        {
            this._telaCidade.ShowDialog();

            if (this._telaCidade.DialogResult == DialogResult.OK)
            {
                idCidade = this._telaCidade.GetIDSelecionado();
                nomeCidade = this._telaCidade.GetNomeSelecionada();
                return true;
            }

            idCidade = 0;
            nomeCidade = String.Empty;
            return false;
        }
        #endregion 
        #region Campos
        public void LimparCamposDocumento()
        {
            this.edtDocumento.Clear();
            this.cbTipoDocumento.SelectedIndex = -1;
        }

        public void LimparCamposEndereco()
        {
            this.edtLogradouro.Clear();
            this.edtNumero.Clear();
            this.edtCEP.Clear();
            this.edtIDCidade.Clear();
            this.edtNomeCidade.Clear();
            this.cbTipoEndereco.SelectedIndex = -1;
        }

        public void LimparCamposTelefone()
        {
            this.edtTelefone.Clear();
            this.cbTipoTelefone.SelectedIndex = -1;
        }

        public String GetCEP()
        {
            return this.edtCEP.Text;
        }

        public String GetCidade()
        {
            return this.edtNomeCidade.Text;
        }


        public DateTime GetDtFundacao()
        {
            return this.edtDtFundacao.Value;
        }

        public int GetLinhaDocumentoSelecionado()
        {
            return this.dgvDocumentos.Rows.IndexOf(this.dgvDocumentos.SelectedRows[0]);
        }

        public int GetLinhaEnderecoSelecionado()
        {
            return this.dgvEnderecos.Rows.IndexOf(this.dgvEnderecos.SelectedRows[0]);
        }


        public int GetLinhaTelefoneSelecionado()
        {
            return this.dgvTelefones.Rows.IndexOf(this.dgvTelefones.SelectedRows[0]);
        }

        public String GetLogradouro()
        {
            return this.edtLogradouro.Text;
        }

        public long GetID()
        {
            long id;

            long.TryParse(this.edtID.Text, out id);

            return id;
        }

        public long GetIDCidade()
        {
            long idCidade;

            long.TryParse(this.edtIDCidade.Text, out idCidade);

            return idCidade;
        }

        public String GetNome()
        {
            return this.edtRazaoSocial.Text;
        }


        public String GetNumero()
        {
            return this.edtNumero.Text;
        }

        public String GetTelefone()
        {
            return this.edtTelefone.Text;
        }

        public String GetTipoDocumento()
        {
            return this.cbTipoDocumento.Text;
        }


        public String GetTipoEndereco()
        {
            return this.cbTipoEndereco.Text;
        }

        public String GetTipoTelefone()
        {
            return this.cbTipoTelefone.Text;
        }

        public String GetValorDocumento()
        {
            return this.edtDocumento.Text;
        }

        public void SetDtFundacao(DateTime dtFundacao)
        {
            this.edtDtFundacao.Value = dtFundacao;
        }

        public void SetID(long id)
        {
            this.edtID.Text = id.ToString();
        }

        public void SetIDCidade(long id)
        {
            this.edtIDCidade.Text = id.ToString();
        }

        public void SetNome(String nome)
        {
            this.edtRazaoSocial.Text = nome;
        }

        public void SetNomeCidade(String nomeCidade)
        {
            this.edtNomeCidade.Text = nomeCidade;
        }

        #endregion

        #region Focus
        public void MandarFocoNaDtFundacao()
        {
            this.edtDtFundacao.Focus();
        }

        public void MandarFocoNoLogradouro()
        {
            this.edtLogradouro.Focus();
        }

        public void MandarFocoNoIDCidade()
        {
            this.edtIDCidade.Focus();
        }

        public void MandarFocoNoNome()
        {
            this.edtRazaoSocial.Focus();
        }

        public void MandarFocoNoTelefone()
        {
            this.edtTelefone.Focus();
        }

        public void MandarFocoNoTipoEndereco()
        {
            this.cbTipoEndereco.Focus();
        }

        public void MandarFocoNoValorDocumento()
        {
            this.edtDocumento.Focus();
        }
        #endregion

        #region Grid
        public void AdicionarDocumentoNoGrid(String ValorDocumento, String TipoDocumento)
        {
            this.dgvDocumentos.Rows.Add(ValorDocumento, TipoDocumento);
        }

        public void AdicionarEnderecoNoGrid(String Logradouro, String Numero, String CEP, long IDCidade, String Cidade, String TipoEndereco)
        {
            this.dgvEnderecos.Rows.Add(Logradouro, Numero, CEP, IDCidade, Cidade, TipoEndereco);
        }

        public void AdicionarTelefoneNoGrid(String Telefone, String TipoTelefone)
        {
            this.dgvTelefones.Rows.Add(Telefone, TipoTelefone);
        }

        public String GetCEPDoGrid(int Indice)
        {
            return (String)this.dgvEnderecos.Rows[Indice].Cells[2].Value;
        }

        public String GetCidadeDoGrid(int Indice)
        {
            return (String)this.dgvEnderecos.Rows[Indice].Cells[4].Value;
        }

        public String GetLogradouroDoGrid(int Indice)
        {
            return (String)this.dgvEnderecos.Rows[Indice].Cells[0].Value;
        }

        public long GetIDCidadeDoGrid(int Indice)
        {
            return (long)this.dgvEnderecos.Rows[Indice].Cells[3].Value;
        }

        public String GetNumeroDoGrid(int Indice)
        {
            return (String)this.dgvEnderecos.Rows[Indice].Cells[1].Value;
        }

        public String GetTelefoneDoGrid(int Indice)
        {
            return (String)this.dgvTelefones.Rows[Indice].Cells[0].Value;
        }

        public String GetTipoDocumentoDoGrid(int Indice)
        {
            return (String)this.dgvDocumentos.Rows[Indice].Cells[1].Value;
        }

        public String GetTipoEnderecoDoGrid(int Indice)
        {
            return (String)this.dgvEnderecos.Rows[Indice].Cells[5].Value;
        }

        public String GetTipoTelefoneDoGrid(int Indice)
        {
            return (String)this.dgvTelefones.Rows[Indice].Cells[1].Value;
        }

        public int GetTotalDeDocumentosDoGrid()
        {
            return this.dgvDocumentos.RowCount;
        }

        public int GetTotalDeEnderecosDoGrid()
        {
            return this.dgvEnderecos.RowCount;
        }

        public int GetTotalDeTelefonesDoGrid()
        {
            return this.dgvTelefones.RowCount;
        }

        public String GetValorDocumentoDoGrid(int Indice)
        {
            return (String)this.dgvDocumentos.Rows[Indice].Cells[0].Value;
        }

        public void LimparGridDeDocumentos()
        {
            this.dgvDocumentos.Rows.Clear();
        }

        public void LimparGridDeTelefones()
        {
            this.dgvTelefones.Rows.Clear();
        }

        public void LimparGridDeEnderecos()
        {
            this.dgvEnderecos.Rows.Clear();
        }

        public void RemoverDocumentoDoGrid(int LinhaSelecionada)
        {
            this.dgvDocumentos.Rows.RemoveAt(LinhaSelecionada);
        }

        public void RemoverEnderecoDoGrid(int LinhaSelecionada)
        {
            this.dgvEnderecos.Rows.RemoveAt(LinhaSelecionada);
        }

        public void RemoverTelefoneDoGrid(int LinhaSelecionada)
        {
            this.dgvTelefones.Rows.RemoveAt(LinhaSelecionada);
        }
        #endregion

        #region Manipulação de tela
        public void VoltarParaTelaAnterior()
        {
            this.Close();
        }
        #endregion

        private void btnFecha_Click(object sender, EventArgs e)
        {
            this._controlador.VoltarParaTelaAnterior();
        }
        #endregion

        private void btnSalva_Click(object sender, EventArgs e)
        {
            this._controlador.Gravar();
        }

        private void btnAdicionarDocumento_Click(object sender, EventArgs e)
        {
            this._controlador.AdicionarDocumentoNoGrid();
        }

        private void btnAdicionarTelefone_Click(object sender, EventArgs e)
        {
            this._controlador.AdicionarTelefoneNoGrid();
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            this._controlador.AdicionarEnderecoNoGrid();
        }

        private void tsmiRemoverDocumento_Click(object sender, EventArgs e)
        {
            this._controlador.RemoverDocumentoDoGrid();
        }

        private void tsmiRemoverTelefone_Click(object sender, EventArgs e)
        {
            this._controlador.RemoverTelefoneDoGrid();
        }

        private void tsmiRemoverEnderecos_Click(object sender, EventArgs e)
        {
            this._controlador.RemoverEnderecoDoGrid();
        }

        private void btnBuscaCidade_Click(object sender, EventArgs e)
        {
            this._controlador.BuscarCidade();
        }

        private void btnBuscaCidade_Enter(object sender, EventArgs e)
        {
            this._controlador.BuscarCidade();
        }

        private void TelaCadastroEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6: this._controlador.Gravar(); break;
            }
        }
    }
}
