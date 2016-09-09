﻿using System;
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
    public partial class frmModelodeFormulariodeCadastro : Form
    {
        public String operacao;


        public frmModelodeFormulariodeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoes(int op)
        {
            /*
             * op = operacoes que serao feitas com os botoes
             * 1= Prepara os botoes para nserir e localizar
             * 2=preparar os ara inserir/alterar um registro
             * 3=preparar a tela para excluir ou alterar           
             */

            pnDados.Enabled = false;
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLocalizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnLocalizar.Enabled = true;                
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }


        }

        private void frmModelodeFormulariodeCadastro_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void frmModelodeFormulariodeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
