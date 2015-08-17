using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.Contrato.Cadastro
{
    public interface IFachadaEmpresa
    {
        Boolean Gravar(DTOPessoa dtoEmmpresaQueVaiSerPersistida);
        DTOPessoa Obter(long id);
        DTOPessoa ObterEmpresa();
    }
}
