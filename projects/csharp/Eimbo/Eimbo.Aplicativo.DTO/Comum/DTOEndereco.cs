using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;
using Eimbo.Dominio.DTO.Cadastro;

namespace Eimbo.Dominio.DTO.Comum
{
    public class DTOEndereco
    {
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public CEP Cep { get; set; }
        public DTOCidade Cidade { get; set; }
        public TipoEndereco TipoEndereco { get; set; }

        public DTOEndereco()
        {
            this.Cidade = new DTOCidade();
        }


        public delegate Cidade ObtemCidadePorDTO(DTOCidade Cidade);

        public Endereco ConverteDTOParaEndereco(ObtemCidadePorDTO BuscadorCidade)
        {
            return new Endereco(this.Logradouro,
                                this.Numero,
                                this.Cep,
                                BuscadorCidade(this.Cidade),
                                this.TipoEndereco);
        }
    }
}
