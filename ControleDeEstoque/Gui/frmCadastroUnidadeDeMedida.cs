using Modelo;
using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gui
{
    public partial class frmCadastroUnidadeDeMedida : Gui.frmModelodeFormulariodeCadastro
    {
        public frmCadastroUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void frmCadastroUnidadeDeMedida_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            this.alteraBotoes(2);
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cnx);
                ModeloUnidadeDeMedida modelo = bll.CarregaModeloUnidadeDeMedida(f.codigo);
                txtCodigo.Text = modelo.UmedCod.ToString();
                txtNome.Text = modelo.UmedNome.ToString();
                this.alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }

            f.Dispose();
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
                    BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cnx);

                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados da tela
                ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
                modelo.UmedNome = txtNome.Text;

                //obj para gravar os dados no banco
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cnx);

                if (this.operacao == "Inserir")
                {
                    //cadastrar uma categoria                
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado, Codigo" + modelo.UmedCod.ToString());
                }
                else
                {
                    
                    modelo.UmedCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
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

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (this.operacao == "Inserir")
            {
                int r = 0;
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cnx);
                r = bll.VerificaUnidadeDeMedida(txtNome.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um registro com esse valor. Deseja Alterar o registro?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes")
                    {
                        this.operacao = "Alterar";
                        ModeloUnidadeDeMedida modelo = bll.CarregaModeloUnidadeDeMedida(r);
                        txtCodigo.Text = modelo.UmedCod.ToString();
                        txtNome.Text = modelo.UmedNome.ToString();
                        this.alteraBotoes(3);
                    }
                }
            }
        }
    }
}
