using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Aplicativo.Controlador.Comum;
using Eimbo.Aplicativo.Visao.ModuloAtendimento;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.DTO.ModuloCaixa;

using StructureMap;

namespace Eimbo.Aplicativo.Controlador.ModuloAtendimento
{
    public class ControladorRecebimentoAtendimento :ControladorPadrao<IVisaoRecebimentoAtendimento>
    {
        private IFachadaCaixa _fachada;

        public ControladorRecebimentoAtendimento(IVisaoRecebimentoAtendimento visao, Decimal ValorAReceber)
            : base(visao)
        {
            this._fachada = ObjectFactory.GetInstance<IFachadaCaixa>();

            this._visao.SetValorAReceber(ValorAReceber);
            this.AtualizarVisao(this._fachada.CalcularRecebimento(this.ObtemDTOAtual()));
        }

        public void AlterarValor()
        {
            this.AtualizarVisao(this._fachada.CalcularRecebimento(this.ObtemDTOAtual()));
        }

        public void ReceberRestateEmDinheiro()
        {
            this.AtualizarVisao(this._fachada.ReceberRestanteComDinheiro(this.ObtemDTOAtual()));
        }

        public void ReceberRestanteEmCartaoCredito()
        {
            this.AtualizarVisao(this._fachada.ReceberRestanteComCartaoCredito(this.ObtemDTOAtual()));
        }

        public void ReceberRestanteEmCartaoDebito()
        {
            this.AtualizarVisao(this._fachada.ReceberRestanteComCartaoDebito(this.ObtemDTOAtual()));
        }

        public void Receber()
        {
            DTORecebimentoCaixa dto = this._fachada.CalcularRecebimento(this.ObtemDTOAtual());
            this._fachada.Receber(dto);
            this._visao.FinalizarRecebimento();
        }

        public void CancelarRecebimento()
        {
            this._visao.CancelarRecebimento();
        }

        private DTORecebimentoCaixa ObtemDTOAtual()
        {
            DTORecebimentoCaixa dto = new DTORecebimentoCaixa();
            dto.ValorReceber = this._visao.GetValorReceber();
            dto.ValorDinheiro = this._visao.GetValorDinheiro();
            dto.ValorCartaoCredito = this._visao.GetValorCartaoCredito();
            dto.ValorCartaoDebito = this._visao.GetValorCartaoDebito();

            return dto;
        }

        private void AtualizarVisao(DTORecebimentoCaixa dto)
        {
            this._visao.SetValorDinheiro(dto.ValorDinheiro);
            this._visao.SetValorCartaoCredito(dto.ValorCartaoCredito);
            this._visao.SetValorCartaoDebito(dto.ValorCartaoDebito);
            this._visao.SetValorSoma(dto.ValorSoma);

            if (dto.ValorTroco > 0)
            {
                this._visao.HabilitarBotoesRestante(false);
                this._visao.AlterarParaTroco();
                this._visao.SetValorTroco(dto.ValorTroco);
                this._visao.HabilitarBotaoReceber(true);
            }
            else 
            {
                this._visao.HabilitarBotoesRestante((dto.ValorRestante > 0));
                this._visao.HabilitarBotaoReceber(dto.ValorRestante.Equals(0));
                this._visao.AlterarParaFaltam();
                this._visao.SetValorRestante(dto.ValorRestante);
            }
        }
    }
}
