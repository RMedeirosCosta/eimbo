using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Aplicativo.Visao.Cadastro;
using Eimbo.Aplicativo.Visao.Comum;

using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Tipo;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.Cadastro
{
    public class ControladorCadastroEstado :ControladorCadastroPadrao<IVisaoCadastroEstado,DTOEstado>
    {
        private IFachadaEstado _fachada;

        public ControladorCadastroEstado(IVisaoCadastroEstado visao) : base((IVisaoCadastroPadrao)visao) { }        

        protected override Boolean AlterarStatus(DTOEstado dtoSelecionado)
        {
            return this._fachada.AlterarStatus(dtoSelecionado);
        }

        protected override void AdicionarRegistro(DTOEstado dto)
        {
            this._visao.AdicionarEstadoNoGrid(dto.ID, dto.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void AlterarRegistro(DTOEstado dto)
        {
            this._visao.AlterarEstadoNoGrid(dto.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override IEnumerable<DTOEstado> Buscar(String palavraChave)
        {
            return this._fachada.Buscar(palavraChave);
        }

        protected override void MandarFocoNoCampoPadrao()
        {
            this._visao.MandarFocoNaUF();
        }

        protected override void MostrarDados(DTOEstado dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return;

            base._visaoCadastroPadrao.SetID(dtoSelecionado.ID);
            this._visao.SetUF(dtoSelecionado.UF);
            base._visaoCadastroPadrao.SetBloqueado(dtoSelecionado.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override void CarregarConsulta(IEnumerable<DTOEstado> conjuntoDados)
        {
            base._visaoCadastroPadrao.LimparGrid();

            if (conjuntoDados == null)
                return;

            foreach (DTOEstado dto in conjuntoDados)                
                this._visao.AdicionarEstadoNoGrid(dto.ID, dto.UF, dto.Status.Equals(TipoStatus.Bloqueado));
        }

        protected override DTOEstado GetDTOQueVaiSerPersistido()
        {
            DTOEstado dto = new DTOEstado();
            dto.ID = base._visaoCadastroPadrao.GetID();
            dto.UF = this._visao.GetUF();

            if (base._visaoCadastroPadrao.GetBloqueado())
                dto.Status = TipoStatus.Bloqueado;
            else
                dto.Status = TipoStatus.Normal;

            return dto;
        }

        protected override DTOEstado GetDTOSelecionado()
        {
            return this._fachada.Obter(this._visaoCadastroPadrao.GetIDSelecionado());
        }

        protected override Boolean Gravar(DTOEstado dtoQueVaiSerPersistido)
        {
            try {
                this._fachada.Gravar(dtoQueVaiSerPersistido);                
            } catch (Exception ex) {
                if (ex is ExcecaoParametroInvalido)
                {
                    if (ex.Message.Contains("uf"))
                    {
                        base._visaoPadrao.ExibirErro("UF inválida ou não informada!", "edtUF");
                        base._visao.MandarFocoNaUF();
                    }
                }
                else if (ex is ExcecaoEntidadeRepetida)
                {
                    base._visaoPadrao.ExibirErro(ex.Message, "edtUF");
                    base._visao.MandarFocoNaUF();
                }

                return false;
            }

            return true;
        }

        protected override void InicializarFachada()
        {
 	        this._fachada = ObjectFactory.GetInstance<IFachadaEstado>();
        }

        public String GetUFSelecionada()
        {
            DTOEstado dto = this.GetDTOSelecionado();

            if (dto == null)
                return String.Empty;

            return dto.UF;
        }

        protected override IEnumerable<DTOEstado> Ordenar(IEnumerable<DTOEstado> conjuntoDados)
        {
            try {
                return conjuntoDados.OrderBy(e => e.ID);
            } catch(ArgumentNullException) {
                return null;
            }
        }
    }
}
