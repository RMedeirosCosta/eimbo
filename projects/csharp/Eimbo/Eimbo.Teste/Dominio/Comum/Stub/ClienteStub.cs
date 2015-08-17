using System;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class ClienteStub :Cliente
    {
        public static Cliente GetInstance(long id, String nome, DateTime data)
        {
            var cliente = new ClienteStub();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.DtNascimento = data;

            return (Cliente)cliente;
        }   
    }
}
