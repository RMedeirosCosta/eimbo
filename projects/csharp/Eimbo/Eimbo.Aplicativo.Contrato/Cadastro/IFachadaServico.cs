using System;
using System.Collections.Generic;
using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaServico
    {
        Boolean AlterarStatus(DTOServico dtoSelecionado);
        IEnumerable<DTOServico> Buscar(String palavraChave = "");
        Boolean Gravar(DTOServico dtoServicoQueVaiSerPersistido);
        DTOServico Obter(long id);
    }
}
