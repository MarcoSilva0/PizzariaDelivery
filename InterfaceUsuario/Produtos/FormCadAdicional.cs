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
    public partial class FormCadAdicional : Form
    {
        private bool IsNovo;
        public FormCadAdicional()
        {
            InitializeComponent();


            MascaraCampoCodigo.AplicarEventos(txtCodigo);
            MascaraDinheiro.AplicarEventos(txtValor);
        }

        private void FormCadAdicional_Load(object sender, EventArgs e)
        {
            btnCancelar_Click(btnCancelar, new EventArgs());
        }

        private void btnBuscaAdicional_Click(object sender, EventArgs e)
        {
            var lista = new AdicionalNG().ListarEntidadesViewPesquisa(Status.Todos);
            //Verificando se a lista está vazia
            if (lista.Count < 1)
            {
                MessageBox.Show("Nenhum usuário encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Exibir a lista para o formulario
            var FormPesquisa = new FormPesquisaGenerica("Listagem de Adicionais", Status.Todos);
            FormPesquisa.lista = lista;
            FormPesquisa.ShowDialog();

            var iRetorno = FormPesquisa.iRetorno;
            //iRetorno = 0;
            if (iRetorno < 1) return;

            txtCodigo.Text = iRetorno.ToString();
            txtCodigo_Validating(txtCodigo, new CancelEventArgs());
            btnBuscaAdicional.Focus();
        }

        private bool VerificarCampos()
        {
            if (txtDescricao.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar a descrição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtValor.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("É necessário informar o Valor do adicional!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos())
                return;

            var oAdicional = new Adicional();
            var adicionalNG = new AdicionalNG();

            oAdicional.Descricao = txtDescricao.Text.Trim();
            oAdicional.Observacao = txtObservacao.Text.Trim();

            MascaraDinheiro.TirarMascara(txtValor, new EventArgs());
            oAdicional.Valor = Convert.ToDecimal(txtValor.Text.Trim());
            MascaraDinheiro.RetornarMascara(txtValor, new EventArgs());
            oAdicional.Status = oucSituacao._status;
            oAdicional.CodigoUsrAlteracao = Sessao.Usuario.Codigo;
            //Gravando no banco pela primeira vez
            if (IsNovo)
            {
                if (adicionalNG.Inserir(oAdicional))
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
                oAdicional.Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
                if (adicionalNG.Alterar(oAdicional))
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim().Equals(string.Empty) || IsNovo)
                return;
            if (MessageBox.Show("Deseja Excluir esse Usuário!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (new AdicionalNG().Excluir(Convert.ToInt32(txtCodigo.Text.Trim())))
                { 
                    MessageBox.Show("Usuário excluido com sucesso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao Excluir registro, tente novamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnBuscaAdicional_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigo.Text.Trim().Equals(string.Empty))
            {
                return;
            }

            var oAdicional = new AdicionalNG().Buscar(Convert.ToInt32(txtCodigo.Text.Trim()));
            if (oAdicional == null)
            {
                btnExcluir.Enabled = false;
                return;
            }

            IsNovo = false;
            txtDescricao.Text = oAdicional.Descricao;
            txtObservacao.Text = oAdicional.Observacao;
            txtValor.Text = oAdicional.Valor.ToString();
            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            MascaraDinheiro.RetornarMascara(txtValor, new EventArgs());
            
            oucSituacao.InicializarSituacao(oAdicional.Status);
            btnExcluir.Enabled = true;
        }

        public void LimparCampos()
        {
            txtCodigo.Text = new AdicionalNG().BuscarProximoCodigo().ToString();
            txtDescricao.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            txtValor.Text = string.Empty;
            btnExcluir.Enabled = false;
            oucSituacao.InicializarSituacao(Status.Ativo);
            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            MascaraDinheiro.RetornarMascara(txtValor, new EventArgs());
            IsNovo = true;
            Funcoes.SelecionarCampo(txtDescricao);
        }
    }
}
