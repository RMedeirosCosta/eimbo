using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Contrato.Cadastro;
using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.DTO.Comum;
using Eimbo.Dominio.Cadastro.ObjetoValor;
using Eimbo.Dominio.Cadastro.Repositorio;
using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Fachada.Cadastro
{
    public class FachadaPessoa :IFachadaPessoa
    {
        protected IPessoaRepositorio _repositorio;
        protected ICidadeRepositorio _repositorioCidade;
        protected IFachadaCidade _fachadaCidade;

        protected FachadaPessoa() { }
        
        public FachadaPessoa(IPessoaRepositorio repositorio, ICidadeRepositorio repositorioCidade, IFachadaCidade fachadaCidade)
        {
            this._repositorio = repositorio;
            this._repositorioCidade = repositorioCidade;
            this._fachadaCidade = fachadaCidade;
        }

        protected DTOPessoa ConverteEntidadeParaDTO(Pessoa entidade)
        {
            DTOPessoa dto = null;

            if (entidade != null)
            {
                dto = new DTOPessoa();
                dto.ID = entidade.Id;
                dto.DtNascimento = entidade.DtNascimento;
                dto.Nome = entidade.Nome;
                dto.Status = entidade.Status;

                foreach (Documento doc in entidade.Documentos)
                {
                    DTODocumento dtoDoc = new DTODocumento();
                    dtoDoc.ValorDocumento = doc.ToStringFormatado();
                    dtoDoc.TipoDocumento = doc.TipoDocumento;

                    dto.AdicionarDocumento(dtoDoc);
                }

                foreach (Telefone tel in entidade.Telefones)
                {
                    DTOTelefone dtoTel = new DTOTelefone();
                    dtoTel.Telefone = tel.ToStringFormatado();
                    dtoTel.Tipo = tel.Tipo;

                    dto.AdicionarTelefone(dtoTel);
                }

                foreach (Endereco end in entidade.Enderecos)
                {
                    DTOEndereco dtoEnd = new DTOEndereco();
                    dtoEnd.Logradouro = end.Logradouro;
                    dtoEnd.Numero = end.Numero;
                    dtoEnd.TipoEndereco = end.TipoEndereco;
                    dtoEnd.Cep = end.Cep;
                    DTOCidade dtoCidade = _fachadaCidade.Obter(end.Cidade.Id);
                    dtoEnd.Cidade = dtoCidade;

                    dto.AdicionarEndereco(dtoEnd);
                }
            }

            return dto;
        }

        public DTOPessoa Obter(long id)
        {
            Pessoa pessoa = this._repositorio.Obter(id);
            return this.ConverteEntidadeParaDTO(pessoa);
        }
    }
}
