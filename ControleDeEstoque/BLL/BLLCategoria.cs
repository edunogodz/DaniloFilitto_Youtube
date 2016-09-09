using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCategoria
    {
        public DALConexao conexao;

        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)
        {
            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }

            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloCategoria modelo)
        {
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }

            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }

            //modelo.CatNome = modelo.CatNome.ToUpper();
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(string valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public int VerificaCategoria(string valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.VerificaCategoria(valor);
        }

        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregaModeloCategoria(codigo);
        }

    }
}
