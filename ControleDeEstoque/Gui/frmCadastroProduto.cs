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
using System.IO;

namespace Gui
{
    public partial class frmCadastroProduto : Gui.frmModelodeFormulariodeCadastro
    {
        public string foto = "";

        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);

            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);        

            BLLCategoria bllCategoria = new BLLCategoria(cnx);
            cmbCatCod.DataSource = bllCategoria.Localizar("");
            cmbCatCod.DisplayMember = "cat_nome";
            cmbCatCod.ValueMember = "cat_cod";

            try
            {
                BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);
                cmbScatCod.DataSource = bllSubCategoria.LocalizarPorCategoria((int)cmbCatCod.SelectedValue);
                cmbScatCod.DisplayMember = "scat_nome";
                cmbScatCod.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria");
            }

            BLLUnidadeDeMedida bllUnidadeDeMedida = new BLLUnidadeDeMedida(cnx);
            cmbUmedCod.DataSource = bllUnidadeDeMedida.Localizar("");
            cmbUmedCod.DisplayMember = "umed_nome";
            cmbUmedCod.ValueMember = "umed_cod";
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            this.alteraBotoes(2);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            this.alteraBotoes(1);
            LimpaTela();
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else e.Handled = true;
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else e.Handled = true;

            }

        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(",") == false)
            {
                txtValorPago.Text += ",00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(",") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0,00";
            }

        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(",") == false)
            {
                txtValorVenda.Text += ",00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                txtValorVenda.Text = "0,00";
            }
        }

        private void txtQtde_Leave(object sender, EventArgs e)
        {
            if (txtQtde.Text.Contains(",") == false)
            {
                txtQtde.Text += ",00";
            }
            else
            {
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 1)
                {
                    txtQtde.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtQtde.Text);
            }
            catch
            {
                txtQtde.Text = "0,00";
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQtde.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else e.Handled = true;

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
                    BLLProduto bll = new BLLProduto(cnx);

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

        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();
            this.foto = "";
            pbxFoto.Image = null;
        }        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloProduto modeloProduto = new ModeloProduto();
                modeloProduto.ProNome = txtNome.Text;
                modeloProduto.ProDescricao = txtDescricao.Text;                          
                modeloProduto.ProValorPago = Convert.ToDouble(txtValorPago.Text);
                modeloProduto.ProValorVenda = Convert.ToDouble(txtValorVenda.Text);
                modeloProduto.ProQtde = Convert.ToDouble(txtQtde.Text);
                modeloProduto.UmedCod = Convert.ToInt32(cmbUmedCod.SelectedValue);
                modeloProduto.CatCod = Convert.ToInt32(cmbCatCod.SelectedValue);
                modeloProduto.ScatCod = Convert.ToInt32(cmbScatCod.SelectedValue);

                //obj para gravar os dados no banco
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bllProduto = new BLLProduto(cnx);

                if (this.operacao == "Inserir")
                {
                    modeloProduto.CarregaImagem(this.foto);     
                    bllProduto.Incluir(modeloProduto);
                    MessageBox.Show("Cadastro efetuado, Codigo: " + modeloProduto.ProCod.ToString());
                }
                else
                {
                    modeloProduto.ProCod = Convert.ToInt32(txtCodigo.Text);
                    if (this.foto == "Foto Original")
                    {
                        ModeloProduto mt = bllProduto.CarregaModeloProduto(modeloProduto.ProCod);
                        modeloProduto.ProFoto = mt.ProFoto;
                        
                    }
                    else
                    {
                        modeloProduto.CarregaImagem(this.foto);  
                    }
                    bllProduto.Alterar(modeloProduto);
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

        private void cmbCatCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                cmbScatCod.Text = "";

                BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);
                cmbScatCod.DataSource = bllSubCategoria.LocalizarPorCategoria((int)cmbCatCod.SelectedValue);
                cmbScatCod.DisplayMember = "scat_nome";
                cmbScatCod.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria");
            }
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (!string.IsNullOrEmpty(od.FileName))
            {
                this.foto = od.FileName;
                pbxFoto.Load(this.foto);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            this.foto = "";
            pbxFoto.Image = null;
            pbxFoto.Refresh();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bllProduto = new BLLProduto(cnx);
                ModeloProduto modeloProduto = bllProduto.CarregaModeloProduto(f.codigo);
                txtCodigo.Text = modeloProduto.ProCod.ToString();
                txtNome.Text = modeloProduto.ProNome.ToString();
                txtDescricao.Text = modeloProduto.ProDescricao.ToString();
                //modeloProduto.CarregaImagem(this.foto);
                txtValorPago.Text = modeloProduto.ProValorPago.ToString();
                txtValorVenda.Text = modeloProduto.ProValorVenda.ToString();
                txtQtde.Text = modeloProduto.ProQtde.ToString();
                cmbUmedCod.SelectedValue = modeloProduto.UmedCod;
                cmbCatCod.SelectedValue = modeloProduto.CatCod;
                cmbScatCod.SelectedValue = modeloProduto.ScatCod;
                try
                {
                    MemoryStream ms = new MemoryStream(modeloProduto.ProFoto);
                    pbxFoto.Image = Image.FromStream(ms);
                    this.foto = "Foto Original";

                }
                catch { }

                txtQtde_Leave(sender, e);
                txtValorPago_Leave(sender, e);
                txtValorVenda_Leave(sender, e);
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
