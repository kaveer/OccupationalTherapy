using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsConnectorData
    {
        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataAdapter dta;
        public OleDbDataReader dtr;

        public void Link()
        {
            con = new OleDbConnection();
            cmd = new OleDbCommand();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\otdb.mdb;Persist Security Info=True";
            cmd.Connection = con;

            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }

        }
    }
}
