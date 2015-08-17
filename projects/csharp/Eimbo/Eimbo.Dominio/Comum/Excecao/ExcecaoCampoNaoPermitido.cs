using System;

namespace Eimbo.Dominio.Comum.Excecao
{
    public class ExcecaoCampoNaoPermitido :Exception
    {
        public ExcecaoCampoNaoPermitido(String campo, String DescricaoDoObjeto)
            :base("Não é permitido " + campo + " para " + DescricaoDoObjeto) {}
    }
}
