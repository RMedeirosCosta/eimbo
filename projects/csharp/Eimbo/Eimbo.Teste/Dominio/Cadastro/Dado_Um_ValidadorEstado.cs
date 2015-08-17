using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Teste.Dominio.Comum.Stub;

namespace Eimbo.Teste.Dominio.Cadastro
{
    [TestClass]
    public class Dado_Um_ValidadorEstado
    {
        private Estado _estadoCadastradoComMesmaUF;
        private Estado _estadoNaoEncontrado;

        public Dado_Um_ValidadorEstado()
        {
            this._estadoCadastradoComMesmaUF = EstadoStub.GetInstance(1, "PR");
            this._estadoNaoEncontrado = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEntidadeRepetida))]
        public void Nao_Posso_Validar_Um_Estado_Novo_Com_UF_De_Outro_Estado_Ja_Cadastrado()
        {
            Estado estadoNovo = new Estado("PR");

            ValidadorEstado validacao = new ValidadorEstado(this._estadoCadastradoComMesmaUF);
            validacao.ValidarEstadoNovo(estadoNovo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEntidadeRepetida))]
        public void Nao_Posso_Validar_Um_Estado_Alterado_Se_A_UF_Ja_Estiver_Em_Outro_Estado_Cadastrado()
        {
            Estado estadoAlterado = EstadoStub.GetInstance(2, "PR");

            ValidadorEstado validacao = new ValidadorEstado(this._estadoCadastradoComMesmaUF);
            validacao.ValidarEstadoAlterado(estadoAlterado);
        }

        [TestMethod]
        public void Devo_Validar_Um_Novo_Estado_Se_Nao_Houver_Nenhum_Estado_Cadastrado_Com_Essa_UF()
        {
            Estado estadoNovo = new Estado("PR");
            ValidadorEstado validacao = new ValidadorEstado(this._estadoNaoEncontrado);
            validacao.ValidarEstadoNovo(estadoNovo);
        }
    }
}
