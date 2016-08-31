using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;
using BLL;

namespace Gui
{
    public partial class frmConsultaCategoria : Form
    {
        public int codigo=0;
        public frmConsultaCategoria()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //obj para gravar os dados no banco
            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bllCategoria = new BLLCategoria(cnx);
            dgvDados.DataSource = bllCategoria.Localizar(txtValor.Text);
        }

        private void frmConsultaCategoria_Load(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Codigo";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 670;
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
