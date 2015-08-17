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
    public class FachadaCidade : IFachadaCidade
    {
        private ICidadeRepositorio _repositorio;
        private IEstadoRepositorio _repositorioEstado;

        public FachadaCidade(ICidadeRepositorio repositorioCidade, IEstadoRepositorio repositorioEstado)
        {
            this._repositorio = repositorioCidade;
            this._repositorioEstado = repositorioEstado;
        }

        public Boolean AlterarStatus(DTOCidade dtoSelecionado)
        {
            if (dtoSelecionado == null)
                return false;

            Cidade cidade = this._repositorio.Obter(dtoSelecionado.ID);
            cidade.AlteraStatus();
            this._repositorio.Salvar(cidade);

            return true;
        }

        public IEnumerable<DTOCidade> Buscar(String palavraChave = "")
        {
            IEnumerable<Cidade> cidades = this._repositorio.Consultar(new CidadePorParteIdNomeUF(palavraChave, palavraChave, palavraChave));

            if (cidades == null) cidades = this._repositorio.ObterTodos();

            IList<DTOCidade> result = new List<DTOCidade>();

            foreach (Cidade cidade in cidades)
            {
                DTOCidade c = new DTOCidade();
                c.ID = cidade.Id;
                c.Status = cidade.Status;
                c.Nome = cidade.Nome;
                DTOEstado e = new DTOEstado();
                e.ID = cidade.Estado.Id;
                e.Status = cidade.Estado.Status;
                e.UF = cidade.Estado.UF;
                c.Estado = e;                

                result.Add(c);
            }

            if (result.Count <= 0) return null;
            else return result;             
        }

        public Boolean Gravar(DTOCidade dtoCidadeQueVaiSerPersistido)
        {
           if (dtoCidadeQueVaiSerPersistido == null)
               return false;

           Estado estado = this._repositorioEstado.Obter(dtoCidadeQueVaiSerPersistido.Estado.ID);

           Cidade cidadeQueVaiSerPersistida;
           Cidade cidadeEncontradaNoBD = this._repositorio.ObterCidadePorNomeEEstado(new CidadePorNomeEEstado(dtoCidadeQueVaiSerPersistido.Nome, estado));
           ValidadorCidade validador = new ValidadorCidade(cidadeEncontradaNoBD);

           if (dtoCidadeQueVaiSerPersistido.IsNovo())
           {
               cidadeQueVaiSerPersistida = new Cidade(estado, dtoCidadeQueVaiSerPersistido.Nome);
               validador.ValidarNovaCidade(cidadeQueVaiSerPersistida);
           }
           else
           {
               cidadeQueVaiSerPersistida = this._repositorio.Obter(dtoCidadeQueVaiSerPersistido.ID);
               cidadeQueVaiSerPersistida.Nome = dtoCidadeQueVaiSerPersistido.Nome;
               cidadeQueVaiSerPersistida.Estado = this._repositorioEstado.Obter(dtoCidadeQueVaiSerPersistido.Estado.ID);
               validador.ValidarCidadeEmAlteracao(cidadeQueVaiSerPersistida);
           }

           this._repositorio.Salvar(cidadeQueVaiSerPersistida);
           dtoCidadeQueVaiSerPersistido.ID = cidadeQueVaiSerPersistida.Id;
           return true;
        }

        public DTOCidade Obter(long id)
        {
            Cidade cidade = this._repositorio.Obter(id);

            if (cidade == null) { return null; }
            else
            {
                DTOCidade dto = new DTOCidade();
                dto.ID = cidade.Id;
                dto.Nome = cidade.Nome;
                dto.Status = cidade.Status;
                DTOEstado dtoEstado = new DTOEstado();
                dtoEstado.ID = cidade.Estado.Id;
                dtoEstado.Status = cidade.Estado.Status;
                dtoEstado.UF = cidade.Estado.UF;
                dto.Estado = dtoEstado;

                return dto;
            }
        }

        public DTOEstado ObterEstado(long id)
        {
            Estado estado = this._repositorioEstado.Obter(id);

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
