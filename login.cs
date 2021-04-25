public partial class frmLogin : Form
    {
        clsDatabase obj = new clsDatabase();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        
        }
