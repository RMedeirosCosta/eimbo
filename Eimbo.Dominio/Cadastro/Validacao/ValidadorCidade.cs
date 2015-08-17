using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Dominio
using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.Excecao;

#endregion

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorCidade
    {
        private Cidade _cidadeEmAlteracao;
        private Cidade _cidadeEncontradaNoBD;
        private String _novoNome;
        private Estado _novoEstado;

        private Boolean NaoFoiEncontradaCidadeNoBancoDeDados
        {
            get { return (this._cidadeEncontradaNoBD == null); }
        }

        public ValidadorCidade(Cidade cidadeEncontradaNoBancoDeDados)
        {
            this._cidadeEncontradaNoBD = cidadeEncontradaNoBancoDeDados;
        }

        public ValidadorCidade(Cidade cidadeEmAlteracao, Cidade cidadeEncontradaNoBD, String novoNome, Estado novoEstado)
        {
            if (novoEstado == null)
                throw new ExcecaoParametroInvalido("ValidacaoCidade.uf");

            this._cidadeEncontradaNoBD = cidadeEncontradaNoBD;
            this._cidadeEmAlteracao = cidadeEmAlteracao;
            this._novoNome = novoNome;
            this._novoEstado = novoEstado;
        }

        public void ValidarNovaCidade(Cidade NovaCidade)
        {
            if (this.NaoFoiEncontradaCidadeNoBancoDeDados)
                return;

            if ((NovaCidade.Nome.Equals(this._cidadeEncontradaNoBD.Nome)) && (NovaCidade.Estado.UF.Equals(this._cidadeEncontradaNoBD.Estado.UF)))
                throw new ExcecaoEntidadeRepetida("Cidade");
        }

        public void ValidarCidadeEmAlteracao(Cidade CidadeEmAlteracao)
        {
            if (this.NaoFoiEncontradaCidadeNoBancoDeDados)
                return;

            if (
                    (!CidadeEmAlteracao.Equals(this._cidadeEncontradaNoBD)) &&
                    ((CidadeEmAlteracao.Nome.Equals(this._cidadeEncontradaNoBD.Nome)) && (CidadeEmAlteracao.Estado.UF.Equals(this._cidadeEncontradaNoBD.Estado.UF)))
               )
                throw new ExcecaoEntidadeRepetida("Cidade");
        }
    }
}
