using Entidades.Enumeradores;
using Entidades.Pessoas;
using Entidades.Sistema;
using InterfaceUsuario.Modulos;
using InterfaceUsuario.Pesquisa;
using Negocio.Pessoas;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace InterfaceUsuario.Pessoas
{
    public partial class FormCadUsuario : Form
    {
        private bool IsNovo;

        public FormCadUsuario()
        {
            InitializeComponent();
            MascaraCampoCodigo.AplicarEventos(txtBuscaUsuario);
            MascaraCampoCodigo.AplicarEventos(txtCodigoTipoUsuario);
        }

        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            var lista = new UsuarioNG().ListarEntidadesViewPesquisa(Status.Todos);
            //Verificando se a lista está vazia
            if (lista.Count < 1)
            {
                MessageBox.Show("Nenhum usuário encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Exibir a lista para o formulario
            var FormPesquisa = new FormPesquisaGenerica("Listagem de Usuários", Status.Todos);
            FormPesquisa.lista = lista;
            FormPesquisa.ShowDialog();

            var iRetorno = FormPesquisa.iRetorno;
            if (iRetorno < 1) return;

            txtBuscaUsuario.Text = iRetorno.ToString();
            txtBuscaUsuario_Validating(txtBuscaUsuario, new CancelEventArgs());
            btnBuscaUsuario.Focus();
        }

        private void btnBuscaTipoUsuario_Click(object sender, EventArgs e)
        {
            var lista = new TipoUsuarioNG().ListarEntidadesViewPesquisa();
            //Verificando se a lista está vazia
            if (lista.Count < 1)
            {
                MessageBox.Show("Nenhum usuário encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Exibir a lista para o formulario
            var FormPesquisa = new FormPesquisaGenerica("Listagem de Tipos de Usuários", Status.Todos);
            FormPesquisa.lista = lista;
            FormPesquisa.ShowDialog();

            var iRetorno = FormPesquisa.iRetorno;
            if (iRetorno < 1) return;

            txtCodigoTipoUsuario.Text = iRetorno.ToString();
            txtCodigoTipoUsuario_Validating(txtCodigoTipoUsuario, new CancelEventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodigoTipoUsuario, new EventArgs());
            btnBuscaTipoUsuario.Focus();
        }

        private void txtBuscaUsuario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBuscaUsuario.Text.Trim().Equals(string.Empty))
            {
                return;
            }

            var oUsuario = new UsuarioNG().Buscar(Convert.ToInt32(txtBuscaUsuario.Text.Trim()));
            if(oUsuario == null)
            {
                btnExcluir.Enabled = false;
                return;
            }

            IsNovo = false;
            txtNomeUsuario.Text = oUsuario.Nome;
            txtLoginUsuario.Text = oUsuario.Login;
            txtSenhaUsuario.Text = oUsuario.Senha;
            txtCodigoTipoUsuario.Text = oUsuario.TipoUsuario.Codigo.ToString();

            //Validando o tipo usuario
            txtCodigoTipoUsuario_Validating(txtCodigoTipoUsuario, new CancelEventArgs());

            //Mascara dos campos codigos
            MascaraCampoCodigo.RetornarMascara(txtBuscaUsuario, new EventArgs());

            //Mascara do campo tipo usuario
            MascaraCampoCodigo.RetornarMascara(txtCodigoTipoUsuario, new EventArgs());

            oucSituacao.InicializarSituacao(oUsuario.Status);
            btnExcluir.Enabled = false;
        }

        public void LimparCampos()
        {
            txtBuscaUsuario.Text = new UsuarioNG().BuscarProximoCodigo().ToString();
            txtNomeUsuario.Text = string.Empty;
            txtLoginUsuario.Text = string.Empty;
            txtSenhaUsuario.Text = string.Empty;
            txtCodigoTipoUsuario.Text = string.Empty;
            btnExcluir.Enabled = false;
            oucSituacao.InicializarSituacao(Status.Ativo);
            MascaraCampoCodigo.RetornarMascara(txtBuscaUsuario, new EventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodigoTipoUsuario, new EventArgs());
            IsNovo = true;
            Funcoes.SelecionarCampo(txtNomeUsuario);
        }

        private void FormCadUsuario_Load(object sender, EventArgs e)
        {
            btnCancelar_Click(btnCancelar, new EventArgs());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private bool VerificarCampos()
        {
            if (txtNomeUsuario.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar o Nome do usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLoginUsuario.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar o Login do usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLoginUsuario.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar a Senha do usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCodigoTipoUsuario.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar o Tipo do usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos())
                return;
            var oUsuario = new Usuario();
            oUsuario.Nome = txtNomeUsuario.Text.Trim();
            oUsuario.Login = txtLoginUsuario.Text.Trim();
            oUsuario.Senha = txtSenhaUsuario.Text.Trim();
            oUsuario.TipoUsuario.Codigo = Convert.ToInt32(txtCodigoTipoUsuario.Text.Trim());
            oUsuario.Status = oucSituacao._status;
            oUsuario.CodigoUsrAlteracao = Sessao.Usuario.Codigo;
            //Gravando no banco pela primeira vez
            if (IsNovo)
            {

            }
            //Atualiza o Registro
            else
            {

            }
        }

        private void txtCodigoTipoUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigoTipoUsuario.Text.Trim().Equals(string.Empty))
            {
                lblMostraTipoUsuario.Text = string.Empty;
                return;
            }

            var oTipoUsuario = new TipoUsuarioNG().Buscar(Convert.ToInt32(txtCodigoTipoUsuario.Text.Trim()));
            if(oTipoUsuario == null)
            {
                MessageBox.Show("Tipo de usuário não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoTipoUsuario.Select();
                return;
            }

            lblMostraTipoUsuario.Text = oTipoUsuario.Descricao;

        }
    }
}