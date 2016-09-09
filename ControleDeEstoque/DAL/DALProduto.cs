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
    public class DALProduto
    {
         public DALConexao conexao;

         public DALProduto(DALConexao cx)
        { 
            this.conexao = cx;
        }

        public void Incluir(ModeloProduto modelo)        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into Produto(pro_nome,pro_descricao,pro_foto,pro_valorpago,pro_valorvenda,pro_qtde,umed_cod,cat_cod,scat_cod) "+
            "values (@nome,@descricao,@foto,@valorpago,@valorvenda,@qtde,@undmedcod,@catcod,@scatcod); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.ProNome);
            cmd.Parameters.AddWithValue("@descricao", modelo.ProDescricao);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (modelo.ProFoto == null)
            {
                //cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else
            {
                //cmd.Parameters.AddWithValue("@foto", modelo.ProFoto);
                cmd.Parameters["@foto"].Value = modelo.ProFoto;
            }            
            cmd.Parameters.AddWithValue("@valorpago", modelo.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", modelo.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", modelo.ProQtde);
            cmd.Parameters.AddWithValue("@undmedcod", modelo.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
            conexao.Conectar();
            modelo.ProCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(ModeloProduto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE produto set pro_nome = @nome,pro_descricao = @descricao, "+
                "pro_foto=@foto,pro_valorpago=@valorpago,pro_valorvenda=@valorvenda,pro_qtde=@qtde, "+
                "umed_cod=@umed_cod,cat_cod=@catcod,scat_cod=@scatcod where pro_cod = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.ProNome);
            cmd.Parameters.AddWithValue("@descricao", modelo.ProDescricao);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (modelo.ProFoto == null)
            {
                //cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else
            {
                //cmd.Parameters.AddWithValue("@foto", modelo.ProFoto);
                cmd.Parameters["@foto"].Value = modelo.ProFoto;
            }
            cmd.Parameters.AddWithValue("@valorpago", modelo.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", modelo.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", modelo.ProQtde);
            cmd.Parameters.AddWithValue("@umed_cod", modelo.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
            cmd.Parameters.AddWithValue("@codigo", modelo.ProCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from produto where pro_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select P.pro_cod,P.pro_nome,P.pro_descricao,P.pro_foto,P.pro_valorpago,P.pro_valorvenda,P.pro_qtde, " +
	                                                "P.umed_cod,U.umed_nome,P.cat_cod,C.cat_nome,P.scat_cod,S.scat_nome from produto P  " +
                                                    "inner join undmedida U on P.umed_cod = U.umed_cod " +
                                                    "inner join categoria C on P.cat_cod = C.cat_cod " +
                                                    "inner join Subcategoria S on P.Scat_cod = S.scat_cod " +
                                                    "where pro_nome like '%'+'" + valor + "'+'%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificaProduto(string valor)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from produto where pro_cod = @valor";
            cmd.Parameters.AddWithValue("@valor", valor);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["pro_cod"]);
            }

            conexao.Desconectar();
            return r;
        }

        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from produto where pro_Cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ProCod = Convert.ToInt32(registro["pro_Cod"]);
                modelo.ProNome = Convert.ToString(registro["pro_nome"]);
                modelo.ProDescricao = Convert.ToString(registro["pro_descricao"]);
                try
                {
                    modelo.ProFoto = (byte[])registro["pro_foto"];
                }
                catch { }                
                modelo.ProValorPago = Convert.ToDouble(registro["pro_valorpago"]);
                modelo.ProValorVenda = Convert.ToDouble(registro["pro_valorvenda"]);
                modelo.ProQtde = Convert.ToInt32(registro["pro_qtde"]);
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.ScatCod = Convert.ToInt32(registro["scat_Cod"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
