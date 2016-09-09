namespace Gui
{
    partial class frmCadastroProduto
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmbUmedCod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.lblQtde = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.cmbScatCod = new System.Windows.Forms.ComboBox();
            this.lblScatCod = new System.Windows.Forms.Label();
            this.cmbCatCod = new System.Windows.Forms.ComboBox();
            this.lblCatCod = new System.Windows.Forms.Label();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.pbxFoto = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.btnRemover);
            this.pnDados.Controls.Add(this.btnCarregar);
            this.pnDados.Controls.Add(this.lblFoto);
            this.pnDados.Controls.Add(this.pnlFoto);
            this.pnDados.Controls.Add(this.cmbCatCod);
            this.pnDados.Controls.Add(this.lblCatCod);
            this.pnDados.Controls.Add(this.cmbScatCod);
            this.pnDados.Controls.Add(this.lblScatCod);
            this.pnDados.Controls.Add(this.txtValorPago);
            this.pnDados.Controls.Add(this.lblValorPago);
            this.pnDados.Controls.Add(this.txtQtde);
            this.pnDados.Controls.Add(this.lblQtde);
            this.pnDados.Controls.Add(this.txtValorVenda);
            this.pnDados.Controls.Add(this.lblValorVenda);
            this.pnDados.Controls.Add(this.txtDescricao);
            this.pnDados.Controls.Add(this.lblDescricao);
            this.pnDados.Controls.Add(this.txtCodigo);
            this.pnDados.Controls.Add(this.txtNome);
            this.pnDados.Controls.Add(this.cmbUmedCod);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.lblNome);
            this.pnDados.Controls.Add(this.lblCodigo);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(9, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(9, 68);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(350, 20);
            this.txtNome.TabIndex = 2;
            // 
            // cmbUmedCod
            // 
            this.cmbUmedCod.FormattingEnabled = true;
            this.cmbUmedCod.Location = new System.Drawing.Point(182, 378);
            this.cmbUmedCod.Name = "cmbUmedCod";
            this.cmbUmedCod.Size = new System.Drawing.Size(173, 21);
            this.cmbUmedCod.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unidade de Medida";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 52);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(90, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome do Produto";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 13);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(9, 107);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(350, 207);
            this.txtDescricao.TabIndex = 3;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 91);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(110, 13);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descricao do Produto";
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.Location = new System.Drawing.Point(182, 338);
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(173, 20);
            this.txtValorVenda.TabIndex = 5;
            this.txtValorVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenda_KeyPress);
            this.txtValorVenda.Leave += new System.EventHandler(this.txtValorVenda_Leave);
            // 
            // lblValorVenda
            // 
            this.lblValorVenda.AutoSize = true;
            this.lblValorVenda.Location = new System.Drawing.Point(179, 317);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(80, 13);
            this.lblValorVenda.TabIndex = 0;
            this.lblValorVenda.Text = "Valor de Venda";
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(5, 378);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(158, 20);
            this.txtQtde.TabIndex = 6;
            this.txtQtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtde_KeyPress);
            this.txtQtde.Leave += new System.EventHandler(this.txtQtde_Leave);
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Location = new System.Drawing.Point(3, 362);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(62, 13);
            this.lblQtde.TabIndex = 0;
            this.lblQtde.Text = "Quantidade";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(5, 338);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(158, 20);
            this.txtValorPago.TabIndex = 4;
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            this.txtValorPago.Leave += new System.EventHandler(this.txtValorPago_Leave);
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Location = new System.Drawing.Point(6, 319);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(59, 13);
            this.lblValorPago.TabIndex = 0;
            this.lblValorPago.Text = "Valor Pago";
            // 
            // cmbScatCod
            // 
            this.cmbScatCod.FormattingEnabled = true;
            this.cmbScatCod.Location = new System.Drawing.Point(182, 417);
            this.cmbScatCod.Name = "cmbScatCod";
            this.cmbScatCod.Size = new System.Drawing.Size(173, 21);
            this.cmbScatCod.TabIndex = 9;
            // 
            // lblScatCod
            // 
            this.lblScatCod.AutoSize = true;
            this.lblScatCod.Location = new System.Drawing.Point(179, 401);
            this.lblScatCod.Name = "lblScatCod";
            this.lblScatCod.Size = new System.Drawing.Size(117, 13);
            this.lblScatCod.TabIndex = 0;
            this.lblScatCod.Text = "Nome da SubCategoria";
            // 
            // cmbCatCod
            // 
            this.cmbCatCod.FormattingEnabled = true;
            this.cmbCatCod.Location = new System.Drawing.Point(5, 417);
            this.cmbCatCod.Name = "cmbCatCod";
            this.cmbCatCod.Size = new System.Drawing.Size(158, 21);
            this.cmbCatCod.TabIndex = 8;
            this.cmbCatCod.SelectedIndexChanged += new System.EventHandler(this.cmbCatCod_SelectedIndexChanged);
            // 
            // lblCatCod
            // 
            this.lblCatCod.AutoSize = true;
            this.lblCatCod.Location = new System.Drawing.Point(2, 401);
            this.lblCatCod.Name = "lblCatCod";
            this.lblCatCod.Size = new System.Drawing.Size(98, 13);
            this.lblCatCod.TabIndex = 0;
            this.lblCatCod.Text = "Nome da Categoria";
            // 
            // pnlFoto
            // 
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFoto.Controls.Add(this.pbxFoto);
            this.pnlFoto.Location = new System.Drawing.Point(374, 21);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(392, 344);
            this.pnlFoto.TabIndex = 0;
            // 
            // pbxFoto
            // 
            this.pbxFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxFoto.Location = new System.Drawing.Point(0, 0);
            this.pbxFoto.Name = "pbxFoto";
            this.pbxFoto.Size = new System.Drawing.Size(388, 340);
            this.pbxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFoto.TabIndex = 0;
            this.pbxFoto.TabStop = false;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(371, 5);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(28, 13);
            this.lblFoto.TabIndex = 0;
            this.lblFoto.Text = "Foto";
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(374, 371);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(188, 67);
            this.btnCarregar.TabIndex = 0;
            this.btnCarregar.Text = "Carregar Foto";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(582, 371);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(188, 67);
            this.btnRemover.TabIndex = 0;
            this.btnRemover.Text = "Remover Foto";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // frmCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "frmCadastroProduto";
            this.Text = "Cadastro de Produto";
            this.Load += new System.EventHandler(this.frmCadastroProduto_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.PictureBox pbxFoto;
        private System.Windows.Forms.ComboBox cmbCatCod;
        private System.Windows.Forms.Label lblCatCod;
        private System.Windows.Forms.ComboBox cmbScatCod;
        private System.Windows.Forms.Label lblScatCod;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbUmedCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCodigo;
    }
}
