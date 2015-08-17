using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Comum.ObjetoValor
{
    public class CPF :Documento
    {
        public CPF(String cpf) :base(cpf, TipoDocumento.CPF) {}

        public static implicit operator CPF(String cpf)
        {
            return new CPF(cpf);
        }

        public override String MascaraParaFormatacao()
        {
            return "{0}.{1}.{2}-{3}";
        }

        public override String ToStringFormatado()
        {
            try
            {
                return string.Format(this.MascaraParaFormatacao(), base.ValorDocumento.Substring(0, 3), base.ValorDocumento.Substring(3, 3), base.ValorDocumento.Substring(6, 3), base.ValorDocumento.Substring(9, 2));
            }
            catch (ArgumentOutOfRangeException)
            {
                return base.ValorDocumento;
            }
        }

        public override bool ValidaDocumento()
        {
            String cpf = this.ValorDocumento;
            var cpfSomenteNumeros = cpf.Replace("_", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty).Trim();

            if (!String.IsNullOrWhiteSpace(cpfSomenteNumeros))
                if (!Regex.IsMatch(cpfSomenteNumeros, "^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}$|^[0-9]{11}$")
                    || Regex.IsMatch(cpfSomenteNumeros, "^[0]{11}$|^[1]{11}$|^[2]{11}$|^[3]{11}$|^[4]{11}$|^[5]{11}$|^[6]{11}$|^[7]{11}$|^[8]{11}$|^[9]{11}$"))
                    return false;

            // Caso coloque todos os numeros iguais
            Int32[] multiplicador1 = new Int32[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32[] multiplicador2 = new Int32[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempCpf;
            String digito;
            Int32 soma;
            Int32 resto;

            if (cpfSomenteNumeros.Length != 11)
                return false;

            tempCpf = cpfSomenteNumeros.Substring(0, 9);
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

            return cpfSomenteNumeros.EndsWith(digito);            
        }
    }
}
