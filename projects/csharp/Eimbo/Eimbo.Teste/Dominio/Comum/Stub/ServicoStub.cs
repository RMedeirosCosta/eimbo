using System;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class ServicoStub :Servico
    {
        public static Servico GetInstance(long id, String descricao, Decimal valor)
        {
            var servico = new ServicoStub();

            servico.Id = id;
            servico.Descricao = descricao;
            servico.Valor = valor;

            return (Servico)servico;
        }
    }
}
