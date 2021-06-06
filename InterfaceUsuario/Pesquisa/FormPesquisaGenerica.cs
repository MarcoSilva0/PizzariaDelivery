using Entidades.Entidades;
using Entidades.Enumeradores;
using InterfaceUsuario.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InterfaceUsuario.Pesquisa
{
    public partial class FormPesquisaGenerica : Form
    {

        public List<EntidadeViewPesquisa> lista = new List<EntidadeViewPesquisa>();
        public int iRetorno = 0;

        public FormPesquisaGenerica(string strTitulo, Status status)
        {
            InitializeComponent();
            this.Text = strTitulo;
            if (status == Status.Ativo)
                optAtivos.Checked = true;
            else if (status == Status.Inativo)
                optInativos.Checked = true;
            else
                optTodos.Checked = true;
        }

        private void FormPesquisaGenerica_Load(object sender, EventArgs e)
        {
            var form = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                Top = 0,
                Left = 0
            };
            limparCampos();
            PreencherLista(lista);
        }

        public void limparCampos()
        {
            txtBusca.Text = String.Empty;
            iRetorno = 0;
        }

        private void PreencherLista(List<EntidadeViewPesquisa> list)
        {
            lvlListagem.Clear();
            lvlListagem.View = View.Details;

            lvlListagem.Columns.Add("Código", 80, HorizontalAlignment.Right);
            lvlListagem.Columns.Add("Descrição", 280, HorizontalAlignment.Left);

            foreach(var item in list)
            {
                if (!optTodos.Checked) {
                    if (optAtivos.Checked && item.Status != Entidades.Enumeradores.Status.Ativo)
                        continue;
                    else if (optInativos.Checked && item.Status != Entidades.Enumeradores.Status.Inativo)
                        continue;
                }
                var linha = new string[2];
                linha[0] = item.Codigo.ToString();
                linha[1] = item.Descricao;
                var itemX = new ListViewItem(linha);
                lvlListagem.Items.Add(itemX);
            }
            Funcoes.ListViewColor(lvlListagem);
        }

        private void lvlListagem_DoubleClick(object sender, EventArgs e)
        {
            btnConfirmar_Click(btnConfirmar, new EventArgs());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lvlListagem.SelectedIndices.Count <= 0)
                return;


            var iSelectedIndex = Convert.ToInt32(lvlListagem.SelectedIndices[0]);
            if (iSelectedIndex >= 0)
            {
                iRetorno = Convert.ToInt32(lvlListagem.Items[iSelectedIndex].Text);
                btnSair_Click(btnSair, new EventArgs());
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void optTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (!optTodos.Checked) return;
            limparCampos();
            PreencherLista(lista);
        }

        private void optAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (!optAtivos.Checked) return;
            limparCampos();
            PreencherLista(lista);
        }

        private void optInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (!optInativos.Checked) return;
            limparCampos();
            PreencherLista(lista);
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim().Equals(string.Empty))
                return;

            var listResult = new List<EntidadeViewPesquisa>(from p in lista where p.Descricao.ToLower().Contains(txtBusca.Text.Trim().ToLower()) select p);
            PreencherLista(listResult);
        }
    }
}
