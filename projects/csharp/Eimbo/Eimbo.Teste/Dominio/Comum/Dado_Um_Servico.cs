using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Eimbo.Dominio.Comum
{
    [TestClass]
    public class Dado_Um_Servico
    {
        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Descricao_Nula()
        {
            Servico servico;

            try {
                // Caso for nula
                servico = new Servico(null, 1437.00m);
            } catch (ExcecaoParametroInvalido ex) {
                // Caso estiver vazia
                if (ex.Message.Contains("Descricao"))
                    servico = new Servico("", 1m);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoParametroInvalido))]
        public void Nao_Devo_Conseguir_Criar_Com_Valor_Invalido()
        {
            Servico servico;

            try {
                // Caso estiver zerado
                servico = new Servico("ESCOVA", 0);
            } catch (ExcecaoParametroInvalido ex) {
                // Caso for menor que zero
                if (ex.Message.Contains("Valor")) 
                    servico = new Servico("ESCOVA", -1m);
            }
        }

        [TestMethod]
        public void Devo_Conseguir_Criar_Um_Servico_Valido()
        {
            Servico servico = new Servico("Escova", 1m);

            Assert.AreEqual(servico.Descricao, "ESCOVA");
            Assert.AreEqual(servico.Valor, 1m);
        }
    }
}
