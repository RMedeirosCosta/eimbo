using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class CidadeMap :ClassMap<Cidade>
    {
        public CidadeMap()
        {
            this.Table("cidades");

            this.Id(c => c.Id)
                 .Column("id")
                 .Not.Nullable()
                 .Index("idx_cidade_pkey")
                 .GeneratedBy
                 .SequenceIdentity("seq_cidades");

            this.Map(c => c.Nome)
                .Column("nome")
                .Not.Nullable()
                .Length(300);

            this.Map(c => c.Status)
                .Column("status")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.References(c => c.Estado)
                           .Column("estado_id")
                           .Not.Nullable()
                           .Index("idx_estado_fkey")
                           .Cascade.Delete()
                           .ForeignKey("cidade_estado_fkey");

        }
    }
}
