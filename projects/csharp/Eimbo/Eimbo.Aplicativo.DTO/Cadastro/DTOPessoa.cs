using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.Comum;

namespace Eimbo.Dominio.DTO.Cadastro
{
    public class DTOPessoa :DTOBloqueavel
    {
        public String Nome { get; set; }
        public DateTime DtNascimento { get; set; }

        private IList<DTODocumento> _documentos;
        private IList<DTOTelefone> _telefones;
        private IList<DTOEndereco> _enderecos;

        public IEnumerable<DTODocumento> Documentos { get { return this._documentos; } }
        public IEnumerable<DTOTelefone> Telefones { get { return this._telefones; } }
        public IEnumerable<DTOEndereco> Enderecos { get { return this._enderecos; } }

        public DTOPessoa()
        {
            this._documentos = new List<DTODocumento>();
            this._telefones = new List<DTOTelefone>();
            this._enderecos = new List<DTOEndereco>();
        }

        public void AdicionarDocumento(DTODocumento dtoDocumento)
        {
            if (this._documentos == null)
                this._documentos = new List<DTODocumento>();

            this._documentos.Add(dtoDocumento);
        }

        public void AdicionarTelefone(DTOTelefone dtoTelefone)
        {
            if (this._telefones == null)
                this._telefones = new List<DTOTelefone>();

            this._telefones.Add(dtoTelefone);
        }

        public void AdicionarEndereco(DTOEndereco dtoEndereco)
        {
            if (this._enderecos == null)
                this._enderecos = new List<DTOEndereco>();

            this._enderecos.Add(dtoEndereco);
        }
    }
}
