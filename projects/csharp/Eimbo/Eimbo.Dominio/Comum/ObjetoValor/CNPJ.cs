using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class CNPJ :Documento
    {
        public CNPJ(String cnpj) :base(cnpj, TipoDocumento.CNPJ) {}

        public static implicit operator CNPJ(String cnpj)
        {
            return new CNPJ(cnpj);
        }

        public override String MascaraParaFormatacao()
        {   //01 234 567 8901 23            
            //01.934.032/0001.27
            return "{0}.{1}.{2}/{3}-{4}";
        }

        public override String ToStringFormatado()
        {
            try
            {
                return string.Format(this.MascaraParaFormatacao(), base.ValorDocumento.Substring(0, 2), base.ValorDocumento.Substring(2, 3), base.ValorDocumento.Substring(5, 3), base.ValorDocumento.Substring(8, 4), base.ValorDocumento.Substring(12, 2));
            }
            catch (ArgumentOutOfRangeException)
            {
                return base.ValorDocumento;
            }
        }

        public override bool ValidaDocumento()
        {
            String cpnj = this.ValorDocumento;
            var cnpjSomenteNumeros = cpnj.Replace("_", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty).Trim();

            if (!String.IsNullOrWhiteSpace(cnpjSomenteNumeros))
                if (!Regex.IsMatch(cnpjSomenteNumeros, "^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}$|^[0-9]{11}$")
                    || Regex.IsMatch(cnpjSomenteNumeros, "^[0]{11}$|^[1]{11}$|^[2]{11}$|^[3]{11}$|^[4]{11}$|^[5]{11}$|^[6]{11}$|^[7]{11}$|^[8]{11}$|^[9]{11}$"))
                    return false;

            // Caso coloque todos os numeros iguais
            Int32[] multiplicador1 = new Int32[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32[] multiplicador2 = new Int32[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempCpf;
            String digito;
            Int32 soma;
            Int32 resto;

            if (cnpjSomenteNumeros.Length != 11)
                return false;

            tempCpf = cnpjSomenteNumeros.Substring(0, 9);
            soma = 0;
            for (Int32 i = 0; i < 9; i++)
                soma += Int32.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (Int32 i = 0; i < 10; i++)
                soma += Int32.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpjSomenteNumeros.EndsWith(digito);            
        }
    }    
}
