using Entidades.Enumeradores;
using Entidades.Pessoas;
using Entidades.Sistema;
using InterfaceUsuario.Modulos;
using InterfaceUsuario.Pesquisa;
using Negocio.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace InterfaceUsuario.Pessoas
{
    public partial class FormCadCliente : Form
    {
        private bool IsNovo;
        private bool IsSucesso;
        private int iCodEdicao;
        private bool isInibirAutoChek;
        public FormCadCliente()
        {
            InitializeComponent();
            MascaraCampoCodigo.AplicarEventos(txtCodigo);
            MascaraCampoNumero.AplicarEventos(txtNumero);
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
            if (iCodEdicao > 0)
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
            if (!VerificarCampos())
                return;

            Cliente oCliente = new Cliente();
            oCliente.Nome = txtNomeCliente.Text.Trim();
            oCliente.Telefone = Funcoes.RemoverMascaraNumerico(txtTelefone);
            oCliente.Celular = Funcoes.RemoverMascaraNumerico(txtCelular);
            oCliente.Enderecos = MontarListaListViewEnderecos();
            oCliente.Status = oucSituacao._status;
            oCliente.CodigoUsrAlteracao = Sessao.Usuario.Codigo;

            ClienteNG ngCliente = new ClienteNG();

            //inserir na Base
            if (IsNovo)
            {
                if (ngCliente.Inserir(oCliente))
                {
                    MessageBox.Show("Cliente inserido com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao inserir o cliente, tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//Alterando na Base
            else
            {
                oCliente.Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
                if (ngCliente.Alterar(oCliente))
                {
                    MessageBox.Show("Cliente atualizado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar os dados do cliente, tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private List<Endereco> MontarListaListViewEnderecos()
        {
            List<Endereco> lEnderecos = new List<Endereco>();
            foreach(ListViewItem item in lvlEnderecos.Items)
            {
                Endereco oEndereco = new Endereco();
                if (IsNovo)
                    oEndereco.CodigoCliente = Convert.ToInt32(txtCodigo.Text.Trim());
                oEndereco.IsEnderecoPadrao = item.Checked;
                oEndereco.Rua = item.SubItems[1].Text;
                oEndereco.Numero = Convert.ToInt32(item.SubItems[2].Text);
                oEndereco.Complemento = item.SubItems[3].Text;
                oEndereco.Bairro = item.SubItems[4].Text;
                oEndereco.Cidade = item.SubItems[5].Text;

                lEnderecos.Add(oEndereco);
            }
            return lEnderecos;
        }

        private bool VerificarCampos()
        {
            if (txtNomeCliente.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Informe o nome do cliente e tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTelefone.Text.Trim().Equals(string.Empty) && txtCelular.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Informe o telefone ou celular do cliente e tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(lvlEnderecos.Items.Count < 1)
            {
                MessageBox.Show("Informe ao menos um endereço e tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int iContCheck = 0;
            foreach(ListViewItem item in lvlEnderecos.Items)
            {
                if (item.Checked)
                    iContCheck++;
            }
            if(iContCheck == 0)
            {
                MessageBox.Show("Informe o endereço padrão para o cliente e tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (iContCheck > 1)
            {
                MessageBox.Show("Informe apenas um endereço padrão para o cliente e tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Excluir registro
            if (!txtCodigo.Text.Trim().Equals(string.Empty))
            {
                if(MessageBox.Show("Deseja excluir esse cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(new ClienteNG().Excluir(Convert.ToInt32(txtCodigo.Text.Trim())))
                    {
                        MessageBox.Show("Cliente Excluído com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir o cliente, tente novamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private bool VericarCamposEndereco()
        {
            if (txtRua.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informar o nome da Rua!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNumero.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informar o Número do endereço!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtBairro.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informar o Bairro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCidade.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informar a Cidade!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            if (!VericarCamposEndereco())
                return;

            var oEndereco = new Endereco();

            oEndereco.Rua = txtRua.Text.Trim();
            oEndereco.Numero = Convert.ToInt32(txtNumero.Text.Trim());
            oEndereco.Complemento = txtComplemento.Text.Trim();
            oEndereco.Bairro = txtBairro.Text.Trim();
            oEndereco.Cidade = txtCidade.Text.Trim();
            oEndereco.IsEnderecoPadrao = chkEndereco.Checked;

            PreencherListaEndereco(oEndereco);
            LimparCamposEndereco();
        }

        private void btnRemoverEndereco_Click(object sender, EventArgs e)
        {
            if (lvlEnderecos.SelectedIndices.Count <= 0)
                return;

            var iSelectedIndex = Convert.ToInt32(lvlEnderecos.SelectedIndices[0]);
            if (iSelectedIndex >= 0)
                lvlEnderecos.Items[iSelectedIndex].Remove();
        }

        private void btnEditarEndereco_Click(object sender, EventArgs e)
        {
            if (lvlEnderecos.SelectedIndices.Count <= 0)
                return;

            var iSelectedIndex = Convert.ToInt32(lvlEnderecos.SelectedIndices[0]);
            if (iSelectedIndex >= 0)
            {
                var oEndereco = new Endereco();
                oEndereco.IsEnderecoPadrao = lvlEnderecos.Items[iSelectedIndex].Checked;
                oEndereco.Rua = lvlEnderecos.Items[iSelectedIndex].SubItems[1].Text;
                oEndereco.Numero = Convert.ToInt32(lvlEnderecos.Items[iSelectedIndex].SubItems[2].Text);
                oEndereco.Complemento = lvlEnderecos.Items[iSelectedIndex].SubItems[3].Text;
                oEndereco.Bairro = lvlEnderecos.Items[iSelectedIndex].SubItems[4].Text;
                oEndereco.Cidade = lvlEnderecos.Items[iSelectedIndex].SubItems[5].Text;

                
                PreencherCamposEndereco(oEndereco);
                lvlEnderecos.Items[iSelectedIndex].Remove();
            }

        }

        private void PreencherCamposEndereco(Endereco oEndereco)
        {
            txtRua.Text = oEndereco.Rua;
            txtNumero.Text = oEndereco.Numero.ToString();
            txtComplemento.Text = oEndereco.Complemento;
            txtBairro.Text = oEndereco.Bairro;
            txtCidade.Text = oEndereco.Cidade;
            chkEndereco.Checked = oEndereco.IsEnderecoPadrao;
        }

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

            IsNovo = false;
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

            MascaraCampoNumero.RetornarMascara(txtNumero, new EventArgs());


            btnExcluir.Enabled = true;
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
            if (obj.IsEnderecoPadrao)
                itmx.Checked = true;
            lvlEnderecos.Items.Add(itmx);
        }

        private void LimparCampos()
        {

            txtCodigo.Text = new ClienteNG().BuscarProximoCodigo().ToString();
            txtNomeCliente.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtCelular.Text = string.Empty;

            lvlEnderecos.Items.Clear();
            btnExcluir.Enabled = false;

            MascaraCampoCodigo.RetornarMascara(txtCodigo, new EventArgs());
            MascaraCampoNumero.RetornarMascara(txtNumero, new EventArgs());

            oucSituacao.InicializarSituacao(Status.Ativo);

            IsNovo = true;
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

        private void lvlEnderecos_DoubleClick(object sender, EventArgs e)
        {
            btnEditarEndereco_Click(btnEditarEndereco, new EventArgs());
        }

        private void lvlEnderecos_MouseDown(object sender, MouseEventArgs e)
        {
            isInibirAutoChek = true;
        }

        private void lvlEnderecos_MouseUp(object sender, MouseEventArgs e)
        {
            isInibirAutoChek = false;
        }

        private void lvlEnderecos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isInibirAutoChek) 
            { 
                e.NewValue = e.CurrentValue;
                return;
            }
            if(VerificarSeExisteEnderecoPadrao()&& e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
                MessageBox.Show("Pode haver somente um endereço padrão", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarSeExisteEnderecoPadrao()
        {
            foreach(ListViewItem item in lvlEnderecos.Items)
            {
                if (item.Checked)
                    return true;
            }
            return false;
        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}