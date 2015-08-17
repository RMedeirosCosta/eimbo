using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoPessoa
    {
        Fisica = 0,
        Juridica = 1
    }

    public static class NomeTipoPessoa
    {
        public static String Obtem(TipoPessoa tipo)
        {
            switch (tipo)
            {
                case TipoPessoa.Fisica: return "Física";
                case TipoPessoa.Juridica: return "Jurídica";
                default: return String.Empty;
            }
        }
    }
}
