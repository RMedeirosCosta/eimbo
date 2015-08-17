using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorEmpresa
    {
        private Empresa _empresaEncontradaNoBancoDeDados;

        public ValidadorEmpresa(Empresa empresaEncontradaNoBancoDeDados)
        {
            this._empresaEncontradaNoBancoDeDados = empresaEncontradaNoBancoDeDados;
        }

        public void ValidarDuplicidadeCNPJDeNovaEmpresa(Empresa novaEmpresa)
        {
            Documento cnpjEmpresaEncontradaNoBancoDeDados;

            try {
                cnpjEmpresaEncontradaNoBancoDeDados = this._empresaEncontradaNoBancoDeDados.Documentos.SingleOrDefault(e => (e.TipoDocumento.Equals(TipoDocumento.CNPJ)));
            } catch (NullReferenceException) {
                return;
            }

            Documento cnpjNovaEmpresa                     = novaEmpresa.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CNPJ)));

            if (cnpjEmpresaEncontradaNoBancoDeDados.Equals(cnpjNovaEmpresa))
                throw new ExcecaoCNPJJaCadastrado(cnpjNovaEmpresa.ValorDocumento);
        }

        public void ValidarDuplicidadeCNPJDeEmpresaEmAlteracao(Empresa empresaEmAlteracao)
        {
            Documento cnpjEmpresaEncontradaNoBancoDeDados = this._empresaEncontradaNoBancoDeDados.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CNPJ)));
            Documento cnpjEmpresaEmAlteracao = empresaEmAlteracao.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CNPJ)));

            if ((!this._empresaEncontradaNoBancoDeDados.Equals(empresaEmAlteracao)) && (cnpjEmpresaEncontradaNoBancoDeDados.Equals(cnpjEmpresaEmAlteracao)))
                throw new ExcecaoCNPJJaCadastrado(cnpjEmpresaEmAlteracao.ValorDocumento);
        }

        public void ValidarCamposObrigatorios(Empresa empresa)
        {
            try {
                if (empresa.Documentos.Single(e => (e.TipoDocumento.Equals(TipoDocumento.CNPJ)))  == null)
                    throw new ExcecaoCNPJNaoInformado();
            } catch(Exception) {
                throw new ExcecaoCNPJNaoInformado();
            }

            try {
                if (empresa.Telefones.FirstOrDefault() == null)
                    throw new ExcecaoNenhumTelefoneInformado();
            } catch (ArgumentNullException) {
                throw new ExcecaoNenhumTelefoneInformado();
            }

            try {
                if (empresa.Enderecos.Single(e => (e.TipoEndereco.Equals(TipoEndereco.Comercial))) != null)
                    return;
            } catch (Exception) {
                throw new ExcecaoEnderecoComercialNaoInformado();
            }
        }
    }
}
