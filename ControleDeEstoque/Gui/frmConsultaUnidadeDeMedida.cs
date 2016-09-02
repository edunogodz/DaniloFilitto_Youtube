using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class frmConsultaUnidadeDeMedida : Form
    {
        public int codigo = 0;
        public frmConsultaUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void frmConsultaUnidadeDeMedida_Load(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Codigo";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Unidade de Medida";
            dgvDados.Columns[1].Width = 670;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //obj para gravar os dados no banco
            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cnx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
            
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
