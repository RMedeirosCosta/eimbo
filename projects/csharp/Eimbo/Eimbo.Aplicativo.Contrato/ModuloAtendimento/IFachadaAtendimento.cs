using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.ModuloAtendimento;

namespace Eimbo.Dominio.Contrato.ModuloAtendimento
{
    public interface IFachadaAtendimento
    {
        void AdicionarAcrescimo(Decimal acrescimo);
        void AdicionarDesconto(Decimal desconto);
        void AdicionarItem(DTOItem dto);
        Boolean AtendimentoFoiRecebido();
        void CancelarDigitacaoAtual();
        void CriaNovoAtendimento(DTOCabecalhoAtendimento dto);
        void Gravar();
        DTOValoresAtendimento ObterValoresAtendimento();
        void ReceberAtendimento();
        void RemoverItem(DTOItem dto);
    }
}
