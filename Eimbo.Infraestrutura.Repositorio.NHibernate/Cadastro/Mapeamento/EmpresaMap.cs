using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class EmpresaMap :SubclassMap<Empresa>
    {
        public EmpresaMap()
        {
            this.Table("empresas");
            this.Abstract();
        }
    }
}
