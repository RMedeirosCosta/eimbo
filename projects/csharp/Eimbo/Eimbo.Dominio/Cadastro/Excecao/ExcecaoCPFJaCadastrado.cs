using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Cadastro.Excecao
{
    public class ExcecaoCPFJaCadastrado :Exception
    {
        public ExcecaoCPFJaCadastrado(String CPF) : base("CPF " + CPF + " já cadastrado no banco de dados!") { }
    }
}
