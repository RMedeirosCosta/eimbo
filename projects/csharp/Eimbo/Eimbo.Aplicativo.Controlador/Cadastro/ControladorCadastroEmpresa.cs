using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.DTO.Comum;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Comum.Excecao;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroEmpresa :ControladorPadrao<IVisaoCadastroEmpresa>
    {
        private IFachadaEmpresa _fachada;
        private IFachadaCidade _fachadaCidade;

        public ControladorCadastroEmpresa(IVisaoCadastroEmpresa visao) :base(visao) 
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaEmpresa>();
            this._fachadaCidade = ObjectFactory.GetInstance<IFachadaCidade>();
            this.CarregarEmpresaNaTela(this._fachada.ObterEmpresa());
            this._visao.MandarFocoNoNome();
        }

        public void AdicionarDocumentoNoGrid()
        {
            this._visao.AdicionarDocumentoNoGrid(this._visao.GetValorDocumento(), this._visao.GetTipoDocumento());
            this._visao.LimparCamposDocumento();
            this._visao.MandarFocoNoValorDocumento();
        }

        public void AdicionarEnderecoNoGrid()
        {
            this._visao.AdicionarEnderecoNoGrid(this._visao.GetLogradouro(), this._visao.GetNumero(), this._visao.GetCEP(), this._visao.GetIDCidade(), this._visao.GetCidade(), this._visao.GetTipoEndereco());
            this._visao.LimparCamposEndereco();
            this._visao.MandarFocoNoLogradouro();
        }

        public void AdicionarTelefoneNoGrid()
        {
            this._visao.AdicionarTelefoneNoGrid(this._visao.GetTelefone(), this._visao.GetTipoTelefone());
            this._visao.LimparCamposTelefone();
            this._visao.MandarFocoNoTelefone();
        }

        public void BuscarCidade()
        {
            long idCidade;
            String NomeCidade;

            DTOCidade dto = this._fachadaCidade.Obter(this._visao.GetIDCidade());

            if ((dto == null) || (dto.Status.Equals(TipoStatus.Bloqueado)))
            {
                if (this._visao.AchouCidade(out idCidade, out NomeCidade))
                {
                    dto = this._fachadaCidade.Obter(idCidade);

                    if (dto != null)
                    {
                        this._visao.SetIDCidade(dto.ID);
                        this._visao.SetNomeCidade(dto.Nome);
                        this._visao.MandarFocoNoTipoEndereco();
                        return;
                    }
                }

                this._visao.SetIDCidade(0);
                this._visao.MandarFocoNoIDCidade();
            }
            else
            {
                this._visao.SetIDCidade(dto.ID);
                this._visao.SetNomeCidade(dto.Nome);
                this._visao.MandarFocoNoTipoEndereco();
            }
        }


        public void CarregarEmpresaNaTela(DTOPessoa dto)
        {
            if (dto == null)
                return;

            this._visao.SetID(dto.ID);
            this._visao.SetNome(dto.Nome);
            this._visao.SetDtFundacao(dto.DtNascimento);

            this._visao.LimparGridDeDocumentos();
            foreach (DTODocumento doc in dto.Documentos)
                this._visao.AdicionarDocumentoNoGrid(doc.ValorDocumento, NomeTipoDocumento.ObtemString(doc.TipoDocumento));

            this._visao.LimparGridDeTelefones();
            foreach (DTOTelefone tel in dto.Telefones)
                this._visao.AdicionarTelefoneNoGrid(tel.Telefone, NomeTipoTelefone.ObtemString(tel.Tipo));

            this._visao.LimparGridDeEnderecos();
            foreach (DTOEndereco end in dto.Enderecos)
                this._visao.AdicionarEnderecoNoGrid(end.Logradouro, end.Numero, end.Cep.ToStringFormatado(), end.Cidade.ID, end.Cidade.Nome, NomeTipoEndereco.ObtemString(end.TipoEndereco));
        }

        public void Gravar()
        {
            DTOPessoa dto = new DTOPessoa();
            dto.ID = this._visao.GetID();
            dto.Nome = this._visao.GetNome();
            dto.DtNascimento = this._visao.GetDtFundacao();

            IList<String> TiposInválidos = new List<String>();

            for (int i = 0; i < this._visao.GetTotalDeDocumentosDoGrid(); i++)
            {
                DTODocumento dtoDoc = new DTODocumento();
                dtoDoc.ValorDocumento = this._visao.GetValorDocumentoDoGrid(i);

                try
                {
                    dtoDoc.TipoDocumento = NomeTipoDocumento.ObtemTipo(this._visao.GetTipoDocumentoDoGrid(i));
                }
                catch (ExcecaoParametroInvalido)
                {
                    TiposInválidos.Add("Informe um tipo válido para o Documento número " + (i + 1).ToString());
                }

                dto.AdicionarDocumento(dtoDoc);
            }

            for (int i = 0; i < this._visao.GetTotalDeEnderecosDoGrid(); i++)
            {
                DTOEndereco dtoEnd = new DTOEndereco();
                dtoEnd.Logradouro = this._visao.GetLogradouroDoGrid(i);
                dtoEnd.Numero = this._visao.GetNumeroDoGrid(i);
                dtoEnd.Cep = this._visao.GetCEPDoGrid(i);
                dtoEnd.Cidade.ID = this._visao.GetIDCidadeDoGrid(i);
                dtoEnd.Cidade.Nome = this._visao.GetCidadeDoGrid(i);                

                try
                {
                    dtoEnd.TipoEndereco = NomeTipoEndereco.ObtemTipo(this._visao.GetTipoEnderecoDoGrid(i));
                }
                catch (ExcecaoParametroInvalido)
                {
                    TiposInválidos.Add("Informe um tipo válido para o endereço " + (i + 1).ToString());
                }

                dto.AdicionarEndereco(dtoEnd);
            }

            for (int i = 0; i < this._visao.GetTotalDeTelefonesDoGrid(); i++)
            {
                DTOTelefone dtoTel = new DTOTelefone();
                dtoTel.Telefone = this._visao.GetTelefoneDoGrid(i);

                try
                {
                    dtoTel.Tipo = NomeTipoTelefone.ObtemTipo(this._visao.GetTipoTelefoneDoGrid(i));
                }
                catch (ExcecaoParametroInvalido)
                {
                    TiposInválidos.Add("Informe um tipo válido para o telefone " + (i + 1).ToString());
                }

                dto.AdicionarTelefone(dtoTel);
            }

            if (TiposInválidos.Count.CompareTo(0) != 0)
            {                
                string ErrosTiposInvalidos = string.Join("\n", TiposInválidos.ToArray());
                this._visaoPadrao.ExibirErro(ErrosTiposInvalidos);
                return;
            }

            try
            {
                if (this._fachada.Gravar(dto))
                {
                    this._visaoPadrao.Avisar("Empresa gravada com sucesso!");
                    this._visao.VoltarParaTelaAnterior();
                }
            }

            #region Exceções geradas pela classe Pessoa
            #region ExcecaoParametroInvalido
            catch (ExcecaoParametroInvalido ex)
            {
                // Pessoa
                if (ex.Message.Contains("Pessoa"))
                {
                    if (ex.Message.Contains("Nome"))
                    {
                        this._visaoPadrao.ExibirErro("Informe uma razão social válida!", "edtRazaoSocial");
                        this._visao.MandarFocoNoNome();
                    }
                    else if (ex.Message.Contains("DtAniversario"))
                    {
                        this._visaoPadrao.ExibirErro("Informe uma data de fundação válida", "edtDtFundacao");
                        this._visao.MandarFocoNaDtFundacao();
                    }
                }

                // Endereço
                else if (ex.Message.Contains("Endereco"))
                {
                    if (ex.Message.Contains("Logradouro"))
                        this._visaoPadrao.ExibirErro("Informe o logradouro para todos os endereços");

                    else if (ex.Message.Contains("Numero"))
                        this._visaoPadrao.ExibirErro("Informe o número para todos os endereços");

                    else if (ex.Message.Contains("Cep"))
                        this._visaoPadrao.ExibirErro("Informe o CEP para todos os endereços!");

                    else if (ex.Message.Contains("Cidade"))
                        this._visaoPadrao.ExibirErro("Informe a cidade para todos os endereços!");
                }

                // Telefone
                else if (ex.Message.Contains("Telefone"))
                    this._visaoPadrao.ExibirErro("Informe ao menos um telefone válido (xx)xxxx-xxxx para todos os tipos de telefone adicionados!");
            }
            #endregion
            #region ExcecaoDocumentoNaoPermitido
            catch (ExcecaoDocumentoNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoTelefoneNaoPermitido
            catch (ExcecaoTelefoneNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoEnderecoNaoPermitido
            catch (ExcecaoEnderecoNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoParametroRepetido
            catch (ExcecaoParametroRepetido ex)
            {
                if (ex.Message.Contains("Documento"))
                    this._visaoPadrao.ExibirErro("Não é possível cadastrar documentos iguais. Verifique!");

                if (ex.Message.Contains("Telefone"))
                    this._visaoPadrao.ExibirErro("Não é possível cadastrar telefones iguais. Verifique!");

                else if (ex.Message.Contains("Endereco"))
                    this._visaoPadrao.ExibirErro("Não é possível cadastrar endereços iguais. Verifique!");

            }
            #endregion
            #region ExcecaoTipoDocumentoDuplicado
            catch (ExcecaoTipoDocumentoDuplicado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #endregion
            #region Exceções geradas pela class ValidadorEmpresa
            #region ExcecaoCNPJJaCadastrado
            catch (ExcecaoCNPJJaCadastrado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoCNPJNaoInformado
            catch (ExcecaoCNPJNaoInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoNenhumTelefoneInformado
            catch (ExcecaoNenhumTelefoneInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion
            #region ExcecaoEnderecoComercialNaoInformado
            catch (ExcecaoEnderecoComercialNaoInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
            }
            #endregion 
            #endregion
        }

        public void RemoverDocumentoDoGrid()
        {
            this._visao.RemoverDocumentoDoGrid(this._visao.GetLinhaDocumentoSelecionado());
        }

        public void RemoverEnderecoDoGrid()
        {
            this._visao.RemoverEnderecoDoGrid(this._visao.GetLinhaEnderecoSelecionado());
        }

        public void RemoverTelefoneDoGrid()
        {
            this._visao.RemoverTelefoneDoGrid(this._visao.GetLinhaTelefoneSelecionado());
        }

        public void VoltarParaTelaAnterior()
        {
            this._visao.VoltarParaTelaAnterior();
        }
    }
}
