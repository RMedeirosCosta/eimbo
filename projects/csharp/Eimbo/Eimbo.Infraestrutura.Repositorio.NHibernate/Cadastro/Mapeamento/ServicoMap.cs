using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class ServicoMap : ClassMap<Servico>
    {
        public ServicoMap()
        {
            this.Table("servicos");

            this.Id(s => s.Id)
                .Column("id")
                .Not.Nullable()
                .Index("idx_servico_pkey")
                .GeneratedBy
                .SequenceIdentity("seq_servicos");

            this.Map(c => c.Status)
                .Column("status")
                .CustomType(typeof(int))
                .Not.Nullable()
                .Length(1);

            this.Map(c => c.Descricao)
                .Column("descricao")
                .Unique()
                .Not.Nullable()
                .Length(300);

            this.Map(c => c.Valor)
                .Column("valor")
                .Not.Nullable();
        }
    }
}
