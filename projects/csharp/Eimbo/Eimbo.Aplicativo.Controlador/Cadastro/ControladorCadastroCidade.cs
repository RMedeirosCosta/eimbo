using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Aplicativo.Visao.Comum;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroCidade :ControladorCadastroPadrao<IVisaoCadastroCidade,DTOCidade>
    {
        private IFachadaCidade _fachada;

        public ControladorCadastroCidade(IVisaoCadastroCidade visao) : base((IVisaoCadastroPadrao)visao) { }

        protected override Boolean AlterarStatus(DTOCidade dtoSelecionado)
        {
            return this._fachada.AlterarStatus(dtoSelecionado);            
        }

        protected override void AdicionarRegistro(DTOCidade dto)
        {
            this._visao.AdicionarCidadeNoGrid(dto.ID, dto.Nome, dto.Estado.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void AlterarRegistro(DTOCidade dto)
        {
            this._visao.AlterarCidadeNoGrid(dto.Nome, dto.Estado.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override IEnumerable<DTOCidade> Buscar(String palavraChave)
        {
            return this._fachada.Buscar(palavraChave);
        }

        protected override void MandarFocoNoCampoPadrao()
        {
            this._visao.MandarFocoNoNome();
        }

        protected override void MostrarDados(DTOCidade dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return;

            base._visaoCadastroPadrao.SetID(dtoSelecionado.ID);
            base._visaoCadastroPadrao.SetBloqueado(dtoSelecionado.Status.Equals(TipoStatus.Bloqueado));
            this._visao.SetIDEstado(dtoSelecionado.Estado.ID);
            this._visao.SetNome(dtoSelecionado.Nome);
            this._visao.SetUF(dtoSelecionado.Estado.UF);
        }

        protected override void CarregarConsulta(IEnumerable<DTOCidade> conjuntoDados)
        {
            base._visaoCadastroPadrao.LimparGrid();

            if (conjuntoDados == null) 
                return;

            foreach (DTOCidade dto in conjuntoDados)
                this._visao.AdicionarCidadeNoGrid(dto.ID, dto.Nome, dto.Estado.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override DTOCidade GetDTOQueVaiSerPersistido()
        {
            DTOCidade dto = new DTOCidade();
            DTOEstado dtoEstado = new DTOEstado();

            dto.ID = base._visaoCadastroPadrao.GetID();
            dto.Nome = this._visao.GetNome();
            long idEstado; long.TryParse(this._visao.GetIDEstado(), out idEstado);
            dtoEstado.ID = idEstado;
            dtoEstado.UF = this._visao.GetUF();
            dto.Estado = dtoEstado;

            if (base._visaoCadastroPadrao.GetBloqueado())
                dto.Status = TipoStatus.Bloqueado;
            else
                dto.Status = TipoStatus.Normal;

            return dto;
        }

        protected override DTOCidade GetDTOSelecionado()
        {
            return this._fachada.Obter(base._visaoCadastroPadrao.GetIDSelecionado());
        }

        protected override Boolean Gravar(DTOCidade dtoQueVaiSerPersistido)
        {
            try
            {
                this._fachada.Gravar(dtoQueVaiSerPersistido);
            }
            catch (Exception ex)
            {
                if (ex is ExcecaoParametroInvalido)
                {
                    if (ex.Message.Contains("nome"))
                    {
                        base._visaoPadrao.ExibirErro("Nome está inválido ou não informado!", "edtNome");
                        base._visao.MandarFocoNoNome();
                    }

                    else if (ex.Message.Contains("estado"))
                    {
                        base._visaoPadrao.ExibirErro("Estado inválido ou não informado!", "edtIDEstado");
                        base._visao.MandarFocoNoIDEstado();
                    }

                }
                else if (ex is ExcecaoEntidadeRepetida)
                {
                    base._visaoPadrao.ExibirErro(ex.Message, "edtNome");
                    base._visao.MandarFocoNoNome();
                }

                return false;
            }

            return true;
        }

        public String GetNomeSelecionada()
        {
            DTOCidade dto = this.GetDTOSelecionado();

            if (dto == null)
                return String.Empty;

            return dto.Nome;
        }


        public void BuscaEstado(long idEstado)
        {
            String UF;

            DTOEstado dtoEstado = _fachada.ObterEstado(idEstado);

            if ((dtoEstado == null) || (dtoEstado.Status.Equals(TipoStatus.Bloqueado)))
            {
                if (this._visao.AchouEstado(out idEstado, out UF))
                {
                    dtoEstado = _fachada.ObterEstado(idEstado);

                    if (dtoEstado != null)
                    {
                        this._visao.SetIDEstado(idEstado);
                        this._visao.SetUF(UF);
                        return;
                    }
                }

                this._visao.SetUF(String.Empty);
                this._visao.MandarFocoNoIDEstado();
            }
            else
            {
                this._visao.SetIDEstado(dtoEstado.ID);
                this._visao.SetUF(dtoEstado.UF);
            }
        }

        protected override void InicializarFachada()
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCidade>();
        }

        protected override IEnumerable<DTOCidade> Ordenar(IEnumerable<DTOCidade> conjuntoDados)
        {
            try
            {
                return conjuntoDados.OrderBy(e => e.ID);
            }
            // Caso se a lista já vier nula
            catch (ArgumentNullException)
            {
                return null;
            }
            
        }
    }
    
}
