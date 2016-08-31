using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALCategoria
    {
        public DALConexao conexao;

        public DALCategoria(DALConexao cx)
        { 
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@Nome",modelo.CatNome);
            conexao.Conectar();
            modelo.CatCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(ModeloCategoria modelo)        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update categoria set cat_nome = @nome where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@Nome",modelo.CatNome);
            cmd.Parameters.AddWithValue("@codigo",modelo.CatCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from categoria where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from categoria where cat_nome like '%'+'" + valor + "'+'%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            ModeloCategoria modelo = new ModeloCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from categoria where cat_Cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.CatNome = Convert.ToString(registro["cat_nome"]);
            }
            return modelo;
            conexao.Desconectar();

        }



    }
}
