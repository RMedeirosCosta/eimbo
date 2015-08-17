using System;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Teste.Dominio.Comum.Stub
{
    public class FormaPagamentoStub :FormaPagamento
    {
        public static FormaPagamento GetInstance(long id, 
                                                 String descricao,
                                                 TipoFormaPagamento tipoFormaPagamento,
                                                 Decimal percentualAcrescimo,
                                                 Decimal percentualDesconto)
        {
            var formaPagamento = new FormaPagamentoStub();

            formaPagamento.Id = id;
            formaPagamento.Descricao = descricao;
            formaPagamento.Tipo = tipoFormaPagamento;
            formaPagamento.PercentualAcrescimo = percentualAcrescimo;
            formaPagamento.PercentualDesconto = percentualDesconto;

            return (FormaPagamento)formaPagamento;

        }
    }
}
