using Entidades.Enumeradores;
using Entidades.Produtos;
using Entidades.Sistema;
using InterfaceUsuario.Modulos;
using InterfaceUsuario.Pesquisa;
using Negocio.Produtos;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace InterfaceUsuario.Produtos
{
    public partial class FrmCadSaborPizza : Form
    {
        private bool IsNovo;
        public FrmCadSaborPizza()
        {
            InitializeComponent();
            MascaraCampoCodigo.AplicarEventos(txtCodigo);
            MascaraDinheiro.AplicarEventos(txtValorAdicional);
        }

        private void btnBuscaSaborPizza_Click(object sender, EventArgs e)
        {
            var lista = new SaborPizzaNG().ListarEntidadesViewPesquisa(Status.Todos);
            //Verificando se a lista está vazia
            if (lista.Count < 1)
            {
                MessageBox.Show("Sem dados para serem exibidos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Exibir a lista para o formulario
            var FormPesquisa = new FormPesquisaGenerica("Listagem de Sabores de Pizza", Status.Todos);
            FormPesquisa.lista = lista;
            FormPesquisa.ShowDialog();

            var iRetorno = FormPesquisa.iRetorno;
            //iRetorno = 0;
            if (iRetorno < 1) return;

            txtCodigo.Text = iRetorno.ToString();
            txtCodigo_Validating(txtCodigo, new CancelEventArgs());
            btnBuscaSaborPizza.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos())
                return;

            var oSaborPizza = new SaborPizza();
            var saborPizzaNG = new SaborPizzaNG();

            oSaborPizza.Descricao = txtDescricao.Text.Trim();
            oSaborPizza.Observacao = txtObservacao.Text.Trim();

            MascaraDinheiro.TirarMascara(txtValorAdicional, new EventArgs());
            oSaborPizza.ValorAdicional = Convert.ToDecimal(txtValorAdicional.Text.Trim());
            MascaraDinheiro.RetornarMascara(txtValorAdicional, new EventArgs());
            oSaborPizza.Status = oucSituacao._status;
            oSaborPizza.CodigoUsrAlteracao = Sessao.Usuario.Codigo;
            //Gravando no banco pela primeira vez
            if (IsNovo)
            {
                if (saborPizzaNG.Inserir(oSaborPizza))
                {
                    MessageBox.Show("Usuário Cadastrado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao cadastrar novo usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //Atualiza o Registro
            else
            {
                oSaborPizza.Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
                if (saborPizzaNG.Alterar(oSaborPizza))
                {
                    MessageBox.Show("Dados do adicional alterado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao alterar os dados do adicional!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool VerificarCampos()
        {
            if (txtDescricao.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar a descrição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void FrmCadSaborPizza_Load(object sender, EventArgs e)
        {
            btnCancelar_Click(btnCancelar, new EventArgs());
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigo.Text.Trim().Equals(string.Empty))
            {
                return;
            }

            var oSaborPizza = new AdicionalNG().Buscar(Convert.ToInt32(txtCodigo.Text.Trim()));
            if (oSaborPizza == null)
            {
                btnExcluir.Enabled = false;
                return;
            }

            IsNovo = false;
            txtDescricao.Text = oSaborPizza.Descricao;
            txtObservacao.Text = oSaborPizza.Observacao;
            txtValorAdicional.Text = oSaborPizza.Valor.ToString();
            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            MascaraDinheiro.RetornarMascara(txtValorAdicional, new EventArgs());

            oucSituacao.InicializarSituacao(oSaborPizza.Status);
            btnExcluir.Enabled = true;
        }
        public void LimparCampos()
        {
            txtCodigo.Text = new SaborPizzaNG().BuscarProximoCodigo().ToString();
            txtDescricao.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            txtValorAdicional.Text = string.Empty;
            btnExcluir.Enabled = false;
            oucSituacao.InicializarSituacao(Status.Ativo);
            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            MascaraDinheiro.RetornarMascara(txtValorAdicional, new EventArgs());
            IsNovo = true;
            Funcoes.SelecionarCampo(txtDescricao);
        }

    }
}
