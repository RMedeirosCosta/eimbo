using System;

using Eimbo.Dominio.DTO.Cadastro;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.DTO.Cadastro
{
    public class DTOFormaPagamento :DTOBloqueavel
    {
        public String Descricao { get; set; }
        public Decimal PercentualAcrescimo { get; set; }
        public Decimal PercentualDesconto { get; set; }
        public ParcelamentoFormaPagamento Parcelamento { get; set; }
        public TipoFormaPagamento Tipo { get; set; }
    }
}
