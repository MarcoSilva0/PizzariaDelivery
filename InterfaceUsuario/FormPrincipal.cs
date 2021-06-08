using InterfaceUsuario.Login;
using InterfaceUsuario.Pessoas;
using System;
using System.Windows.Forms;

namespace InterfaceUsuario
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient)
                {
                    control.BackgroundImage = Properties.Resources.fundo; //add o background
                    control.BackgroundImageLayout = ImageLayout.Stretch; //preenchendo o form
                    break;
                }
            }

            var frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (!frmLogin.bFlagLogin) Application.Exit();

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnsUsuCli_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void AbrirFormulario(Form oFrm)
        {
            oFrm.WindowState = FormWindowState.Normal;
            oFrm.StartPosition = FormStartPosition.Manual;
            oFrm.MdiParent = this;
            oFrm.Top = 0;
            oFrm.Left = 0;
            oFrm.Show();
        }

        private void mnsUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCadUsuario());
        }

        private void principal_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void mnsCliente_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCadCliente());
        }
    }
}
