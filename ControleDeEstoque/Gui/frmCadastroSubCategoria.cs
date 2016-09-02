using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gui
{
    public partial class frmCadastroSubCategoria : Gui.frmModelodeFormulariodeCadastro
    {
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }

        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bllCategoria = new BLLCategoria(cnx);
            cmbCatCod.DataSource = bllCategoria.Localizar("");
            cmbCatCod.DisplayMember = "cat_nome";
            cmbCatCod.ValueMember = "cat_cod";
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            this.alteraBotoes(2);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //limpar a tela
            LimpaTela();
            this.alteraBotoes(1);
        }

        public void LimpaTela()
        {
            txtScatCod.Clear();
            txtNome.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados da tela
                ModeloSubCategoria modeloSubCategoria = new ModeloSubCategoria();
                modeloSubCategoria.ScatNome = txtNome.Text;
                modeloSubCategoria.CatCod = Convert.ToInt32(cmbCatCod.SelectedValue);

                //obj para gravar os dados no banco
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);

                if (this.operacao == "Inserir")
                {
                    bllSubCategoria.Incluir(modeloSubCategoria);
                    MessageBox.Show("Cadastro efetuado, Codigo: " + modeloSubCategoria.ScatCod.ToString());
                }
                else
                {                    
                    modeloSubCategoria.ScatCod = Convert.ToInt32(txtScatCod.Text);
                    bllSubCategoria.Alterar(modeloSubCategoria);
                    MessageBox.Show("Cadastro alterado");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    //obj para gravar os dados no banco
                    DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);

                    bllSubCategoria.Excluir(Convert.ToInt32(txtScatCod.Text));
                    MessageBox.Show("Cadastro excluido");
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossivel excluir o registro.\n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }
                
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);
                ModeloSubCategoria ModeloSubCategoria = bllSubCategoria.CarregaModeloSubCategoria(f.codigo);
                txtScatCod.Text = ModeloSubCategoria.ScatCod.ToString();
                txtNome.Text = ModeloSubCategoria.ScatNome.ToString();
                cmbCatCod.SelectedValue = ModeloSubCategoria.CatCod;
                this.alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }

            f.Dispose();
        }
    }
}
