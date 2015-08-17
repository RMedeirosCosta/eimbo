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
    public class FachadaCliente :FachadaPessoa, IFachadaCliente
    {
        public FachadaCliente(IPessoaRepositorio repositorio, ICidadeRepositorio repositorioCidade, IFachadaCidade fachadaCidade) : base(repositorio, repositorioCidade, fachadaCidade) { }

        public Boolean AlterarStatus(DTOPessoa dtoSelecionado)
        {
            Pessoa cliente = this._repositorio.Obter(dtoSelecionado.ID);
            cliente.AlteraStatus();

            return true;           
        }

        public IEnumerable<DTOPessoa> Buscar(String palavraChave = "")
        {
            IEnumerable<Pessoa> clientes = this._repositorio.Consultar(new ClientePorParteIDNome(palavraChave, palavraChave));

            if (clientes == null) clientes = this._repositorio.ObterTodos();

            IList<DTOPessoa> result = new List<DTOPessoa>();

            foreach (Pessoa cliente in clientes)
                result.Add(this.ConverteEntidadeParaDTO(cliente));

            if (result.Count <= 0) return null;
            else return result;             
        }

        public Boolean Gravar(DTOPessoa dtoClienteQueVaiSerPersistido)
        {
            if (dtoClienteQueVaiSerPersistido == null)
                return false;

            Pessoa pessoa = this._repositorio.Obter(dtoClienteQueVaiSerPersistido.ID);

            if (pessoa == null)
                pessoa = new Cliente(dtoClienteQueVaiSerPersistido.Nome, dtoClienteQueVaiSerPersistido.DtNascimento);
            else
            {
                pessoa.Nome = dtoClienteQueVaiSerPersistido.Nome;
                pessoa.DtNascimento = dtoClienteQueVaiSerPersistido.DtNascimento;
            }

            pessoa.LimparColecoes();
            foreach (DTODocumento dto in dtoClienteQueVaiSerPersistido.Documentos)
                pessoa.AdicionaDocumento(dto.ConverteDTOParaDocumento());

            foreach (DTOTelefone dto in dtoClienteQueVaiSerPersistido.Telefones)
                pessoa.AdicionaTelefone(dto.ConverteDTOParaTelefone());

            foreach (DTOEndereco dto in dtoClienteQueVaiSerPersistido.Enderecos)
                pessoa.AdicionaEndereco(dto.ConverteDTOParaEndereco(x => this._repositorioCidade.Obter(x.ID)));

            DTODocumento dtoDocumento = dtoClienteQueVaiSerPersistido.Documentos.SingleOrDefault(d => (d.TipoDocumento.Equals(TipoDocumento.CPF)));
            CPF cpf;

            try
            {
                cpf = dtoDocumento.ValorDocumento;
            }
            catch (NullReferenceException)
            {
                cpf = null;
            }

            Pessoa pessoaComOMesmoCPF = this._repositorio.ObterPorDocumento(cpf);
            Cliente clienteEncontradoNoBD;

            try
            {
                if (pessoaComOMesmoCPF != null)
                    clienteEncontradoNoBD = (Cliente)pessoaComOMesmoCPF;
                else
                    clienteEncontradoNoBD = null;
            }
            catch (InvalidCastException)
            {
                clienteEncontradoNoBD = null;
            }

            // Efetuando as validações
            ValidadorCliente validador = new ValidadorCliente(clienteEncontradoNoBD);

            Cliente clienteQueVaiSerPersistido = (Cliente)pessoa;
            validador.ValidarCamposObrigatorios(clienteQueVaiSerPersistido);

            if (dtoClienteQueVaiSerPersistido.IsNovo())
                validador.ValidarDuplicidadeCPFDeNovoCliente(clienteQueVaiSerPersistido);
            else
                validador.ValidarDuplicidadeCPFDeClienteEmAlteracao(clienteQueVaiSerPersistido);

            this._repositorio.Salvar(pessoa);
            dtoClienteQueVaiSerPersistido.ID = pessoa.Id; ;

            return true;
        }

        public new DTOPessoa Obter(long id)
        {
            Pessoa pessoa = this._repositorio.Obter(id);

            try
            {
                if (!pessoa.TipoCadastroPessoa.Equals(TipoCadastroPessoa.Cliente))
                    return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            return this.ConverteEntidadeParaDTO(pessoa);
        }

    }
}
