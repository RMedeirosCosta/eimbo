using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class CidadeStub :Cidade
    {
        public static Cidade GetInstance(long id, String nome, Estado estado)
        {
            var cidade = new CidadeStub();
            cidade.Id = id;
            cidade.Nome = nome;
            cidade.Estado = estado;

            return (Cidade)cidade;
        }
    }
}
