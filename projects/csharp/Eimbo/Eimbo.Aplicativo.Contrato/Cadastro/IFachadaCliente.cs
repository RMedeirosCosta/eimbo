using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaCliente
    {
        Boolean AlterarStatus(DTOPessoa dtoSelecionado);
        IEnumerable<DTOPessoa> Buscar(String palavraChave = "");
        Boolean Gravar(DTOPessoa dtoClienteQueVaiSerPersistido);
        DTOPessoa Obter(long id);
    }
}
