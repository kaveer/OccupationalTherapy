using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointment
    {
        clsConnectorData connect = new clsConnectorData();
        //crud operation
        public bool Test()
        {
            return true;
        }

        public DataTable Retrieve()
        {
            DataTable result = new DataTable();

            connect.Link();
            connect.cmd.CommandText = Model.Commun.clsSQLQuery.RetrieveAppointment;
            connect.dta = new System.Data.OleDb.OleDbDataAdapter(connect.cmd);
            connect.dta.Fill(result);

            return result;
        }
    }
}
