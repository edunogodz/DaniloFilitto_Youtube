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
    public class BLLSubCategoria
    {
        public DALConexao conexao;

        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da sub categoria é obrigatorio");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }
            
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O codigo da subcategoria é obrigatorio");
            }

            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatorio");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }
                        
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(string valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizarPorCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.LocalizarPorCategoria(codigo);
        }

        public int VerificaSubCategoria(string valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.VerificaSubCategoria(valor);
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }
    }
}
