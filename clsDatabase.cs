using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BHM
{
    class clsDatabase
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=dbSales;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        String qry;
        public static string user_role;
        public static int user_id;

        public bool Search(string tblName,string field1,string value1, string field2,string value2)
        {
            
            qry = "select * from " + tblName + " where " + field1 + "='" + value1 + "' and " +  field2 + "='" + value2 + "'";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "tab");
            if (ds.Tables["tab"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        
        }
