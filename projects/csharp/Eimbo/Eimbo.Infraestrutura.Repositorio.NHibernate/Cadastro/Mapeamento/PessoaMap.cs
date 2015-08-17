using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class PessoaMap :ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            this.Table("pessoas");

            this.Id(e => e.Id)
                 .Column("id")                 
                 .Not.Nullable()
                 .Index("idx_pessoa_pkey")
                 .GeneratedBy
                 .SequenceIdentity("seq_pessoas");

            this.Map(e => e.Nome)
                .Column("nome")
                .Not.Nullable();

            this.Map(e => e.DtNascimento)
                .Column("data_nascimento")
                .Not.Nullable();

            this.Map(e => e.Status)
                .Column("status")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.Map(e => e.TipoPessoa)
                .Column("tipo_pessoa")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.Map(e => e.TipoCadastroPessoa)
                .Column("tipo_cadastro_pessoa")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.HasMany<Documento>(pessoa => pessoa.Documentos)                
                .Cascade.All()                
                .Table("pessoas_documentos")                
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("pessoa_id", p => p.Index("idx_pessoa_doc_fkey"))                                                
                .Component(documento => {                                          
                                          documento.Map(d => d.ValorDocumento)
                                                   .Column("valor_documento")
                                                   .CustomType(typeof(String))
                                                   .Not.Nullable()
                                                   .Length(20);
                                                                                    
                                          documento.Map(d => d.TipoDocumento)
                                                   .Column("tipo_documento")
                                                   .CustomType(typeof(int))
                                                   .Not.Nullable()
                                                   .Length(1);
                                        });

            this.HasMany<Telefone>(pessoa => pessoa.Telefones)
                .Cascade.All()
                .Table("pessoas_telefones")
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("pessoa_id", p => p.Index("idx_pessoa_fone_fkey"))
                .Component(telefone  =>
                                        {
                                         telefone.Map(t => t.ValorTelefone)
                                                  .Column("telefone")
                                                  .CustomType(typeof(String))
                                                  .Not.Nullable()
                                                  .Length(10);
                                         telefone.Map(t => t.Tipo)
                                                  .Column("tipo")
                                                  .CustomType(typeof(int))
                                                  .Not.Nullable()
                                                  .Length(1);
                                         });

            this.HasMany<Endereco>(pessoa => pessoa.Enderecos)
                .Cascade.All()
                .Table("pessoas_enderecos")
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("pessoa_id", p => p.Index("idx_pessoa_end_fkey"))
                .Component(endereco =>
                                        {
                                            endereco.Map(e => e.Logradouro)
                                                     .Column("logradouro")
                                                     .CustomType(typeof(String))
                                                     .Not.Nullable();                                            
                                                   //.Length(20);
                                            endereco.Map(e => e.Numero)
                                                    .Column("numero")
                                                    .Not.Nullable();

                                            endereco.Map(e => e.TipoEndereco)
                                                    .Column("tipo_endereco")
                                                    .CustomType(typeof(int))
                                                    .Not.Nullable()
                                                    .Length(1);

                                            endereco.Component(end => end.Cep, cep =>
                                                                                     {
                                                                                         cep.Map(x => x.Cep)
                                                                                            .Column("cep")
                                                                                            .CustomType(typeof(String))
                                                                                            .Not.Nullable()
                                                                                            .Length(8);
                                                                                     });
                                            
                                            endereco.References(e => e.Cidade)
                                                    .Column("id_cidade")
                                                    .Not.Nullable()
                                                    .Index("idx_end_cid_fkey")
                                                    .Cascade.Delete()
                                                    .ForeignKey("end_cid_fkey");                                                    
                                        });
        }
    }
}
