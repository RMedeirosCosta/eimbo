using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.DTO.Comum;
using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroCliente :ControladorCadastroPadrao<IVisaoCadastroCliente, DTOPessoa>
    {
        private IFachadaCliente _fachada;
        private IFachadaCidade _fachadaCidade;

        public ControladorCadastroCliente(IVisaoCadastroCliente visao) : base((IVisaoCadastroPadrao)visao) { }

        protected override Boolean AlterarStatus(DTOPessoa dtoSelecionado)
        {
            return this._fachada.AlterarStatus(dtoSelecionado);
        }

        protected override void AdicionarRegistro(DTOPessoa dto)
        {
            this._visao.AdicionarClienteNoGrid(dto.ID, dto.Nome, dto.Status.Equals(TipoStatus.Bloqueado));
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

        protected override void AlterarRegistro(DTOPessoa dto)
        {
            this._visao.AlterarClienteNoGrid(dto.Nome, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override IEnumerable<DTOPessoa> Buscar(String palavraChave)
        {
            return this._fachada.Buscar(palavraChave);
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

        protected override void MandarFocoNoCampoPadrao()
        {
            this._visao.MandarFocoNoNome();
        }

        protected override void MostrarDados(DTOPessoa dto)
        {
            if (dto == null)
                return;

            this._visao.SetID(dto.ID);
            this._visao.SetNome(dto.Nome);
            this._visao.SetDtNascimento(dto.DtNascimento);
            base._visaoCadastroPadrao.SetBloqueado(dto.Status.Equals(TipoStatus.Bloqueado));

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

        protected override void CarregarConsulta(IEnumerable<DTOPessoa> conjuntoDados)
        {
            base._visaoCadastroPadrao.LimparGrid();

            if (conjuntoDados == null)
                return;

            foreach (DTOPessoa dto in conjuntoDados)
                this._visao.AdicionarClienteNoGrid(dto.ID, dto.Nome, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override DTOPessoa GetDTOQueVaiSerPersistido()
        {
            DTOPessoa dto = new DTOPessoa();
            dto.ID = this._visao.GetID();
            dto.Nome = this._visao.GetNome();
            dto.DtNascimento = this._visao.GetDtNascimento();

            if (base._visaoCadastroPadrao.GetBloqueado())
                dto.Status = TipoStatus.Bloqueado;
            else
                dto.Status = TipoStatus.Normal;

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
                return null;
            }

            return dto;
        }

        protected override DTOPessoa GetDTOSelecionado()
        {
            return this._fachada.Obter(base._visaoCadastroPadrao.GetIDSelecionado());
        }

        protected override void InicializarFachada()
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCliente>();
            this._fachadaCidade = ObjectFactory.GetInstance<IFachadaCidade>();
        }

        protected override IEnumerable<DTOPessoa> Ordenar(IEnumerable<DTOPessoa> conjuntoDados)
        {
            try {
                return conjuntoDados.OrderBy(e => e.ID);
            } catch (ArgumentNullException) {
                return null;
            }
        }

        protected override Boolean Gravar(DTOPessoa dtoQueVaiSerPersistido)
        {
            try
            {
                this._fachada.Gravar(dtoQueVaiSerPersistido);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
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
                        this._visaoPadrao.ExibirErro("Informe um nome válido!", "edtNome");
                        this._visao.MandarFocoNoNome();
                    }
                    else if (ex.Message.Contains("DtAniversario"))
                    {
                        this._visaoPadrao.ExibirErro("Informe uma data de nascimento válida", "edtDtAniversario");
                        this._visao.MandarFocoNaDtNascimento();
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
                    this._visaoPadrao.ExibirErro("Informe um telefone válido (xx)xxxx-xxxx para todos os telefones");

                return false;
            }
            #endregion
            #region ExcecaoDocumentoNaoPermitido
            catch (ExcecaoDocumentoNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #region ExcecaoTelefoneNaoPermitido
            catch (ExcecaoTelefoneNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #region ExcecaoEnderecoNaoPermitido
            catch (ExcecaoEnderecoNaoPermitido ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
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

                return false;
            }
            #endregion
            #region ExcecaoTipoDocumentoDuplicado
            catch (ExcecaoTipoDocumentoDuplicado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #endregion
            #region Exceções geradas pela class ValidadorEmpresa
            #region ExcecaoCPFJaCadastrado
            catch (ExcecaoCPFJaCadastrado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #region ExcecaoCNPJNaoInformado
            catch (ExcecaoCPFNaoInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #region ExcecaoNenhumTelefoneInformado
            catch (ExcecaoNenhumTelefoneInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
            }
            #endregion
            #region ExcecaoNenhumEnderecoInformado
            catch (ExcecaoNenhumEnderecoInformado ex)
            {
                this._visaoPadrao.ExibirErro(ex.Message);
                return false;
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
    }
}
