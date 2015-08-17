using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Eimbo.Dominio.Comum.Entidade;
using Eimbo.Dominio.Comum.ObjetoValor;
using Eimbo.Dominio.Comum.Tipo;

namespace Eimbo.Dominio.Cadastro.ObjetoValor
{
    public class EmpresaCadastrada :Especificacao<Pessoa>
    {
        public override Expression<Func<Pessoa, bool>> SatisfeitoPor()
        {
            //TipoCadastroPessoa.Empresa
            return (pessoa => (pessoa.TipoCadastroPessoa == TipoCadastroPessoa.Empresa)); //(pessoa => (pessoa.TipoCadastroPessoa.Equals(0)));
        }
    }
}
