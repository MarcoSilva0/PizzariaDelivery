
namespace InterfaceUsuario.Pessoas
{
    partial class FormCadUsuario
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnBuscaUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscaUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginUsuario = new System.Windows.Forms.TextBox();
            this.txtSenhaUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoTipoUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscaTipoUsuario = new System.Windows.Forms.Button();
            this.lblMostraTipoUsuario = new System.Windows.Forms.Label();
            this.oucSituacao = new InterfaceUsuario.UserControls.ucSituacao();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnExcluir);
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmar);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(366, 265);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 50);
            this.flowLayoutPanel1.TabIndex = 0;
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
            // btnBuscaUsuario
            // 
            this.btnBuscaUsuario.Image = global::InterfaceUsuario.Properties.Resources.busca;
            this.btnBuscaUsuario.Location = new System.Drawing.Point(118, 26);
            this.btnBuscaUsuario.Name = "btnBuscaUsuario";
            this.btnBuscaUsuario.Size = new System.Drawing.Size(34, 23);
            this.btnBuscaUsuario.TabIndex = 1;
            this.btnBuscaUsuario.UseVisualStyleBackColor = true;
            this.btnBuscaUsuario.Click += new System.EventHandler(this.btnBuscaUsuario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código:";
            // 
            // txtBuscaUsuario
            // 
            this.txtBuscaUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBuscaUsuario.Location = new System.Drawing.Point(12, 27);
            this.txtBuscaUsuario.Name = "txtBuscaUsuario";
            this.txtBuscaUsuario.Size = new System.Drawing.Size(100, 23);
            this.txtBuscaUsuario.TabIndex = 3;
            this.txtBuscaUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtBuscaUsuario_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome:";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNomeUsuario.Location = new System.Drawing.Point(194, 27);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(531, 23);
            this.txtNomeUsuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login:";
            // 
            // txtLoginUsuario
            // 
            this.txtLoginUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLoginUsuario.Location = new System.Drawing.Point(194, 93);
            this.txtLoginUsuario.Name = "txtLoginUsuario";
            this.txtLoginUsuario.Size = new System.Drawing.Size(247, 23);
            this.txtLoginUsuario.TabIndex = 7;
            // 
            // txtSenhaUsuario
            // 
            this.txtSenhaUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSenhaUsuario.Location = new System.Drawing.Point(478, 93);
            this.txtSenhaUsuario.Name = "txtSenhaUsuario";
            this.txtSenhaUsuario.Size = new System.Drawing.Size(247, 23);
            this.txtSenhaUsuario.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Senha:";
            // 
            // txtCodigoTipoUsuario
            // 
            this.txtCodigoTipoUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCodigoTipoUsuario.Location = new System.Drawing.Point(12, 153);
            this.txtCodigoTipoUsuario.Name = "txtCodigoTipoUsuario";
            this.txtCodigoTipoUsuario.Size = new System.Drawing.Size(100, 23);
            this.txtCodigoTipoUsuario.TabIndex = 12;
            this.txtCodigoTipoUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoTipoUsuario_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Usuário";
            // 
            // btnBuscaTipoUsuario
            // 
            this.btnBuscaTipoUsuario.Image = global::InterfaceUsuario.Properties.Resources.busca;
            this.btnBuscaTipoUsuario.Location = new System.Drawing.Point(118, 152);
            this.btnBuscaTipoUsuario.Name = "btnBuscaTipoUsuario";
            this.btnBuscaTipoUsuario.Size = new System.Drawing.Size(34, 23);
            this.btnBuscaTipoUsuario.TabIndex = 10;
            this.btnBuscaTipoUsuario.UseVisualStyleBackColor = true;
            this.btnBuscaTipoUsuario.Click += new System.EventHandler(this.btnBuscaTipoUsuario_Click);
            // 
            // lblMostraTipoUsuario
            // 
            this.lblMostraTipoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMostraTipoUsuario.Location = new System.Drawing.Point(194, 152);
            this.lblMostraTipoUsuario.Name = "lblMostraTipoUsuario";
            this.lblMostraTipoUsuario.Size = new System.Drawing.Size(531, 24);
            this.lblMostraTipoUsuario.TabIndex = 13;
            this.lblMostraTipoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // oucSituacao
            // 
            this.oucSituacao.Location = new System.Drawing.Point(526, 185);
            this.oucSituacao.Name = "oucSituacao";
            this.oucSituacao.Size = new System.Drawing.Size(199, 69);
            this.oucSituacao.TabIndex = 14;
            // 
            // FormCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 327);
            this.Controls.Add(this.oucSituacao);
            this.Controls.Add(this.lblMostraTipoUsuario);
            this.Controls.Add(this.txtCodigoTipoUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscaTipoUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSenhaUsuario);
            this.Controls.Add(this.txtLoginUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscaUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscaUsuario);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadUsuario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Cadastro de Usuário";
            this.Load += new System.EventHandler(this.FormCadUsuario_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBuscaUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscaUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginUsuario;
        private System.Windows.Forms.TextBox txtSenhaUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoTipoUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscaTipoUsuario;
        private System.Windows.Forms.Label lblMostraTipoUsuario;
        private UserControls.ucSituacao oucSituacao;
        private System.Windows.Forms.Button btnConfirmar;
    }
}