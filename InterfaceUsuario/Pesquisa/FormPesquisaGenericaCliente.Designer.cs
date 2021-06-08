
namespace InterfaceUsuario.Pesquisa
{
    partial class FormPesquisaGenericaCliente
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvlListagem = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.optInativos = new System.Windows.Forms.RadioButton();
            this.optAtivos = new System.Windows.Forms.RadioButton();
            this.optTodos = new System.Windows.Forms.RadioButton();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gpbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvlListagem);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 310);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listagem de Clientes";
            // 
            // lvlListagem
            // 
            this.lvlListagem.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvlListagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlListagem.FullRowSelect = true;
            this.lvlListagem.GridLines = true;
            this.lvlListagem.HideSelection = false;
            this.lvlListagem.Location = new System.Drawing.Point(3, 25);
            this.lvlListagem.Name = "lvlListagem";
            this.lvlListagem.Size = new System.Drawing.Size(527, 282);
            this.lvlListagem.TabIndex = 0;
            this.lvlListagem.UseCompatibleStateImageBehavior = false;
            this.lvlListagem.DoubleClick += new System.EventHandler(this.lvlListagem_DoubleClick_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConfirmar);
            this.flowLayoutPanel1.Controls.Add(this.btnSair);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(315, 469);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 52);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Image = global::InterfaceUsuario.Properties.Resources.confirmar;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(122, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(105, 45);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.Image = global::InterfaceUsuario.Properties.Resources.sair;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSair.Location = new System.Drawing.Point(11, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(105, 45);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.optInativos);
            this.gpbStatus.Controls.Add(this.optAtivos);
            this.gpbStatus.Controls.Add(this.optTodos);
            this.gpbStatus.Location = new System.Drawing.Point(15, 72);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(525, 75);
            this.gpbStatus.TabIndex = 9;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Estado";
            // 
            // optInativos
            // 
            this.optInativos.AutoSize = true;
            this.optInativos.Location = new System.Drawing.Point(410, 28);
            this.optInativos.Name = "optInativos";
            this.optInativos.Size = new System.Drawing.Size(82, 25);
            this.optInativos.TabIndex = 2;
            this.optInativos.TabStop = true;
            this.optInativos.Text = "Inativos";
            this.optInativos.UseVisualStyleBackColor = true;
            this.optInativos.CheckedChanged += new System.EventHandler(this.optInativos_CheckedChanged_1);
            // 
            // optAtivos
            // 
            this.optAtivos.AutoSize = true;
            this.optAtivos.Location = new System.Drawing.Point(213, 28);
            this.optAtivos.Name = "optAtivos";
            this.optAtivos.Size = new System.Drawing.Size(71, 25);
            this.optAtivos.TabIndex = 1;
            this.optAtivos.TabStop = true;
            this.optAtivos.Text = "Ativos";
            this.optAtivos.UseVisualStyleBackColor = true;
            this.optAtivos.CheckedChanged += new System.EventHandler(this.optAtivos_CheckedChanged_1);
            // 
            // optTodos
            // 
            this.optTodos.AutoSize = true;
            this.optTodos.Location = new System.Drawing.Point(6, 28);
            this.optTodos.Name = "optTodos";
            this.optTodos.Size = new System.Drawing.Size(68, 25);
            this.optTodos.TabIndex = 0;
            this.optTodos.TabStop = true;
            this.optTodos.Text = "Todos";
            this.optTodos.UseVisualStyleBackColor = true;
            this.optTodos.CheckedChanged += new System.EventHandler(this.optTodos_CheckedChanged_1);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(14, 36);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(526, 29);
            this.txtBusca.TabIndex = 8;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Busca:";
            // 
            // FormPesquisaGenericaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(557, 533);
            this.Controls.Add(this.gpbStatus);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPesquisaGenericaCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Clientes";
            this.Load += new System.EventHandler(this.FormPesquisaGenericaCliente_Load);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvlListagem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.RadioButton optInativos;
        private System.Windows.Forms.RadioButton optAtivos;
        private System.Windows.Forms.RadioButton optTodos;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gpbStatus;
    }
}