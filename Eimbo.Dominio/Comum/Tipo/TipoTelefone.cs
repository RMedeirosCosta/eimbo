using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoTelefone
    {
        Residencial = 0,
        Comercial   = 1,
        Celular     = 2,
        Fax         = 3
    }

    public static class NomeTipoTelefone
    {
        public static String ObtemString(TipoTelefone tipo)
        {
            switch (tipo)
            {
                case TipoTelefone.Residencial: return "Residencial";
                case TipoTelefone.Comercial: return "Comercial";
                case TipoTelefone.Celular: return "Celular";
                case TipoTelefone.Fax: return "Fax";
                default: throw new ExcecaoParametroInvalido("tipo");
            }
        }

        public static TipoTelefone ObtemTipo(String tipo)
        {
            switch (tipo)
            {
                case "Residencial": return TipoTelefone.Residencial;
                case "Comercial": return TipoTelefone.Comercial;
                case "Celular": return TipoTelefone.Celular;
                case "Fax": return TipoTelefone.Fax;
                default: throw new ExcecaoParametroInvalido("tipo");
            }
        }
    }
}
