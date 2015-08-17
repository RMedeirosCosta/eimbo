using System;

namespace Eimbo.Dominio.Cadastro.Excecao
{
    public class ExcecaoDescricaoServicoJaCadastrada :Exception
    {
        public ExcecaoDescricaoServicoJaCadastrada() : base("Essa descrição já está cadastrada para outro serviço!") { }
    }
}
