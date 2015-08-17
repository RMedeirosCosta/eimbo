using System;
using System.Collections.Generic;
using System.Text;

using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaEstado
    {
        Boolean AlterarStatus(DTOEstado dtoSelecionado);
        IEnumerable<DTOEstado> Buscar(String palavraChave = "");
        Boolean Gravar(DTOEstado dtoEstadoQueVaiSerPersistido);
        DTOEstado Obter(long id);
    }
}
