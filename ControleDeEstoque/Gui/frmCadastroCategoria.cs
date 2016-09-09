using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Modelo;
using DAL;
using BLL;

namespace Gui
{
    public partial class frmCadastroCategoria : Gui.frmModelodeFormulariodeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
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
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                //leitura dos dados da tela
                ModeloCategoria modeloCategoria = new ModeloCategoria();
                modeloCategoria.CatNome = txtNome.Text;

                //obj para gravar os dados no banco
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bllCategoria = new BLLCategoria(cnx);

                if (this.operacao == "Inserir")
                {
                    //cadastrar uma categoria                
                    bllCategoria.Incluir(modeloCategoria);
                    MessageBox.Show("Cadastro efetuado, Codigo" + modeloCategoria.CatCod.ToString());
                }
                else
                {
                    //Alterar uma categoria
                    modeloCategoria.CatCod = Convert.ToInt32(txtCodigo.Text);
                    bllCategoria.Alterar(modeloCategoria);
                    MessageBox.Show("Cadastro alterado");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
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
                    BLLCategoria bllCategoria = new BLLCategoria(cnx);

                    bllCategoria.Excluir(Convert.ToInt32(txtCodigo.Text));
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

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            if (f.codigo !=0)
            {                
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bllCategoria = new BLLCategoria(cnx);
                ModeloCategoria modeloCategoria = bllCategoria.CarregaModeloCategoria(f.codigo);
                txtCodigo.Text = modeloCategoria.CatCod.ToString();
                txtNome.Text = modeloCategoria.CatNome.ToString();
                this.alteraBotoes(3);
            }else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }

            f.Dispose();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (this.operacao == "Inserir")
            {
                int r = 0;
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cnx);
                r = bll.VerificaCategoria(txtNome.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um registro com esse valor. Deseja Alterar o registro?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes")
                    {
                        this.operacao = "Alterar";
                        ModeloCategoria modelo = bll.CarregaModeloCategoria(r);
                        txtCodigo.Text = modelo.CatCod.ToString();
                        txtNome.Text = modelo.CatNome.ToString();
                        this.alteraBotoes(3);
                    }
                }
            }
        }
    }
}
