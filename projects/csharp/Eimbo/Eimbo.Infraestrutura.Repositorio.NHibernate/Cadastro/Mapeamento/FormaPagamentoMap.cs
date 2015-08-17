using System;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class FormaPagamentoMap : ClassMap<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            this.Table("fpagtos");

            this.Id(e => e.Id)
                .Column("id")
                .Not.Nullable()
                .Index("idx_fpagto_pkey")
                .GeneratedBy
                .SequenceIdentity("seq_fpagtos");

            this.Map(e => e.Descricao)
                .Column("descricao")
                .Not.Nullable();

            this.Map(e => e.PercentualAcrescimo)
                .Column("percentual_acrescimo")
                .Not.Nullable();

            this.Map(e => e.PercentualDesconto)
                .Column("percentual_desconto")
                .Not.Nullable();

            this.Map(e => e.Status)
                .Column("status")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.Map(e => e.Tipo)
                .Column("tipo_fpagto")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.HasMany<ParcelamentoFormaPagamento>(fpagto => fpagto.Parcelamentos)
                .Cascade.All()
                .Table("fpagtos_parcelamento")
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumns.Add("fpagto_id", p => p.Index("idx_fpagto_parc_fkey"))
                .Component(parcelamento =>
                {
                    parcelamento.Map(m => m.IntervaloEntreParcelas)
                                .Column("intervalo_parcelas")
                                .Not.Nullable()
                                .Default("0");

                    parcelamento.Map(m => m.QuantidadeParcelas)
                                .Column("quantidade_parcelas")
                                .Not.Nullable()
                                .Default("0");

                    parcelamento.Map(m => m.Tipo)
                                .Column("tipo_parc_fpagto")
                                .CustomType(typeof(int))
                                .Length(1);

                });
        }
    }
}
