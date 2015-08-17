using System;

using Eimbo.Dominio.Cadastro.Validacao;
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Teste.Dominio.Comum.Stub;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eimbo.Teste.Dominio.Cadastro
{
    [TestClass]
    public class Dado_Um_ValidadorCidade
    {
        private Estado _parana;
        private Cidade _cidadeEncontradaNoBancoDeDados;
        private Cidade _cidadeNaoEncontrada;

        public Dado_Um_ValidadorCidade()
        {
            this._parana = EstadoStub.GetInstance(1, "PR");
            this._cidadeEncontradaNoBancoDeDados = CidadeStub.GetInstance(2, "SANTO ANTÔNIO DA PLATINA", this._parana);
            this._cidadeNaoEncontrada = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEntidadeRepetida))]
        public void Nao_Posso_Validar_Uma_Cidade_Nova_Com_Mesmo_Nome_E_Mesmo_Estado_De_Outra_Cidade_Ja_Existente()
        {
            Cidade novaCidade = new Cidade(this._parana, "SANTO ANTÔNIO DA PLATINA");
            ValidadorCidade validador = new ValidadorCidade(this._cidadeEncontradaNoBancoDeDados);
            validador.ValidarNovaCidade(novaCidade);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoEntidadeRepetida))]
        public void Nao_Posso_Validar_Uma_Cidade_Em_Alteracao_Com_Mesmo_Nome_E_Mesma_UF_De_Outra_Cidade_Ja_Existente()
        {
            Cidade cidadeEmAlteracao = CidadeStub.GetInstance(1, "SANTO ANTÔNIO DA PLATINA", this._parana);
            ValidadorCidade validador = new ValidadorCidade(this._cidadeEncontradaNoBancoDeDados);
            validador.ValidarCidadeEmAlteracao(cidadeEmAlteracao);
        }

        [TestMethod]
        public void Posso_Validar_Uma_Cidade_Nova_Se_Nao_Houver_Outra_Cidade_Com_Mesmo_Nome_E_Mesmo_UF_Ja_Existente()
        {
            Cidade novaCidade = new Cidade(EstadoStub.GetInstance(1, "PR"), "SANTO ANTÔNIO DA PLATINA");
            ValidadorCidade validador = new ValidadorCidade(this._cidadeNaoEncontrada);
            validador.ValidarNovaCidade(novaCidade);
        }
    }
}
