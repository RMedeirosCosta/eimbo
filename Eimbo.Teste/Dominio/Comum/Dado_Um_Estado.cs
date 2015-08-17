using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Eimbo.Dominio.Comum
{
    [TestClass]
    public class Dado_Um_Estado
    {
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_UF_Nula()
        {
            Estado estado = new Estado(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_UF_Com_Mais_De_Dois_Caracteres()
        {
            Estado estado = new Estado("PRP");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_UF_Com_Menos_De_Dois_Caracteres()
        {
            Estado estado = new Estado("");
        }
    }
}
