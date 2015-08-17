using System;
using System.Collections.Generic;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.Cadastro.ObjetoValor;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.Fachada.Cadastro
{
    public class FachadaServico :IFachadaServico
    {
        private IServicoRepositorio _repositorio;

        public FachadaServico(IServicoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Boolean AlterarStatus(DTOServico dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return false;

            Servico servico = this._repositorio.Obter(dtoSelecionado.ID);
            servico.AlteraStatus();
            this._repositorio.Salvar(servico);
            return true;
        }

        public IEnumerable<DTOServico> Buscar(String palavraChave = "")
        {
            IEnumerable<Servico> servicos = this._repositorio.Consultar(new ServicoPorParteIdDescricao(palavraChave, palavraChave));

            if (servicos == null) servicos = this._repositorio.ObterTodos();

            IList<DTOServico> result = new List<DTOServico>();

            foreach (Servico servico in servicos)
            {
                DTOServico d = new DTOServico();
                d.ID = servico.Id;                
                d.Status = servico.Status;
                d.Descricao = servico.Descricao;
                d.Valor = servico.Valor;

                result.Add(d);
            }

            if (result.Count <= 0) return null;
            else return result;
        }

        public Boolean Gravar(DTOServico dtoServicoQueVaiSerPersistido)
        {
            if (dtoServicoQueVaiSerPersistido == null)
                return false;

            Servico servico = this._repositorio.Obter(dtoServicoQueVaiSerPersistido.ID);

            if (servico == null) servico = new Servico(dtoServicoQueVaiSerPersistido.Descricao, dtoServicoQueVaiSerPersistido.Valor);
            else
            {
                servico.Descricao = dtoServicoQueVaiSerPersistido.Descricao;
                servico.Valor = dtoServicoQueVaiSerPersistido.Valor;
            }

            Servico servicoEncontradoNoBD = this._repositorio.ObterServicoPelaDescricao(dtoServicoQueVaiSerPersistido.Descricao);

            ValidadorServico validador = new ValidadorServico(servicoEncontradoNoBD);

            if (dtoServicoQueVaiSerPersistido.IsNovo()) validador.ValidarNovoServico(servico);
            else validador.ValidarServicoEmAlteracao(servico);

            this._repositorio.Salvar(servico);
            dtoServicoQueVaiSerPersistido.ID = servico.Id;

            return true;
        }

        public DTOServico Obter(long id)
        {
            Servico servico = this._repositorio.Obter(id);

            if (servico == null) { return null; }
            else
            {
                DTOServico dto = new DTOServico();
                dto.ID = servico.Id;
                dto.Status = servico.Status;
                dto.Descricao = servico.Descricao;
                dto.Valor = servico.Valor;

                return dto;
            }

        }
    }
}
