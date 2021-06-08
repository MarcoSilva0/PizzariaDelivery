
namespace InterfaceUsuario.Pessoas
{
    partial class FormCadCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.oucSituacao = new InterfaceUsuario.UserControls.ucSituacao();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditarEndereco = new System.Windows.Forms.Button();
            this.btnRemoverEndereco = new System.Windows.Forms.Button();
            this.lvlEnderecos = new System.Windows.Forms.ListView();
            this.btnAdicionarEndereco = new System.Windows.Forms.Button();
            this.chkEndereco = new System.Windows.Forms.CheckBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNomeCliente.Location = new System.Drawing.Point(194, 27);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(667, 23);
            this.txtNomeCliente.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodigo.Location = new System.Drawing.Point(12, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 8;
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.Image = global::InterfaceUsuario.Properties.Resources.busca;
            this.btnBuscaCliente.Location = new System.Drawing.Point(118, 26);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(34, 23);
            this.btnBuscaCliente.TabIndex = 6;
            this.btnBuscaCliente.UseVisualStyleBackColor = true;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // oucSituacao
            // 
            this.oucSituacao.Location = new System.Drawing.Point(659, 539);
            this.oucSituacao.Name = "oucSituacao";
            this.oucSituacao.Size = new System.Drawing.Size(199, 69);
            this.oucSituacao.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnExcluir);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmar);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(499, 619);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 50);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::InterfaceUsuario.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(254, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 45);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::InterfaceUsuario.Properties.Resources.excluir;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.Location = new System.Drawing.Point(143, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(105, 45);
            this.btnExcluir.TabIndex = 1;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Image = global::InterfaceUsuario.Properties.Resources.confirmar;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(32, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(105, 45);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(194, 82);
            this.txtTelefone.Mask = "(00) 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(100, 23);
            this.txtTelefone.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Telefone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Celular:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(330, 82);
            this.txtCelular.Mask = "(00) 00000-0000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(100, 23);
            this.txtCelular.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditarEndereco);
            this.groupBox1.Controls.Add(this.btnRemoverEndereco);
            this.groupBox1.Controls.Add(this.lvlEnderecos);
            this.groupBox1.Controls.Add(this.btnAdicionarEndereco);
            this.groupBox1.Controls.Add(this.chkEndereco);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBairro);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtComplemento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRua);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 422);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço";
            // 
            // btnEditarEndereco
            // 
            this.btnEditarEndereco.Image = global::InterfaceUsuario.Properties.Resources.editar;
            this.btnEditarEndereco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarEndereco.Location = new System.Drawing.Point(135, 373);
            this.btnEditarEndereco.Name = "btnEditarEndereco";
            this.btnEditarEndereco.Size = new System.Drawing.Size(90, 34);
            this.btnEditarEndereco.TabIndex = 25;
            this.btnEditarEndereco.Text = "Editar";
            this.btnEditarEndereco.UseVisualStyleBackColor = true;
            this.btnEditarEndereco.Click += new System.EventHandler(this.btnEditarEndereco_Click);
            // 
            // btnRemoverEndereco
            // 
            this.btnRemoverEndereco.Image = global::InterfaceUsuario.Properties.Resources.excluir;
            this.btnRemoverEndereco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoverEndereco.Location = new System.Drawing.Point(18, 373);
            this.btnRemoverEndereco.Name = "btnRemoverEndereco";
            this.btnRemoverEndereco.Size = new System.Drawing.Size(90, 34);
            this.btnRemoverEndereco.TabIndex = 24;
            this.btnRemoverEndereco.Text = "Remover";
            this.btnRemoverEndereco.UseVisualStyleBackColor = true;
            this.btnRemoverEndereco.Click += new System.EventHandler(this.btnRemoverEndereco_Click);
            // 
            // lvlEnderecos
            // 
            this.lvlEnderecos.CheckBoxes = true;
            this.lvlEnderecos.FullRowSelect = true;
            this.lvlEnderecos.GridLines = true;
            this.lvlEnderecos.HideSelection = false;
            this.lvlEnderecos.Location = new System.Drawing.Point(18, 228);
            this.lvlEnderecos.Name = "lvlEnderecos";
            this.lvlEnderecos.Size = new System.Drawing.Size(812, 139);
            this.lvlEnderecos.TabIndex = 23;
            this.lvlEnderecos.UseCompatibleStateImageBehavior = false;
            // 
            // btnAdicionarEndereco
            // 
            this.btnAdicionarEndereco.Image = global::InterfaceUsuario.Properties.Resources.confirmar;
            this.btnAdicionarEndereco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarEndereco.Location = new System.Drawing.Point(740, 173);
            this.btnAdicionarEndereco.Name = "btnAdicionarEndereco";
            this.btnAdicionarEndereco.Size = new System.Drawing.Size(90, 34);
            this.btnAdicionarEndereco.TabIndex = 22;
            this.btnAdicionarEndereco.Text = "Adicionar";
            this.btnAdicionarEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarEndereco.UseVisualStyleBackColor = true;
            this.btnAdicionarEndereco.Click += new System.EventHandler(this.btnAdicionarEndereco_Click);
            // 
            // chkEndereco
            // 
            this.chkEndereco.AutoSize = true;
            this.chkEndereco.Location = new System.Drawing.Point(620, 182);
            this.chkEndereco.Name = "chkEndereco";
            this.chkEndereco.Size = new System.Drawing.Size(115, 19);
            this.chkEndereco.TabIndex = 21;
            this.chkEndereco.Text = "Endereço Padrão";
            this.chkEndereco.UseVisualStyleBackColor = true;
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCidade.Location = new System.Drawing.Point(318, 180);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(291, 23);
            this.txtCidade.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Cidade:";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBairro.Location = new System.Drawing.Point(18, 180);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(276, 23);
            this.txtBairro.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bairro:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.SystemColors.Window;
            this.txtComplemento.Location = new System.Drawing.Point(171, 111);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(659, 23);
            this.txtComplemento.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Complemento:";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumero.Location = new System.Drawing.Point(18, 111);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(122, 23);
            this.txtNumero.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Número:";
            // 
            // txtRua
            // 
            this.txtRua.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRua.Location = new System.Drawing.Point(18, 52);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(812, 23);
            this.txtRua.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rua:";
            // 
            // FormCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 681);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.oucSituacao);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscaCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cadastro de Clientes";
            this.Load += new System.EventHandler(this.FormCadCliente_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscaCliente;
        private UserControls.ucSituacao oucSituacao;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditarEndereco;
        private System.Windows.Forms.Button btnRemoverEndereco;
        private System.Windows.Forms.ListView lvlEnderecos;
        private System.Windows.Forms.Button btnAdicionarEndereco;
        private System.Windows.Forms.CheckBox chkEndereco;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label8;
    }
}