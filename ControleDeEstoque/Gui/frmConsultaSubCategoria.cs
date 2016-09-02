﻿using BLL;
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
    public partial class frmConsultaSubCategoria : Form
    {
        public int codigo = 0;
        public int catCod = 0;

        public frmConsultaSubCategoria()
        {
            InitializeComponent();
        }

        private void frmConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Codigo Da SubCategoria";
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].HeaderText = "Nome da SubCategoria";
            dgvDados.Columns[1].Width = 200;
            dgvDados.Columns[2].HeaderText = "Codigo da Categoria";
            dgvDados.Columns[2].Width = 100;
            dgvDados.Columns[3].HeaderText = "Nome da Categoria";
            dgvDados.Columns[3].Width = 200; 
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cnx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubCategoria bllSubCategoria = new BLLSubCategoria(cnx);
            dgvDados.DataSource = bllSubCategoria.Localizar(txtValor.Text);
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
