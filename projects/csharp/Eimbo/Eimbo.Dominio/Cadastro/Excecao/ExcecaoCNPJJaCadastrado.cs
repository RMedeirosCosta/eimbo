using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Cadastro.Excecao
{
    public class ExcecaoCNPJJaCadastrado :Exception
    {
        public ExcecaoCNPJJaCadastrado(String CNPJ) : base("CNPJ "+CNPJ+" já cadastrado no banco de dados!") { }
    }
}
