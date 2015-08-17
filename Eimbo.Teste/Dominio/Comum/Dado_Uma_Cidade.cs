using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;

namespace Eimbo.Eimbo.Dominio.Comum
{
    [TestClass]
    public class Dado_Uma_Cidade
    {
        private static Estado _estadoValido = new Estado("PR");

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Nome_Nulo()
        {
            Cidade cidade = new Cidade(_estadoValido, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_UF_Nula()
        {
            Cidade cidade = new Cidade(null, "Cidade Teste");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Nome_Em_Branco()
        {
            Cidade cidade = new Cidade(_estadoValido, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Nome_Maior_Que_300_Caracteres()
        {
            String nomeComMaisDe300Caracteres = new String('*', 301);          

            Cidade cidade = new Cidade(_estadoValido, nomeComMaisDe300Caracteres);
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Valida()
        {
            Cidade cidade = new Cidade(_estadoValido, "Santo Antônio da Platina   ");

            Assert.AreEqual(cidade.Nome, "SANTO ANTÔNIO DA PLATINA");
        }
    }
}
