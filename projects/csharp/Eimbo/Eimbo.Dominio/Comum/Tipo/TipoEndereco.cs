using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoEndereco
    {
        Residencial = 0,
        Comercial   = 1,
        Cobranca    = 2
    }

    public static class NomeTipoEndereco
    {
        public static String ObtemString(TipoEndereco tipo)
        {
            switch (tipo)
            {
                case TipoEndereco.Residencial: return "Residencial";
                case TipoEndereco.Comercial:   return "Comercial";
                case TipoEndereco.Cobranca:    return "Cobranca";
                default:  throw new ExcecaoParametroInvalido("Tipo");
            }
        }

        public static TipoEndereco ObtemTipo(String tipo)
        {
            switch (tipo)
            {
                case "Residencial": return TipoEndereco.Residencial;
                case "Comercial": return TipoEndereco.Comercial;
                case "Cobranca": return TipoEndereco.Cobranca;
                default:  throw new ExcecaoParametroInvalido("Tipo");
            }
        }
    }
}
