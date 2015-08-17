using System;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoFormaPagamento
    {
        Nenhum = -1,
        Vista = 0,
        Prazo = 1
    }

    public static class NomeTipoFormaPagamento
    {
        public static String Obtem(TipoFormaPagamento TipoFormaPagamento)
        {
            switch(TipoFormaPagamento)
            {
                case TipoFormaPagamento.Vista: return "À vista"; 
                case TipoFormaPagamento.Prazo: return "A prazo"; 
                default: throw new ExcecaoParametroInvalido("TipoFormaPagamento");
            }
        }
    }
}
