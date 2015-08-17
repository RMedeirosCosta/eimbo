using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Entidade
{
    public abstract class Pessoa :EntidadeBloqueavel
    {
        private String _nome;

        // Também pode ser a razão social da empresa
        public virtual String Nome 
        { 
            get
            {
                return this._nome.ToUpper().Trim();
            } 

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new Excecao.ExcecaoParametroInvalido("Pessoa.Nome");

                this._nome = value;
            }
        }

        private DateTime _dtNascimento;

        // Também pode ser a data de abertura da empresa
        public virtual DateTime DtNascimento 
        { 
            get
            {
                return this._dtNascimento;
            }
            set
            {
                if ((value == null) || (value.Equals(DateTime.MinValue)))
                    throw new Excecao.ExcecaoParametroInvalido("Pessoa.DtAniversario");

                this._dtNascimento = value;
            }
        }

        // Física ou Jurídica
        public virtual TipoPessoa TipoPessoa { get; set; } 

        // Empresa, Cliente, Fornecedor e etc.
        public virtual TipoCadastroPessoa TipoCadastroPessoa { get; set; }

        private IList<Telefone> _telefones;
        public virtual IEnumerable<Telefone> Telefones { get { return this._telefones; } }

        private IList<Endereco> _enderecos;
        public virtual IEnumerable<Endereco> Enderecos { get { return this._enderecos; } }

        private IList<Documento> _documentos;
        public virtual IEnumerable<Documento> Documentos {
                                                           get 
                                                              {
                                                                  // MUDAR_AQUI_1  
                                                                  // Essa operação foi definida porque até o presente momento eu não consegui achar uma configuração do Fluent NHibernate
                                                                  // na qual eu pudesse mapear um Componente() abstrato. Não consegui achar a opção para setar o identificador de cada subclasse.
                                                                  if ((this._documentos != null) && (this._documentos.Count > 0))
                                                                  {
                                                                      IList<Documento> replaced = new List<Documento>();

                                                                      foreach (Documento d in this._documentos)
                                                                      {
                                                                          switch (d.TipoDocumento)
                                                                          {
                                                                              case TipoDocumento.RG: 
                                                                                                       //this._documentos.Remove(d);
                                                                                                       replaced.Add(new RG(d.ValorDocumento));
                                                                                                       break;

                                                                              case TipoDocumento.CPF:
                                                                                                       //this._documentos.Remove(d);
                                                                                                       replaced.Add(new CPF(d.ValorDocumento));
                                                                                                       break;

                                                                              case TipoDocumento.IE:
                                                                                                       //this._documentos.Remove(d);
                                                                                                       replaced.Add(new IE(d.ValorDocumento));
                                                                                                       break;

                                                                              case TipoDocumento.CNPJ:
                                                                                                       //this._documentos.Remove(d);
                                                                                                       replaced.Add(new CNPJ(d.ValorDocumento));
                                                                                                       break;
                                                                          }

                                                                          this._documentos = replaced;
                                                                      }
                                                                  }

                                                                 return this._documentos; 
                                                               }
                                                         }
    
        protected Pessoa() {}

        public Pessoa(String nome, DateTime dtNascimento)
        {
            base._status = TipoStatus.Normal;
            this.Nome = nome;
            this.DtNascimento = dtNascimento;
            this._telefones = null;
            this._enderecos = null;
            this._documentos = null; 
        }

        protected abstract TipoDocumento[] DocumentosPermitidos(); // { throw new NotImplementedException(); }
        protected abstract TipoEndereco[] EnderecosPermitidos();   // { throw new NotImplementedException(); }
        protected abstract TipoTelefone[] TelefonesPermitidos();   // { throw new NotImplementedException(); }
 
        public virtual void LimparColecoes()
        {
            if (this._documentos != null)
                this._documentos.Clear();

            if (this._enderecos != null)
                this._enderecos.Clear();

            if (this._telefones != null)
                this._telefones.Clear();
        }

        public virtual void AdicionaDocumento(Documento documento)
        {
            if (documento == null)
                throw new ExcecaoParametroInvalido("Pessoa.Documento");

            //if (!documento.ValidaDocumento())
            //    throw new ExcecaoValorDocumentoInvalido(documento.TipoDocumento);

            if (!this.DocumentosPermitidos().Contains(documento.TipoDocumento))
                throw new ExcecaoDocumentoNaoPermitido(this.TipoPessoa, documento.TipoDocumento);

            if (this._documentos == null)
                this._documentos = new List<Documento>();

            if (this._documentos.Contains(documento))
                throw new ExcecaoParametroRepetido("Pessoa.Documento");

            if (this._documentos.Any(doc => doc.TipoDocumento.Equals(documento.TipoDocumento)))
                throw new ExcecaoTipoDocumentoDuplicado(documento.TipoDocumento);

            this._documentos.Add(documento);
        }

        public virtual void RemoveDocumento(Documento documento)
        {
            if (this._documentos == null)
                return;

            this._documentos.Remove(documento);
        }

        public virtual void AdicionaTelefone(Telefone telefone)
        {
            if (telefone == null)
                throw new ExcecaoParametroInvalido("Pessoa.Telefone");

            if (!this.TelefonesPermitidos().Contains(telefone.Tipo))
                throw new ExcecaoTelefoneNaoPermitido(this.TipoPessoa, telefone.Tipo);

            if (this._telefones == null)
                this._telefones = new List<Telefone>();

            if (this._telefones.Contains(telefone))
                throw new ExcecaoParametroRepetido("Pessoa.Telefone");

            this._telefones.Add(telefone);            
        }

        public virtual void RemoveTelefone(Telefone telefone)
        {
            if (this._telefones == null)
                return;

            this._telefones.Remove(telefone);
        }

        public virtual void AdicionaEndereco(Endereco endereco)
        {
            if (endereco == null)
                throw new ExcecaoParametroInvalido("Pessoa.Endereco");

            if (!this.EnderecosPermitidos().Contains(endereco.TipoEndereco))
                throw new ExcecaoEnderecoNaoPermitido(this.TipoPessoa, endereco.TipoEndereco);

            if (this._enderecos == null)
                this._enderecos = new List<Endereco>();

            if (this.Enderecos.Contains(endereco))
                throw new ExcecaoParametroRepetido("Pessoa.Endereco");

            this._enderecos.Add(endereco);
        }

        public virtual void RemoveEndereco(Endereco endereco)
        {
            if (this._enderecos == null)
                return;

            this._enderecos.Remove(endereco);
        }
    }    
}
