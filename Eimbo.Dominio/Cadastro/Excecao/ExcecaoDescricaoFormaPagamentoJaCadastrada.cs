using System;

namespace Eimbo.Dominio.Cadastro.Excecao
{
    public class ExcecaoDescricaoFormaPagamentoJaCadastrada :Exception
    {
        public ExcecaoDescricaoFormaPagamentoJaCadastrada() : base("Essa descrição já está cadastrada para outra forma de pagamento!") { }
    }
}
