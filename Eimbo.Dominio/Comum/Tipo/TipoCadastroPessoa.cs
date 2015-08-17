using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Dominio.Comum.Tipo
{
    public enum TipoCadastroPessoa
    {
        Empresa = 0,
        Cliente = 1,
        Fornecedor = 2,
        Profissional = 3
    }

    public static class NomeTipoCadastroPessoa
    {
        public static String Obtem(TipoCadastroPessoa TipoCadastroPessoa)
        {
            switch (TipoCadastroPessoa)
            {
                case TipoCadastroPessoa.Empresa: return "Empresa";
                case TipoCadastroPessoa.Cliente: return "Cliente";
                case TipoCadastroPessoa.Fornecedor: return "Fornecedor";
                case TipoCadastroPessoa.Profissional: return "Profissional";
                default: throw new ExcecaoParametroInvalido("Tipo");
            }
        }
    }
}
