using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaCidade
    {
        Boolean AlterarStatus(DTOCidade dtoSelecionado);
        IEnumerable<DTOCidade> Buscar(String palavraChave = "");
        Boolean Gravar(DTOCidade dtoCidadeQueVaiSerPersistido);
        DTOCidade Obter(long id);
        DTOEstado ObterEstado(long id);
    }
}
