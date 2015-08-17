using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;
using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroServico :ControladorCadastroPadrao<IVisaoCadastroServico, DTOServico>
    {
        private IFachadaServico _fachada;

        public ControladorCadastroServico(IVisaoCadastroServico visao) : base((IVisaoCadastroPadrao)visao) { }

        protected override Boolean AlterarStatus(DTOServico dtoSelecionado)
        {
            return this._fachada.AlterarStatus(dtoSelecionado);
        }

        protected override void AdicionarRegistro(DTOServico dto)
        {
            this._visao.AdicionarServicoNoGrid(dto.ID, dto.Descricao, dto.Valor, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void AlterarRegistro(DTOServico dto)
        {
            this._visao.AlterarServicoNoGrid(dto.Descricao, dto.Valor, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override IEnumerable<DTOServico> Buscar(String palavraChave)
        {
            return this._fachada.Buscar(palavraChave);
        }

        protected override void MandarFocoNoCampoPadrao()
        {
            this._visao.MandarFocoNaDescricao();
        }

        protected override void MostrarDados(DTOServico dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return;

            base._visaoCadastroPadrao.SetID(dtoSelecionado.ID);
            this._visao.SetDescricao(dtoSelecionado.Descricao);
            this._visao.SetValor(dtoSelecionado.Valor);
            base._visaoCadastroPadrao.SetBloqueado(dtoSelecionado.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void CarregarConsulta(IEnumerable<DTOServico> conjuntoDados)
        {
            base._visaoCadastroPadrao.LimparGrid();

            if (conjuntoDados == null)
                return;

            foreach (DTOServico dto in conjuntoDados)
                this._visao.AdicionarServicoNoGrid(dto.ID, dto.Descricao, dto.Valor, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override DTOServico GetDTOQueVaiSerPersistido()
        {
            DTOServico dto = new DTOServico();
            dto.ID = base._visaoCadastroPadrao.GetID();
            dto.Descricao = this._visao.GetDescricao();
            dto.Valor = this._visao.GetValor();

            if (base._visaoCadastroPadrao.GetBloqueado())
                dto.Status = TipoStatus.Bloqueado;
            else
                dto.Status = TipoStatus.Normal;

            return dto;
        }

        protected override DTOServico GetDTOSelecionado()
        {
            return this._fachada.Obter(this._visaoCadastroPadrao.GetIDSelecionado());
        }

        protected override Boolean Gravar(DTOServico dtoQueVaiSerPersistido)
        {
            try
            {
                this._fachada.Gravar(dtoQueVaiSerPersistido);
            }
            catch (Exception ex)
            {
                if (ex is ExcecaoParametroInvalido)
                {
                    if (ex.Message.Contains("Descricao"))
                    {
                        base._visaoPadrao.ExibirErro("Descrição inválida! Verifique.", "edtDescricao");
                        this._visao.MandarFocoNaDescricao();
                    }
                    else if (ex.Message.Contains("Valor"))
                    {
                        base._visaoPadrao.ExibirErro("Valor inválido! Verifique.", "edtValor");
                        this._visao.MandarFocoNoValor();
                    }
                }

                else if (ex is ExcecaoDescricaoServicoJaCadastrada)
                {
                    base._visaoPadrao.ExibirErro(ex.Message, "edtDescricao");
                    this._visao.MandarFocoNaDescricao();
                }

                return false;
            }

            return true;
        }


        protected override void InicializarFachada()
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaServico>();
        }

        protected override IEnumerable<DTOServico> Ordenar(IEnumerable<DTOServico> conjuntoDados)
        {
            try {
                return conjuntoDados.OrderBy(e => e.ID);
            } catch (ArgumentNullException) {
                return null;
            }
        }
    }
}
