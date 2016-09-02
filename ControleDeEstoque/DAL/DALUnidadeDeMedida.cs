using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class DALUnidadeDeMedida
    {
       public DALConexao conexao;
       
       public DALUnidadeDeMedida(DALConexao cx)
        { 
            this.conexao = cx;
        }

        public void Incluir(ModeloUnidadeDeMedida modelo)        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into undMedida(umed_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@Nome",modelo.UmedNome);
            conexao.Conectar();
            modelo.UmedCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(ModeloUnidadeDeMedida modelo)        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update undMedida set umed_nome = @nome where umed_cod = @codigo;";
            cmd.Parameters.AddWithValue("@Nome",modelo.UmedNome);
            cmd.Parameters.AddWithValue("@codigo",modelo.UmedCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from undMedida where umed_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from undMedida where umed_nome like '%'+'" + valor + "'+'%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificaUnidadeDeMedida(string valor)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undMedida where umed_nome = @valor";
            cmd.Parameters.AddWithValue("@valor", valor);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r= Convert.ToInt32(registro["umed_cod"]);
            }

            conexao.Desconectar();
            return r;
        }

        public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int codigo)
        {
            ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undMedida where umed_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.UmedNome = Convert.ToString(registro["umed_nome"]);
            }
            return modelo;
            conexao.Desconectar();

        }
    }
}
