using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.DTO.ModuloCaixa;

namespace Eimbo.Dominio.Contrato.ModuloCaixa
{
    public interface IFachadaCaixa
    {
        Boolean AbrirNovoCaixa(Decimal SaldoAbertura);
        DTORecebimentoCaixa CalcularRecebimento(DTORecebimentoCaixa dto);
        Boolean EfetuarSangria(Decimal Valor);
        Boolean EfetuarReforco(Decimal Valor);
        IEnumerable<DTOLancamentoCaixa> ObterExtrato();
        Boolean FecharCaixaAtual();
        Boolean ReabrirUltimoCaixa();
        void Receber(DTORecebimentoCaixa dto);
        DTOCaixa ObterCaixaAtual();
        DTORecebimentoCaixa ReceberRestanteComCartaoCredito(DTORecebimentoCaixa dto);
        DTORecebimentoCaixa ReceberRestanteComCartaoDebito(DTORecebimentoCaixa dto);
        DTORecebimentoCaixa ReceberRestanteComDinheiro(DTORecebimentoCaixa dto);
        Boolean VerificaDataAberturaIgualDiaCorrente(DTOCaixa dto);        
    }
}
