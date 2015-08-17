using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoStatus
    {
        Normal    = 0,
        Bloqueado = 1
    }

    public static class NomeTipoStatus
    {
        public static String Obtem(TipoStatus tipo)
        {
            switch (tipo)
            {
                case TipoStatus.Normal: return "Normal";
                case TipoStatus.Bloqueado: return "Bloqueado";
                default: return String.Empty;
            }
        }
    }
}
