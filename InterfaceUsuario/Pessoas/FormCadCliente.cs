using Entidades.Enumeradores;
using InterfaceUsuario.Modulos;
using InterfaceUsuario.Pesquisa;
using Negocio.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Pessoas
{
    public partial class FormCadCliente : Form
    {
        private bool Isnovo;
        private bool IsSucesso;
        private int iCodEdicao;
        public FormCadCliente()
        {
            InitializeComponent();
            MascaraCampoCodigo.AplicarEventos(txtCodigo);
        }

        public void InicializarEdicao(int iCodEdit)
        {
            IsSucesso = false;
            iCodEdicao = iCodEdit;
        }

        private void FormCadCliente_Load(object sender, EventArgs e)
        {
            //Lista
            PrepararLista();

            //Botão cancelar = Limpar campos
            btnCancelar_Click(btnCancelar, new EventArgs());

            // Verificar se é uma edicao
            if(iCodEdicao > 0)
            {
                txtCodigo.Enabled = false;
                btnBuscaCliente.Enabled = false;
                btnCancelar.Enabled = false;
                txtCodigo.Text = iCodEdicao.ToString();
                txtCodigo_Validating(txtCodigo, new CancelEventArgs());
            }
        }

        private void PrepararLista()
        {
            lvlEnderecos.Clear();
            lvlEnderecos.View = View.Details;
            lvlEnderecos.Columns.Add("Padrão", 50, HorizontalAlignment.Right);
            lvlEnderecos.Columns.Add("Rua", 180, HorizontalAlignment.Left);
            lvlEnderecos.Columns.Add("Número", 50, HorizontalAlignment.Right);
            lvlEnderecos.Columns.Add("Complemento", 160, HorizontalAlignment.Left);
            lvlEnderecos.Columns.Add("Bairro", 80, HorizontalAlignment.Left);
            lvlEnderecos.Columns.Add("Cidade", 80, HorizontalAlignment.Left);
        }

        //----------------<Botoes>-------------------------

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoverEndereco_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarEndereco_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            var formPesquisa = new FormPesquisaGenericaCliente(Status.Todos);
            formPesquisa.gpbStatus.Enabled = true;
            formPesquisa.ShowDialog();
            var iRetorno = formPesquisa.iRetorno;
            if (iRetorno < 1)
                return;
            txtCodigo.Text = iRetorno.ToString();

            txtCodigo_Validating(txtCodigo, new CancelEventArgs());
            //Validação
            btnBuscaCliente.Focus();

        }
        //----------------</Botoes>-------------------------

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigo.Text.Trim().Equals(string.Empty))
                return;
            //Varredura de cliente na base de dados
            var oCliente = new ClienteNG().Buscar(Convert.ToInt32(txtCodigo.Text.Trim()));
            if (oCliente == null)
            {
                if (iCodEdicao > 0)
                {
                    MessageBox.Show("Não foi possível alterar o registro, tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                btnExcluir.Enabled = false;
                return;
            }

            Isnovo = false;
            txtNomeCliente.Text = oCliente.Nome;
            txtTelefone.Text = oCliente.Telefone.ToString();
            txtCelular.Text = oCliente.Celular.ToString();

            LimparCamposEndereco();
            foreach (var item in oCliente.Enderecos)
            {
                PreencherListaEndereco(item);
            }

            oucSituacao.InicializarSituacao(oCliente.Status);
            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            btnExcluir.Enabled = true;
        }

        private void PreencherListaEndereco(Entidades.Pessoas.Endereco obj)
        {
            var linha = new string[6];
            linha[0] = string.Empty;
            linha[1] = obj.Rua;
            linha[2] = obj.Numero.ToString();
            linha[3] = obj.Complemento;
            linha[4] = obj.Bairro;
            linha[5] = obj.Cidade;

            var itmx = new ListViewItem(linha);
            if (obj.isEnderecoPadrao) 
                itmx.Checked = true;
            lvlEnderecos.Items.Add(itmx);
        }

        private void LimparCampos()
        {
            LimparCampos();
            txtCodigo.Text = new ClienteNG().BuscarProximoCodigo().ToString();
            txtNomeCliente.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtCelular.Text = string.Empty;

            lvlEnderecos.Items.Clear();
            btnExcluir.Enabled = false;

            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            oucSituacao.InicializarSituacao(Status.Ativo);

            Isnovo = true;
            Funcoes.SelecionarCampo(txtNomeCliente);
        }
        private void LimparCamposEndereco()
        {
            txtRua.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            chkEndereco.Checked = false;

        }
    }
}