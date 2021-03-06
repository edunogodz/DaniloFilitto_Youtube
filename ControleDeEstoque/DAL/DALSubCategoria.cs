﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALSubCategoria
    {
        public DALConexao conexao;

        public DALSubCategoria(DALConexao cx)
        { 
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modelo)        
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into subcategoria(scat_nome,cat_cod) values (@nome,@catcod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@Nome", modelo.ScatNome);
                conexao.Conectar();
                modelo.ScatCod = Convert.ToInt32(cmd.ExecuteScalar());                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
            
        }

        public void Alterar(ModeloSubCategoria modelo)        
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update subcategoria set scat_nome = @nome , cat_cod = @catcod where scat_cod = @scatcod;";
                cmd.Parameters.AddWithValue("@Nome", modelo.ScatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();                
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from subcategoria where scat_cod = @scat_cod;";
                cmd.Parameters.AddWithValue("@scat_cod", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Este registro esta sendo utilizado em outra tabela:" + erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select scat_cod,scat_nome,c.cat_cod, c.cat_nome from subcategoria s join categoria C on C.cat_cod = S.cat_cod where scat_nome like '%'+'" + valor + "'+'%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarPorCategoria(int codigo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select scat_cod,scat_nome,c.cat_cod, c.cat_nome from subcategoria s join categoria C on C.cat_cod = S.cat_cod where s.cat_cod = '" + codigo + "'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificaSubCategoria(string valor)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from subcategoria where scat_nome = @valor";
            cmd.Parameters.AddWithValue("@valor", valor);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["scat_cod"]);
            }

            conexao.Desconectar();
            return r;
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            ModeloSubCategoria modelo = new ModeloSubCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from subcategoria where scat_Cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ScatCod = Convert.ToInt32(registro["scat_cod"]);
                modelo.ScatNome = Convert.ToString(registro["scat_nome"]);
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
            }
            return modelo;
            conexao.Desconectar();

        }


    }
}
