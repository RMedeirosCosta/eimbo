using System;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoParcelamentoFormaPagamento
    {
        Nenhum     = -1,
        ComEntrada = 0,
        SemEntrada = 1
    }

    public static class NomeTipoParcelamentoFormaPagamento
    {
        public static String Obtem(TipoParcelamentoFormaPagamento TipoParcelamentoFormaPagamento)
        {
            switch (TipoParcelamentoFormaPagamento)
            {
                case TipoParcelamentoFormaPagamento.ComEntrada: return "Com entrada";
                case TipoParcelamentoFormaPagamento.SemEntrada: return "Sem entrada";
                default: throw new ExcecaoParametroInvalido("TipoParcelamentoFormaPagamento");
            }
        }
    }
}
