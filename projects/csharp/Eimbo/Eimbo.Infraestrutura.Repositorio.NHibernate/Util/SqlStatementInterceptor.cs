using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using orm = NHibernate;
using System.Diagnostics;

namespace Eimbo.Infraestrutura.Repositorio.NHibernate.Util
{
    public class SqlStatementInterceptor : orm.EmptyInterceptor
    {
        public override orm.SqlCommand.SqlString OnPrepareStatement(orm.SqlCommand.SqlString sql)
        {
            return sql;//Query Sql gerada pelo nHibernate
        }
    } 
}
