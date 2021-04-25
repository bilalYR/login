class clsDatabase
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=dbSales;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        String qry;
        
        }

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


/////////////////////////////////////////////////////////////////////////////////////////////



private void button1_Click(object sender, EventArgs e)
        {
            clsDatabase obj = new clsDatabase();
            bool chk = obj.Search("tblLogin", "loginId", textBox1.Text, "password", textBox2.Text);

            if (chk == true)
            {
                clsDatabase.user_role= obj.FindField("tblLogin", "loginId", textBox1.Text, "password", textBox2.Text,"role");
                clsDatabase.user_id = int.Parse(obj.FindField("tbllogin", "loginId", textBox1.Text, "password", textBox2.Text, "id"));
                MessageBox.Show("Valid User");
                Form1 f = new Form1();
                this.Hide();
                f.Show();
                this.timer1.Start();
            }
            else
            {
                MessageBox.Show("InValid User");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }
