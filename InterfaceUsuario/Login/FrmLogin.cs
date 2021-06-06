using Negocio.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Sistema;

namespace InterfaceUsuario.Login
{
    public partial class FrmLogin : Form
    {
        public bool bFlagLogin;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersao.Text = string.Format(lblVersao.Text, version.Major, version.Minor, version.Build, version.Revision);

            //nn sei se vou usar, ainda estou pensado 23:24 24/05/2021
            CarregarUsuario();
        }

        private void CarregarUsuario()
        {
            //mandando listar no banco 23:24 24/05/2021
            var lista = new UsuarioNG().ListarUsuarioAtivos();
            if(lista.Count > 0)
            {
                foreach(var item in lista)
                {
                    cmbUsuarios.Items.Add(new ComboBoxUsuario(item.Login, item.Codigo, item.Senha));
                }
            }

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Preencha todos os campos do formulário para acessar o sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (txtSenha.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Preencha todos os campos do formulário para acessar o sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = (ComboBoxUsuario)cmbUsuarios.SelectedItem;
            if(item.Senha != txtSenha.Text.Trim())
            {
                MessageBox.Show("Senha Incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bFlagLogin = true;

            Sessao.Usuario = new Entidades.Entidade(item.Codigo, item.Login);
            Sessao.TipoUsuario = new TipoUsuarioNG().BucasTipoUsuarioDoUsuario(item.Codigo);

            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
