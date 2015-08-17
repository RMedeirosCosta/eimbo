using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eimbo.Dominio.DTO.Comum
{
    public class DTO
    {
        public long ID { get; set; }

        public Boolean IsNovo() { return (this.ID == 0); }
    }
}
