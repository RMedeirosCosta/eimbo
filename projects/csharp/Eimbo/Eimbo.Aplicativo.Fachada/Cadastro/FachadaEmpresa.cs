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
    public class FachadaEmpresa :FachadaPessoa, IFachadaEmpresa
    {
        public FachadaEmpresa(IPessoaRepositorio repositorio, ICidadeRepositorio repositorioCidade, IFachadaCidade fachadaCidade) : base(repositorio, repositorioCidade, fachadaCidade) { }

        public Boolean Gravar(DTOPessoa dtoEmpresaQueVaiSerPersistida)
        {
            if (dtoEmpresaQueVaiSerPersistida == null)
                return false;

            Pessoa pessoa = this._repositorio.Obter(dtoEmpresaQueVaiSerPersistida.ID);

            if (pessoa == null)
                pessoa = new Empresa(dtoEmpresaQueVaiSerPersistida.Nome, dtoEmpresaQueVaiSerPersistida.DtNascimento);
            else
            {
                pessoa.Nome = dtoEmpresaQueVaiSerPersistida.Nome;
                pessoa.DtNascimento = dtoEmpresaQueVaiSerPersistida.DtNascimento;
            }

            pessoa.LimparColecoes();
            foreach (DTODocumento dto in dtoEmpresaQueVaiSerPersistida.Documentos)
                pessoa.AdicionaDocumento(dto.ConverteDTOParaDocumento());

            foreach (DTOTelefone dto in dtoEmpresaQueVaiSerPersistida.Telefones)
                pessoa.AdicionaTelefone(dto.ConverteDTOParaTelefone());

            foreach (DTOEndereco dto in dtoEmpresaQueVaiSerPersistida.Enderecos)
                pessoa.AdicionaEndereco(dto.ConverteDTOParaEndereco(x => this._repositorioCidade.Obter(x.ID)));

            DTODocumento dtoDocumento = dtoEmpresaQueVaiSerPersistida.Documentos.SingleOrDefault(d => (d.TipoDocumento.Equals(TipoDocumento.CNPJ)));
            CNPJ cnpj;

            try
            {
                cnpj = dtoDocumento.ValorDocumento;
            }
            catch (NullReferenceException)
            {
                cnpj = null;
            }

            Pessoa pessoaComOMesmoCNPJ = this._repositorio.ObterPorDocumento(cnpj);
            Empresa empresaEncontradaNoBD;

            if (pessoaComOMesmoCNPJ != null)
                empresaEncontradaNoBD = (Empresa)pessoaComOMesmoCNPJ;
            else
                empresaEncontradaNoBD = null;

            // Efetuando as validações
            ValidadorEmpresa validador = new ValidadorEmpresa(empresaEncontradaNoBD);

            Empresa empresaQueVaiSerPersistida = (Empresa)pessoa;
            validador.ValidarCamposObrigatorios(empresaQueVaiSerPersistida);

            if (dtoEmpresaQueVaiSerPersistida.IsNovo())
                validador.ValidarDuplicidadeCNPJDeNovaEmpresa(empresaQueVaiSerPersistida);
            else
                validador.ValidarDuplicidadeCNPJDeEmpresaEmAlteracao(empresaQueVaiSerPersistida);

            this._repositorio.Salvar(pessoa);
            dtoEmpresaQueVaiSerPersistida.ID = pessoa.Id; ;

            return true;

        }

        public DTOPessoa ObterEmpresa()
        {
            try
            {
                return this.ConverteEntidadeParaDTO(this._repositorio.Consultar(new EmpresaCadastrada()).SingleOrDefault());
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
