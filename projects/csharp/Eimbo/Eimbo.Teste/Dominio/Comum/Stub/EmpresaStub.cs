using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class EmpresaStub : Empresa
    {
       public static Empresa GetInstance(long id, String nome, DateTime data)
       {
           var empresa = new EmpresaStub();
           empresa.Id = id;
           empresa.Nome = nome;
           empresa.DtNascimento = data;                    

           return (Empresa)empresa;
       }   
    }
}
