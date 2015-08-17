using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroFormaPagamento :ControladorCadastroPadrao<IVisaoCadastroFormaPagamento, DTOFormaPagamento>
    {
        private IFachadaFormaPagamento _fachada;

        public ControladorCadastroFormaPagamento(IVisaoCadastroFormaPagamento visao) :base((IVisaoCadastroPadrao)visao) { }

        protected override bool AlterarStatus(DTOFormaPagamento dtoSelecionado)
        {
            return this._fachada.AlterarStatus(dtoSelecionado);
        }

        protected override void AdicionarRegistro(DTOFormaPagamento dto)
        {
            this._visao.AdicionarFormaPagamentoNoGrid(dto.ID, dto.Descricao, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void AlterarRegistro(DTOFormaPagamento dto)
        {
            this._visao.AlterarFormaPagamentoNoGrid(dto.Descricao, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override IEnumerable<DTOFormaPagamento> Buscar(String palavraChave)
        {
            return this._fachada.Buscar(palavraChave);
        }

        protected override void MandarFocoNoCampoPadrao()
        {
            this._visao.MandarFocoNaDescricao();
        }

        protected override void MostrarDados(DTOFormaPagamento dtoSelecionado)
        {
            this._visao.HabilitarGrupoParcelamento(false);

            if (dtoSelecionado == null)
                return;

            base._visaoCadastroPadrao.SetID(dtoSelecionado.ID);
            base._visaoCadastroPadrao.SetBloqueado(dtoSelecionado.Status.Equals(TipoStatus.Bloqueado));
            this._visao.SetDescricao(dtoSelecionado.Descricao);

            if (dtoSelecionado.Tipo.Equals(TipoFormaPagamento.Vista))
                this._visao.SetTipo(0);
            else
                this._visao.SetTipo(1);

            this._visao.SetPercentualAcrescimo(dtoSelecionado.PercentualAcrescimo);
            this._visao.SetPercentualDesconto(dtoSelecionado.PercentualDesconto);

            if (dtoSelecionado.Parcelamento != null)
            {
                if (dtoSelecionado.Parcelamento.Tipo.Equals(TipoParcelamentoFormaPagamento.ComEntrada))
                    this._visao.SetTipoParcelamento(0);
                else
                    this._visao.SetTipoParcelamento(1);

                this._visao.SetQuantidadeParcelas(dtoSelecionado.Parcelamento.QuantidadeParcelas);
                this._visao.SetIntervaloEntreParcelas(dtoSelecionado.Parcelamento.IntervaloEntreParcelas);
            }
        }

        protected override void CarregarConsulta(IEnumerable<DTOFormaPagamento> conjuntoDados)
        {
            base._visaoCadastroPadrao.LimparGrid();

            if (conjuntoDados == null)
                return;

            foreach (DTOFormaPagamento dto in conjuntoDados)
                this._visao.AdicionarFormaPagamentoNoGrid(dto.ID, dto.Descricao, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override DTOFormaPagamento GetDTOQueVaiSerPersistido()
        {
            DTOFormaPagamento dto = new DTOFormaPagamento();
            dto.ID = base._visaoCadastroPadrao.GetID();
            dto.Descricao = this._visao.GetDescricao();

            if (base._visaoCadastroPadrao.GetBloqueado())
                dto.Status = TipoStatus.Bloqueado;
            else
                dto.Status = TipoStatus.Normal;

            dto.PercentualAcrescimo = this._visao.GetPercentualAcrescimo();
            dto.PercentualDesconto = this._visao.GetPercentualDesconto();

            if (this._visao.GetTipo().Equals(0))
                dto.Tipo = TipoFormaPagamento.Vista;
            else if (this._visao.GetTipo().Equals(1))
            {
                dto.Tipo = TipoFormaPagamento.Prazo;

                TipoParcelamentoFormaPagamento tipoParcelamentoEscolhido;

                if (this._visao.GetTipoParcelamento().Equals(0))
                    tipoParcelamentoEscolhido = TipoParcelamentoFormaPagamento.ComEntrada;
                else if (this._visao.GetTipoParcelamento().Equals(1))
                    tipoParcelamentoEscolhido = TipoParcelamentoFormaPagamento.SemEntrada;
                else
                    tipoParcelamentoEscolhido = TipoParcelamentoFormaPagamento.Nenhum;

                dto.Parcelamento = new ParcelamentoFormaPagamento(tipoParcelamentoEscolhido, this._visao.GetQuantidadeParcelas(), this._visao.GetIntervaloEntreParcelas());
            }
            else
                dto.Tipo = TipoFormaPagamento.Nenhum;

            return dto;
        }


        protected override DTOFormaPagamento GetDTOSelecionado()
        {
            return this._fachada.Obter(this._visaoCadastroPadrao.GetIDSelecionado());
        }

        protected override Boolean Gravar(DTOFormaPagamento dtoQueVaiSerPersistido)
        {
            try
            {
                this._fachada.Gravar(dtoQueVaiSerPersistido);
            }
            catch (Exception ex)
            {
                #region ExcecaoParametroInvalido
                if (ex is ExcecaoParametroInvalido)
                {
                    if (ex.Message.Contains("Descricao"))
                    {
                        base._visaoPadrao.ExibirErro("Descrição inválida! Verifique.", "edtDescricao");
                        this._visao.MandarFocoNaDescricao();
                    }
                    else if (ex.Message.Contains("Acrescimo"))
                    {
                        base._visaoPadrao.ExibirErro("Acréscimo inválido! Verifique.", "edtPercentualAcrescimo");
                        this._visao.MandarFocoNoAcrescimo();
                    }

                    else if (ex.Message.Contains("Desconto"))
                    {
                        base._visaoPadrao.ExibirErro("Desconto inválido! Verifique.", "edtPercentualDesconto");
                        this._visao.MandarFocoNoDesconto();
                    }

                    else if (ex.Message.Contains("Parcelamento"))
                        base._visaoPadrao.ExibirErro("Opções de parcelamento estão inválidas! Verifique.");

                    else if (ex.Message.Contains("IntervaloParcelas"))
                    {
                        base._visaoPadrao.ExibirErro("Intervalo entre parcelas está inválido ou não foi informado! Verifique.", "edtIntervaloEntreParcelas");
                        this._visao.MandarFocoNoIntervaloEntreParcelas();
                    }

                    else if (ex.Message.Contains("QuantidadeParcelas"))
                    {
                        base._visaoPadrao.ExibirErro("Quantidade de parcelas está inválido ou não foi informado! Verifique.", "edtQuantidadeParcelas");
                        this._visao.MandarFocoNaQuantidadeDeParcelas();
                    }

                    else if (ex.Message.Contains("Tipo"))
                        base._visaoPadrao.ExibirErro("Tipo da forma de pagamento está inválido ou não foi informado! Verifique.");

                    else if (ex.Message.Contains("TipoParcelamento"))
                        base._visaoPadrao.ExibirErro("Tipo do parcelamento está inválido ou não foi informado! Verifique.");
                    
                }
                #endregion

                else if (ex is ExcecaoCampoObrigatorioNaoInformado)
                    base._visaoPadrao.ExibirErro("É necessário informar o parcelamento para forma de pagamento a prazo!");

                else
                    base._visaoPadrao.ExibirErro(ex.Message);

                return false;
            }

            return true;
        }

        protected override void InicializarFachada()
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaFormaPagamento>();
        }

        protected override IEnumerable<DTOFormaPagamento> Ordenar(IEnumerable<DTOFormaPagamento> conjuntoDados)
        {
            try
            {
                return conjuntoDados.OrderBy(e => e.ID);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public void AlterarTipo(int Tipo)
        {

        }
    }
}
