using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.ModuloCaixa.Entidade;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.ModuloCaixa.Mapeamento
{
    public class CaixaMap : ClassMap<Caixa>
    {
        public CaixaMap()
        {
            this.Table("caixas");

            this.Id(e => e.Id)
                .Column("id")
                .Not.Nullable()
                .Index("idx_caixa_pkey")
                .GeneratedBy
                .SequenceIdentity("seq_caixas");

            this.Map(e => e.DataAbertura)
                .Column("data_abertura")
                //.Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            this.Map(e => e.DataFechamento)
                .Column("data_fechamento")
                //.Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            this.Map(e => e.Situacao)
                .Column("situacao")
                //.Access.CamelCaseField(Prefix.Underscore)
                .CustomType(typeof(int))
                .Not.Nullable();

            this.HasMany<LancamentoCaixa>(c => c.Lancamentos)
                .Cascade.All()
                .Table("caixa_lancamentos")
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("caixa_id", p => p.Index("idx_caixa_lanc_fkey"))
                .Component(lancamento =>
                {
                    lancamento.Map(l => l.DiaHorario)
                              .Column("dia_horario")
                              //.Access.CamelCaseField(Prefix.Underscore)
                              .Not.Nullable();

                    lancamento.Map(l => l.Descricao)
                              .Column("descricao")
                              //.Access.CamelCaseField(Prefix.Underscore)
                              .CustomType(typeof(String))
                              .Not.Nullable();

                    lancamento.Map(l => l.TipoMovimentacao)
                              .Column("tipo_movimentacao")
                              //.Access.CamelCaseField(Prefix.Underscore)
                              .CustomType(typeof(int))
                              .Not.Nullable()
                              .Length(1);

                    lancamento.Map(l => l.TipoPagamento)
                              .Column("tipo_pagamento")
                              //.Access.CamelCaseField(Prefix.Underscore)
                              .CustomType(typeof(int))
                              .Not.Nullable()
                              .Length(1);

                    lancamento.Map(l => l.Valor)
                              .Column("valor")
                              //.Access.CamelCaseField(Prefix.Underscore)
                              .CustomType(typeof(Decimal))
                              .Not.Nullable();
                });                                
        }
    }
}
