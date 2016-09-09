using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Modelo;
using System.Data;

namespace BLL
{
    public class BLLProduto
    {
         public DALConexao conexao;
         public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloProduto modelo)
        {
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio");
            }

            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatorio");
            }

            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatorio");
            }

            if (modelo.ProQtde <= 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da Categoria é obrigatorio");
            }

            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O codigo da SubCategoria é obrigatorio");
            }

            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloProduto modelo)
        {
            if (modelo.ProCod <= 0)
            {
                throw new Exception("O codigo do produto é obrigatorio");
            }

            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio");
            }

            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatorio");
            }

            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatorio");
            }

            if (modelo.ProQtde <= 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da Categoria é obrigatorio");
            }

            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O codigo da SubCategoria é obrigatorio");
            }

            DALProduto DALobj = new DALProduto(conexao);            
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao); 
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(string valor)
        {
            DALProduto DALobj = new DALProduto(conexao); 
            return DALobj.Localizar(valor);
        }

        public int VerificaProduto(string valor)
        {
            DALProduto DALobj = new DALProduto(conexao); 
            return DALobj.VerificaProduto(valor);
        }

        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao); 
            return DALobj.CarregaModeloProduto(codigo);
        }

    }
}
