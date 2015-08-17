using System;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class ParcelamentoFormaPagamentoMap :ComponentMap<ParcelamentoFormaPagamento>
    {
        public ParcelamentoFormaPagamentoMap()        
        {
            this.Map(m => m.IntervaloEntreParcelas)
                .Column("intervalo_parcelas")
                .Not.Nullable()
                .Default("0");

            this.Map(m => m.QuantidadeParcelas)
                .Column("quantidade_parcelas")
                .Not.Nullable()
                .Default("0");

            this.Map(m => m.Tipo)
                .Column("tipo_parc_fpagto")
                .CustomType(typeof(int))
                .Length(1);
        }
    }
}
