using System;

using Eimbo.Dominio.Cadastro.Excecao;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorFormaPagamento
    {
        private FormaPagamento _encontradaNoBD;

        public ValidadorFormaPagamento(FormaPagamento encontradaNoBD)
        {
            this._encontradaNoBD = encontradaNoBD;
        }

        public void ValidarNovaFormaPagamento(FormaPagamento nova)
        {
            try
            {
                if (this._encontradaNoBD.Descricao.Equals(nova.Descricao))
                    throw new ExcecaoDescricaoFormaPagamentoJaCadastrada();
            }
            catch (NullReferenceException) { }
        }

        public void ValidarFormaPagamentoEmAlteracao(FormaPagamento emAlteracao)
        {
            try
            {
                if ((!this._encontradaNoBD.Equals(emAlteracao)) && (this._encontradaNoBD.Descricao.Equals(emAlteracao.Descricao)))
                    throw new ExcecaoDescricaoFormaPagamentoJaCadastrada();
            }
            catch (NullReferenceException) { }
        }
    }
}
