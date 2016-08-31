using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String StringDeConexao
        {
            get
            {
                string strPass = "Net Coders";
                return "Data Source=NOGODZ\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;User ID=sa;Password='" + strPass + "'";            

            }
        }
    }
}
