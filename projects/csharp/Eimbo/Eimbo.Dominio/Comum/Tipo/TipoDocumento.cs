using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoDocumento
    {
        RG = 0,
        CPF = 1,
        IE = 2,
        CNPJ = 3
    }

    public static class NomeTipoDocumento
    {
        public static String ObtemString(TipoDocumento tipo)
        {
            switch (tipo)
            {
                case TipoDocumento.RG: return "RG";
                case TipoDocumento.CPF: return "CPF";
                case TipoDocumento.IE: return "IE";
                case TipoDocumento.CNPJ: return "CNPJ";
                default: throw new ExcecaoParametroInvalido("tipo");
            }
        }

        public static TipoDocumento ObtemTipo(String tipo)
        {
            switch (tipo)
            {
                case "RG":   return TipoDocumento.RG;
                case "CPF":  return TipoDocumento.CPF;
                case "CNPJ": return TipoDocumento.CNPJ;
                case "IE":   return TipoDocumento.IE;
                default: throw new ExcecaoParametroInvalido("Tipo");
            }
        }
    }
}
