using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorCliente
    {
        private Cliente _clienteEncontradoNoBancoDeDados;

        public ValidadorCliente(Cliente clienteEncontradoNoBancoDeDados)
        {
            this._clienteEncontradoNoBancoDeDados = clienteEncontradoNoBancoDeDados;
        }

        public void ValidarCamposObrigatorios(Cliente cliente)
        {
            // Cada try catch trata a possibilidade da coleção não estar instânciada
            try {
                if (!cliente.Documentos.Any(d => (d.TipoDocumento.Equals(TipoDocumento.CPF))))
                    throw new ExcecaoCPFNaoInformado();
            }
            catch (ArgumentException) {
                throw new ExcecaoCPFNaoInformado();
            }

            try {
                if (cliente.Telefones.FirstOrDefault() == null)
                    throw new ExcecaoNenhumTelefoneInformado();
            }
            catch (ArgumentNullException) {
                throw new ExcecaoNenhumTelefoneInformado();            
            }

            try {
                if (cliente.Enderecos.FirstOrDefault() == null)
                    throw new ExcecaoNenhumEnderecoInformado();
            } catch (ArgumentNullException) {
                throw new ExcecaoNenhumEnderecoInformado();
            }
        }

        public void ValidarDuplicidadeCPFDeNovoCliente(Cliente novoCliente)
        {
            Documento cpfClienteEncontradoNoBancoDeDados;

            try {
                cpfClienteEncontradoNoBancoDeDados = this._clienteEncontradoNoBancoDeDados.Documentos.SingleOrDefault(e => (e.TipoDocumento.Equals(TipoDocumento.CPF)));
            } catch (NullReferenceException) {
                return;
            }

            Documento cpfNovoCliente = novoCliente.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CPF)));

            if (cpfClienteEncontradoNoBancoDeDados.Equals(cpfNovoCliente))
                throw new ExcecaoCPFJaCadastrado(cpfNovoCliente.ValorDocumento);
        }

        public void ValidarDuplicidadeCPFDeClienteEmAlteracao(Cliente clienteEmAlteracao)
        {
            if (this._clienteEncontradoNoBancoDeDados == null)
                return;

            Documento cpfClienteEncontradoNoBancoDeDados = this._clienteEncontradoNoBancoDeDados.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CPF)));
            Documento cpfClienteEmAlteracao = clienteEmAlteracao.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CPF)));

            if ((!this._clienteEncontradoNoBancoDeDados.Equals(clienteEmAlteracao)) && (cpfClienteEncontradoNoBancoDeDados.Equals(cpfClienteEmAlteracao)))
                throw new ExcecaoCPFJaCadastrado(cpfClienteEmAlteracao.ValorDocumento);
        }
    }
}
