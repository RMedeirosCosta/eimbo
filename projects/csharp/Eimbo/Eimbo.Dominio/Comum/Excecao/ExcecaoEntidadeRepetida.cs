using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoEntidadeRepetida :Exception
    {
        public ExcecaoEntidadeRepetida(String Entidade) : base(String.Concat(Entidade, " já cadastrada no banco de dados")) { }
    }
}
