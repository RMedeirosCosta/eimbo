using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eimbo.Dominio.Comum.Excecao;
using Eimbo.Dominio.Comum.Entidade;

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorEstado
    {
        private Estado _estadoCadastradoComMesmaUF;
        
        public ValidadorEstado(Estado estadoCadastradoComMesmaUF)
        {
            this._estadoCadastradoComMesmaUF = estadoCadastradoComMesmaUF;
        }

        private Boolean NaoFoiEncontradoEstadoComMesmaUF { get { return (this._estadoCadastradoComMesmaUF == null); } }

        public void ValidarEstadoNovo(Estado estadoNovo)
        {
            if (this.NaoFoiEncontradoEstadoComMesmaUF) return;

            if (this._estadoCadastradoComMesmaUF.UF.Equals(estadoNovo.UF))
                throw new ExcecaoEntidadeRepetida("Estado");
        }

        public void ValidarEstadoAlterado(Estado estadoAlterado)
        {
            if (this.NaoFoiEncontradoEstadoComMesmaUF) return;

            if ((!this._estadoCadastradoComMesmaUF.Equals(estadoAlterado)) && (this._estadoCadastradoComMesmaUF.UF.Equals(estadoAlterado.UF)))
                throw new ExcecaoEntidadeRepetida("Estado");
        }
    }
}
