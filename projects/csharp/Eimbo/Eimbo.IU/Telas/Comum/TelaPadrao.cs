using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eimbo.Aplicativo.Visao.Comum;

namespace Eimbo.IU.Telas.Comum
{
    public partial class TelaPadrao : Form, IVisaoPadrao
    {
        public TelaPadrao()
        {
            InitializeComponent();
        }

        public Boolean PedirConfirmacao(String pergunta)
        {
            return (MessageBox.Show(this, pergunta, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        public void Avisar(String aviso)
        {
            MessageBox.Show(this, aviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExibirErro(String Erro, String NomeDoControle)
        {
            Control ctrl = this.Controls.Find(NomeDoControle, true)[0];
            ToolTip tt = new ToolTip();
            tt.ToolTipIcon = ToolTipIcon.Error;
            tt.ToolTipTitle = "Erro!";
            
            try
            {
                tt.Show(Erro, ctrl);                
            }
            catch (NullReferenceException)
            {
                // Se não achar o controle chama a exceção convencional
                this.ExibirErro(Erro);
            }
        }

        public void ExibirErro(String Erro)
        {
            MessageBox.Show(this, Erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);        
        }

        private void TelaPadrao_KeyDown(object sender, KeyEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Return: SendKeys.Send("{TAB}"); break; //Mudo o foco quando o usuário aperta ENTER
                case Keys.Escape: this.Close();           break; //Fecho a janela quando o usuário aperta ESC               
            }
        }
    }
}
