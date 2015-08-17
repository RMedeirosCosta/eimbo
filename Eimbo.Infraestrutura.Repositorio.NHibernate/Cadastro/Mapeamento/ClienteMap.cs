using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;

using FluentNHibernate.Mapping;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Cadastro.Mapeamento
{
    public class ClienteMap :SubclassMap<Cliente>
    {
        public ClienteMap()
        {
            this.Table("clientes");
            this.Abstract();
        }
    }
}
