using Eimbo.Dominio.Cadastro.Excecao;
using System;

namespace Eimbo.Dominio.Cadastro.Validacao
{
    public class ValidadorServico
    {
        private Eimbo.Dominio.Comum.Entidade.Servico _servicoCadastrado;

        public ValidadorServico(Eimbo.Dominio.Comum.Entidade.Servico servicoCadastrado)
        {
            this._servicoCadastrado = servicoCadastrado;
        }

        public void ValidarNovoServico(Eimbo.Dominio.Comum.Entidade.Servico novoServico)
        {
            try
            {
                if (novoServico.Descricao.Equals(this._servicoCadastrado.Descricao))
                    throw new ExcecaoDescricaoServicoJaCadastrada();
            }
            catch (NullReferenceException)
            {
                // Caso não houver nenhum serviço cadastrado com essa descrição.
            }
        }

        public void ValidarServicoEmAlteracao(Eimbo.Dominio.Comum.Entidade.Servico servicoEmAlteracao)
        {
            // Se o serviço a ser validado for ele mesmo vaza daqui.
            if (servicoEmAlteracao.Equals(this._servicoCadastrado))
                return;

            // Se não há nenhum serviço com a mesma descrição que ele, vaza daqui também
            if (this._servicoCadastrado == null)
                return;

            if (servicoEmAlteracao.Descricao.Equals(this._servicoCadastrado.Descricao))
                throw new ExcecaoDescricaoServicoJaCadastrada();
        }
    }
}
