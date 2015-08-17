using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloAtendimento.Entidade;
using Eimbo.Dominio.ModuloAtendimento.ObjetoValor;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Mapeamento.ModuloAtendimento
{
    public class AtendimentoMap: ClassMap<Atendimento>
    {
        public AtendimentoMap()
        {
            this.Table("atendimentos");

            this.Id(a => a.Id)
                .Column("id")
                .Not.Nullable()
                .Index("idx_atendimento_pkey")
                .GeneratedBy
                .SequenceIdentity("seq_atendimentos");

           this.Map(a => a.Data)
                .Column("data")
                .Not.Nullable();

           this.References(a => a.Empresa)
               .Column("empresa_id")
               .Not.Nullable()
               .Index("idx_empresa_fkey")
               .Cascade.None()
               .ForeignKey("atendimento_empresa_fkey");

           this.References(a => a.Cliente)
               .Column("cliente_id")
               .Not.Nullable()
               .Index("idx_cliente_fkey")
               .Cascade.None()
               .ForeignKey("atendimento_cliente_fkey");

           this.References(a => a.FormaPagamento)
               .Column("fpagto_id")
               .Not.Nullable()
               .Index("idx_fpagto_fkey")
               .Cascade.None()
               .ForeignKey("atendimento_fpagto_fkey");

            this.Map(a => a.Situacao)
                .Column("situacao")
                .CustomType(typeof(int))
                .Not.Nullable();

            this.Map(a => a.Acrescimo)
                .Column("acrescimo")
                .Not.Nullable();

            this.Map(a => a.AcrescimoFormaPagamento)
                .Column("acrescimo_fpagto")
                .Not.Nullable();

            this.Map(a => a.Desconto)
                .Column("desconto")
                .Not.Nullable();

            this.Map(a => a.DescontoFormaPagamento)
                .Column("desconto_fpagto")
                .Not.Nullable();

           this.HasMany<ItemAtendimento>(a => a.Itens)                
                .Cascade.All()                
                .Table("atendimentos_itens")                
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("atendimento_id", p => p.Index("idx_atendimento_itens_fkey"))                                                
                .Component(a => {              
                                  a.References(i => i.Servico)
                                   .Column("servico_id")
                                   .Not.Nullable()
                                   .Index("idx_servico_fkey")
                                   .Cascade.None()
                                   .ForeignKey("atendimentoitem_servico_fkey");

                                  a.Map(i => i.ValorUnitario)
                                   .Column("valor_unitario")
                                   .Not.Nullable();
                                                                                    
                                  a.Map(i => i.Quantidade)
                                   .Column("quantidade")
                                   .Not.Nullable();
                                });
        }

    }
}
