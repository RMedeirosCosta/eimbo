using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.Entidade;
using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class EstadoMap :ClassMap<Estado>
    {
        public EstadoMap()
        {
            this.Table("estados");

            this.Id(e => e.Id)
                 .Column("id")
                 .Not.Nullable()
                 .Index("idx_estado_pkey")
                 .GeneratedBy
                 .SequenceIdentity("seq_estados");

            this.Map(e => e.UF)
                .Column("uf")
                .Not.Nullable()
                .Length(2);

            this.Map(e => e.Status)
                .Column("status")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);
        }
    }
}
