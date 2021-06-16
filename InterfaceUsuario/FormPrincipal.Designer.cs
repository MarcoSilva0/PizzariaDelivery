
namespace InterfaceUsuario
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.MenuStrip principal;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.mnsArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mSair = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.Pessoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnsPessoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsUsuCli = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnsUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.Produto = new System.Windows.Forms.ToolStripMenuItem();
            this.Produtos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Adicionais = new System.Windows.Forms.ToolStripMenuItem();
            this.Pizzas = new System.Windows.Forms.ToolStripMenuItem();
            this.Pizza = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Sabores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsRotinas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsSair = new System.Windows.Forms.ToolStripMenuItem();
            principal = new System.Windows.Forms.MenuStrip();
            principal.SuspendLayout();
            this.mSair.SuspendLayout();
            this.Pessoa.SuspendLayout();
            this.mnsUsuCli.SuspendLayout();
            this.Produtos.SuspendLayout();
            this.Pizza.SuspendLayout();
            this.SuspendLayout();
            // 
            // principal
            // 
            principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsArquivo,
            this.mnsCadastro,
            this.mnsRotinas,
            this.mnsRelatorios});
            principal.Location = new System.Drawing.Point(0, 0);
            principal.Name = "principal";
            principal.Size = new System.Drawing.Size(955, 24);
            principal.TabIndex = 1;
            principal.Text = "mnsPrincipal";
            principal.VisibleChanged += new System.EventHandler(this.principal_VisibleChanged);
            // 
            // mnsArquivo
            // 
            this.mnsArquivo.DropDown = this.mSair;
            this.mnsArquivo.Name = "mnsArquivo";
            this.mnsArquivo.Size = new System.Drawing.Size(61, 20);
            this.mnsArquivo.Text = "Arquivo";
            // 
            // mSair
            // 
            this.mSair.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sair});
            this.mSair.Name = "contextMenuStrip1";
            this.mSair.OwnerItem = this.mnsArquivo;
            this.mSair.Size = new System.Drawing.Size(94, 26);
            this.mSair.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // sair
            // 
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(93, 22);
            this.sair.Text = "Sair";
            // 
            // mnsCadastro
            // 
            this.mnsCadastro.DropDown = this.Pessoa;
            this.mnsCadastro.Name = "mnsCadastro";
            this.mnsCadastro.Size = new System.Drawing.Size(66, 20);
            this.mnsCadastro.Text = "Cadastro";
            // 
            // Pessoa
            // 
            this.Pessoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsPessoa,
            this.Produto});
            this.Pessoa.Name = "Pessoa";
            this.Pessoa.OwnerItem = this.mnsCadastro;
            this.Pessoa.Size = new System.Drawing.Size(123, 48);
            // 
            // mnsPessoa
            // 
            this.mnsPessoa.DropDown = this.mnsUsuCli;
            this.mnsPessoa.Name = "mnsPessoa";
            this.mnsPessoa.Size = new System.Drawing.Size(122, 22);
            this.mnsPessoa.Text = "Pessoas";
            // 
            // mnsUsuCli
            // 
            this.mnsUsuCli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsUsuario,
            this.mnsCliente});
            this.mnsUsuCli.Name = "mnsUsuCli";
            this.mnsUsuCli.OwnerItem = this.mnsPessoa;
            this.mnsUsuCli.Size = new System.Drawing.Size(120, 48);
            this.mnsUsuCli.Opening += new System.ComponentModel.CancelEventHandler(this.mnsUsuCli_Opening);
            // 
            // mnsUsuario
            // 
            this.mnsUsuario.Name = "mnsUsuario";
            this.mnsUsuario.Size = new System.Drawing.Size(119, 22);
            this.mnsUsuario.Text = "Usuários";
            this.mnsUsuario.Click += new System.EventHandler(this.mnsUsuario_Click);
            // 
            // mnsCliente
            // 
            this.mnsCliente.Name = "mnsCliente";
            this.mnsCliente.Size = new System.Drawing.Size(119, 22);
            this.mnsCliente.Text = "Clientes";
            this.mnsCliente.Click += new System.EventHandler(this.mnsCliente_Click_1);
            // 
            // Produto
            // 
            this.Produto.DropDown = this.Produtos;
            this.Produto.Name = "Produto";
            this.Produto.Size = new System.Drawing.Size(122, 22);
            this.Produto.Text = "Produtos";
            // 
            // Produtos
            // 
            this.Produtos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Adicionais,
            this.Pizzas});
            this.Produtos.Name = "Produtos";
            this.Produtos.OwnerItem = this.Produto;
            this.Produtos.Size = new System.Drawing.Size(130, 48);
            this.Produtos.Text = "Produtos";
            // 
            // Adicionais
            // 
            this.Adicionais.Name = "Adicionais";
            this.Adicionais.Size = new System.Drawing.Size(129, 22);
            this.Adicionais.Text = "Adicionais";
            this.Adicionais.Click += new System.EventHandler(this.Adicionais_Click);
            // 
            // Pizzas
            // 
            this.Pizzas.DropDown = this.Pizza;
            this.Pizzas.Name = "Pizzas";
            this.Pizzas.Size = new System.Drawing.Size(129, 22);
            this.Pizzas.Text = "Pizzas";
            // 
            // Pizza
            // 
            this.Pizza.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sabores});
            this.Pizza.Name = "Pizza";
            this.Pizza.OwnerItem = this.Pizzas;
            this.Pizza.Size = new System.Drawing.Size(116, 26);
            this.Pizza.Text = "Pizza";
            // 
            // Sabores
            // 
            this.Sabores.Name = "Sabores";
            this.Sabores.Size = new System.Drawing.Size(115, 22);
            this.Sabores.Text = "Sabores";
            this.Sabores.Click += new System.EventHandler(this.Sabores_Click);
            // 
            // mnsRotinas
            // 
            this.mnsRotinas.Name = "mnsRotinas";
            this.mnsRotinas.Size = new System.Drawing.Size(58, 20);
            this.mnsRotinas.Text = "Rotinas";
            // 
            // mnsRelatorios
            // 
            this.mnsRelatorios.Name = "mnsRelatorios";
            this.mnsRelatorios.Size = new System.Drawing.Size(71, 20);
            this.mnsRelatorios.Text = "Relatórios";
            // 
            // mnsSair
            // 
            this.mnsSair.Name = "mnsSair";
            this.mnsSair.Size = new System.Drawing.Size(93, 22);
            this.mnsSair.Text = "Sair";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 584);
            this.Controls.Add(principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = principal;
            this.Name = "FormPrincipal";
            this.Text = "Pizzaria Delivery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            principal.ResumeLayout(false);
            principal.PerformLayout();
            this.mSair.ResumeLayout(false);
            this.Pessoa.ResumeLayout(false);
            this.mnsUsuCli.ResumeLayout(false);
            this.Produtos.ResumeLayout(false);
            this.Pizza.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsSair;
        private System.Windows.Forms.ToolStripMenuItem mnsArquivo;
        private System.Windows.Forms.ContextMenuStrip mSair;
        private System.Windows.Forms.ToolStripMenuItem sair;
        private System.Windows.Forms.ToolStripMenuItem mnsCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnsRotinas;
        private System.Windows.Forms.ToolStripMenuItem mnsRelatorios;
        private System.Windows.Forms.ContextMenuStrip Pessoa;
        private System.Windows.Forms.ToolStripMenuItem mnsPessoa;
        private System.Windows.Forms.ContextMenuStrip mnsUsuCli;
        private System.Windows.Forms.ToolStripMenuItem mnsUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnsCliente;
        private System.Windows.Forms.ContextMenuStrip Produtos;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Produto;
        private System.Windows.Forms.ToolStripMenuItem Adicionais;
        private System.Windows.Forms.ToolStripMenuItem Pizzas;
        private System.Windows.Forms.ContextMenuStrip Pizza;
        private System.Windows.Forms.ToolStripMenuItem Sabores;
    }
}

