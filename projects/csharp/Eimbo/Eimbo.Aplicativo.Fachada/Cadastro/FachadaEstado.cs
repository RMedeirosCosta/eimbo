using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.Cadastro.ObjetoValor;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;


namespace Eimbo.Dominio.Fachada.Cadastro
{
    public class FachadaEstado :IFachadaEstado
    {
        private IEstadoRepositorio _repositorio;

        public FachadaEstado(IEstadoRepositorio repositorio)
        {
            this._repositorio = repositorio;                
        }

        public Boolean AlterarStatus(DTOEstado dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return false;

            Estado estado = this._repositorio.Obter(dtoSelecionado.ID);
            estado.AlteraStatus();
            this._repositorio.Salvar(estado);
            return true;
        }

        public IEnumerable<DTOEstado> Buscar(String palavraChave = "")
        {
            IEnumerable<Estado> estados = this._repositorio.Consultar(new EstadoPorParteIdEUF(palavraChave, palavraChave));

            if (estados == null) estados = this._repositorio.ObterTodos();

            IList<DTOEstado> result = new List<DTOEstado>();

            foreach(Estado estado in estados) 
            {
                DTOEstado d = new DTOEstado();
                d.ID = estado.Id;
                d.Status = estado.Status;
                d.UF = estado.UF;

                result.Add(d);
            }

            if (result.Count <= 0) return null;
            else                   return result;             
        }

        public Boolean Gravar(DTOEstado dtoEstadoQueVaiSerPersistido)
        {
            if (dtoEstadoQueVaiSerPersistido == null) 
                return false;

            Estado estado = _repositorio.Obter(dtoEstadoQueVaiSerPersistido.ID);

            if (estado == null) estado = new Estado(dtoEstadoQueVaiSerPersistido.UF);
            else                estado.UF = dtoEstadoQueVaiSerPersistido.UF;

            Estado estadoEncontradoNoBD = _repositorio.ObterEstadoPorUF(new EstadoPorUF(dtoEstadoQueVaiSerPersistido.UF));

            ValidadorEstado servico = new ValidadorEstado(estadoEncontradoNoBD);

            if (dtoEstadoQueVaiSerPersistido.IsNovo()) servico.ValidarEstadoNovo(estado);
            else servico.ValidarEstadoAlterado(estado);

            this._repositorio.Salvar(estado);
            dtoEstadoQueVaiSerPersistido.ID = estado.Id;

            return true;
        }

        public DTOEstado Obter(long id)
        {
            Estado estado = this._repositorio.Obter(id);

            if (estado == null) { return null; }
            else
            {
                DTOEstado dto = new DTOEstado();
                dto.ID = estado.Id;
                dto.Status = estado.Status;
                dto.UF = estado.UF;

                return dto;
            }
        }
    }
}
