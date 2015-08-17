using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Aplicativo.Controlador.Cadastro.Tipo
{
    public enum TipoEstadoCadastro
    {
        Consulta     = 0,
        Visualizacao = 1,
        Inclusao     = 2,
        Alteracao    = 3,
        Pesquisa     = 4,
    }
}
