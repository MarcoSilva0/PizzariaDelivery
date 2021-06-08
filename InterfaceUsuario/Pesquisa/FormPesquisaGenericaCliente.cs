using Entidades.Enumeradores;
using InterfaceUsuario.Modulos;
using Negocio.Pessoas;
using System;
using System.Windows.Forms;

namespace InterfaceUsuario.Pesquisa
{
    public partial class FormPesquisaGenericaCliente : Form
    {
        public int iRetorno = 0;

        public FormPesquisaGenericaCliente(Status status)
        {
            InitializeComponent();
            if (status == Status.Ativo)
                optAtivos.Checked = true;
            else if (status == Status.Inativo)
                optInativos.Checked = true;
            else
                optTodos.Checked = true;
        }

        private void FormPesquisaGenericaCliente_Load(object sender, EventArgs e)
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
            PrepararListView();
            BuscarClientes();
        }

        private void BuscarClientes()
        {
            Status status;
            if (optAtivos.Checked) 
            {
                status = Status.Ativo;
            }
            else if (optInativos.Checked)
            {
                status = Status.Inativo;
            }
            else
            {
                status = Status.Todos;
            }
            lvlListagem.Items.Clear();

            var lista = new ClienteNG().ListarPesquisaCliente(status, txtBusca.Text.Trim());
            if (lista.Count < 1)
                return;
            foreach(var item in lista)
            {
                var linha = new string[4];
                linha[0] = item.Codigo.ToString();
                linha[1] = item.Nome;
                linha[2] = item.Telefone;
                linha[3] = item.Celular;
                var itmx = new ListViewItem(linha);
                lvlListagem.Items.Add(itmx);
            }

            Funcoes.ListViewColor(lvlListagem);
        }

        private void PrepararListView()
        {
            lvlListagem.Clear();
            lvlListagem.View = View.Details;
            lvlListagem.Columns.Add("Código", 80, HorizontalAlignment.Right);
            lvlListagem.Columns.Add("Nome", 270, HorizontalAlignment.Left);
            lvlListagem.Columns.Add("Telefone", 90, HorizontalAlignment.Left);
            lvlListagem.Columns.Add("Celular", 90, HorizontalAlignment.Left);
        }

        public void limparCampos()
        {
            txtBusca.Text = String.Empty;
            iRetorno = 0;
        }
        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (lvlListagem.SelectedIndices.Count <= 0)
                return;


            var iSelectedIndex = Convert.ToInt32(lvlListagem.SelectedIndices[0]);
            if (iSelectedIndex >= 0)
            {
                iRetorno = Convert.ToInt32(lvlListagem.Items[iSelectedIndex].Text);
                btnSair_Click_1(btnSair, new EventArgs());
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!optTodos.Checked) return;
            BuscarClientes();
        }

        private void optAtivos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!optAtivos.Checked) return;
            BuscarClientes();
        }

        private void optInativos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!optInativos.Checked) return;
            BuscarClientes();
        }

        private void lvlListagem_DoubleClick_1(object sender, EventArgs e)
        {
            btnConfirmar_Click_1(btnConfirmar, new EventArgs());
        }

        private void txtBusca_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim().Length < 3)
                return;
            BuscarClientes();
        }

       
    }
}
