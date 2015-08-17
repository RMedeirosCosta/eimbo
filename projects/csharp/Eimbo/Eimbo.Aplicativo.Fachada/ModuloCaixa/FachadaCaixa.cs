using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Contrato.ModuloCaixa;
using Eimbo.Dominio.DTO.ModuloCaixa;
using Eimbo.Dominio.ModuloCaixa.Entidade;
using Eimbo.Dominio.ModuloCaixa.Repositorio;
using Eimbo.Dominio.ModuloCaixa.Excecao;
using Eimbo.Dominio.ModuloCaixa.Tipo;

namespace Eimbo.Dominio.Fachada.ModuloCaixa
{
    public class FachadaCaixa :IFachadaCaixa
    {
        private ICaixaRepositorio _repositorio;

        public FachadaCaixa(ICaixaRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Boolean AbrirNovoCaixa(Decimal SaldoAbertura)
        {
            Caixa caixaAnteriorAberto = this._repositorio.ObterUltimoCaixaAberto();

            if (caixaAnteriorAberto != null)
                throw new ExcecaoCaixaAnteriorAberto();

            Caixa novoCaixa = new Caixa(SaldoAbertura);

            try
            {
                this._repositorio.Salvar(novoCaixa);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean EfetuarSangria(Decimal valor)
        {
            try
            {
                Caixa caixa = this._repositorio.ObterUltimoCaixaAberto();
                caixa.EfetuarSangria(valor);

                this._repositorio.Salvar(caixa);
                return true;
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAberto();
            }
        }

        public Boolean EfetuarReforco(Decimal valor)
        {
            try
            {
                Caixa caixa = this._repositorio.ObterUltimoCaixaAberto();
                caixa.EfetuarReforco(valor);

                this._repositorio.Salvar(caixa);
                return true;
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAberto();
            }
        }

        public IEnumerable<DTOLancamentoCaixa> ObterExtrato()
        {
            Caixa caixa = this._repositorio.ObterUltimoCaixaAberto();

            if (caixa == null)
                throw new ExcecaoNenhumCaixaAberto();

            IList<DTOLancamentoCaixa> retorno = new List<DTOLancamentoCaixa>();

            foreach (LancamentoCaixa lancamento in caixa.Lancamentos)
            {
                DTOLancamentoCaixa dto = new DTOLancamentoCaixa();
                dto.DataHora = lancamento.DiaHorario;
                dto.Descricao = lancamento.Descricao;
                dto.TipoPagamento = lancamento.TipoPagamento;

                // Valor de saída ficam negativos 
                if (lancamento.TipoMovimentacao.Equals(TipoMovimentacaoLancamentoCaixa.Saida))
                    dto.Valor = (-1 * lancamento.Valor);
                else
                    dto.Valor = lancamento.Valor;

                retorno.Add(dto);
            }

            return retorno;
        }

        public Boolean FecharCaixaAtual()
        {
            try
            {
                Caixa caixa = this._repositorio.ObterUltimoCaixaAberto();
                caixa.Fechar();
                this._repositorio.Salvar(caixa);

                return true;
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAberto();
            }
        }

        public Boolean ReabrirUltimoCaixa()        
        {
            Caixa caixaAberto = this._repositorio.ObterUltimoCaixaAberto();

            if (caixaAberto != null)
                throw new ExcecaoCaixaAnteriorAberto();

            try
            {
                Caixa caixa = this._repositorio.ObterUltimoCaixaFechado();
                caixa.Abrir();
                this._repositorio.Salvar(caixa);
                return true;
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAnterior();
            }
        }

        public DTOCaixa ObterCaixaAtual()
        {
            Caixa caixaAtual = this._repositorio.ObterUltimoCaixaAberto();

            try
            {
                DTOCaixa dto = new DTOCaixa();
                dto.DataAbertura = caixaAtual.DataAbertura;
                dto.EstaAberto = caixaAtual.EstaAberto;
                dto.SaldoAbertura = caixaAtual.SaldoAbertura;
                dto.SaldoCartaoCredito = caixaAtual.SaldoCartaoCredito;
                dto.SaldoCartaoDebito = caixaAtual.SaldoCartaoDebito;
                dto.SaldoDinheiro = caixaAtual.SaldoDinheiro;
                dto.SaldoGeral = caixaAtual.SaldoGeral;
                dto.TotalAtendimentosDinheiro = caixaAtual.TotalAtendimentosDinheiro;
                dto.TotalReforcos = caixaAtual.TotalReforcos;
                dto.TotalSangrias = caixaAtual.TotalSangrias;
                dto.TotalTrocos = caixaAtual.TotalTrocos;

                return dto;

            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAberto();
            }
        }

        public Boolean VerificaDataAberturaIgualDiaCorrente(DTOCaixa dto)
        {
            try
            {
                return dto.DataAbertura.Date.Equals(DateTime.Now.Date);
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoParametroInvalido("dto");
            }
        }

        public DTORecebimentoCaixa CalcularRecebimento(DTORecebimentoCaixa dto)
        {
            DTORecebimentoCaixa dtoRetorno = new DTORecebimentoCaixa();

            dtoRetorno.ValorDinheiro = dto.ValorDinheiro;
            dtoRetorno.ValorCartaoCredito = dto.ValorCartaoCredito;
            dtoRetorno.ValorCartaoDebito = dto.ValorCartaoDebito;
            dtoRetorno.ValorSoma = (dto.ValorDinheiro + dto.ValorCartaoCredito + dto.ValorCartaoDebito);

            dtoRetorno.ValorRestante = (dto.ValorReceber - dtoRetorno.ValorSoma);

            if (dtoRetorno.ValorRestante < 0)
            {
                dtoRetorno.ValorTroco = Decimal.Negate(dtoRetorno.ValorRestante);
                dtoRetorno.ValorRestante = 0;
            }

            return dtoRetorno;
        }

        public DTORecebimentoCaixa ReceberRestanteComDinheiro(DTORecebimentoCaixa dto)
        {
            DTORecebimentoCaixa dtoRetorno = this.CalcularRecebimento(dto);

            dto.ValorDinheiro += dtoRetorno.ValorRestante;

            dtoRetorno = this.CalcularRecebimento(dto);

            return dtoRetorno;
        }

        public DTORecebimentoCaixa ReceberRestanteComCartaoCredito(DTORecebimentoCaixa dto)
        {
            DTORecebimentoCaixa dtoRetorno = this.CalcularRecebimento(dto);

            dto.ValorCartaoCredito += dtoRetorno.ValorRestante;

            dtoRetorno = this.CalcularRecebimento(dto);

            return dtoRetorno;
        }

        public DTORecebimentoCaixa ReceberRestanteComCartaoDebito(DTORecebimentoCaixa dto)
        {
            DTORecebimentoCaixa dtoRetorno = this.CalcularRecebimento(dto);

            dto.ValorCartaoDebito += dtoRetorno.ValorRestante;

            dtoRetorno = this.CalcularRecebimento(dto);

            return dtoRetorno;
        }

        public void Receber(DTORecebimentoCaixa dto)
        {
            if (dto.ValorRestante > 0)
                throw new ExcecaoValorPagoMenorQueValorAReceber();

            Caixa caixa = this._repositorio.ObterUltimoCaixaAberto();

            try
            {
                if (dto.ValorTroco > caixa.SaldoDinheiro)
                    throw new ExcecaoValorInsuficienteEmCaixa();

                if (dto.ValorDinheiro > 0)
                    caixa.ReceberAtendimentoEmDinheiro(dto.ValorDinheiro);

                if (dto.ValorCartaoCredito > 0)
                    caixa.ReceberAtendimentoCartaoCredito(dto.ValorCartaoCredito);

                if (dto.ValorCartaoDebito > 0)
                    caixa.ReceberAtendimentoCartaoDebito(dto.ValorCartaoDebito);

                if (dto.ValorTroco > 0)
                    caixa.EfetuarSaidaParaTroco(dto.ValorTroco);

                this._repositorio.Salvar(caixa);
            }
            catch (NullReferenceException)
            {
                throw new ExcecaoNenhumCaixaAberto();
            }
        }
    }
}
