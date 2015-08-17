using System;
using System.Collections.Generic;

using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaFormaPagamento
    {
        Boolean AlterarStatus(DTOFormaPagamento dtoSelecionado);
        IEnumerable<DTOFormaPagamento> Buscar(String palavraChave = "");
        Boolean Gravar(DTOFormaPagamento dtoFormaPagamento);
        DTOFormaPagamento Obter(long id);        
    }
}
