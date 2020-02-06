using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Techofab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Techofab;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand("insert into techofab (id, fname, lname, gender, contact, dob, course_type, " +
                "course_name, course_duration) values(@id, @fname, @lname, @gender, @contact, @dob, @course_type, " +
                "@course_name, @course_duration)", con))
            {
                try
                {
                    string new_id = ID(fname.Text, dob.Value.Year.ToString(), lname.Text, contact.Text);
                    id.Text = new_id;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", new_id);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@lname", lname.Text);
                    cmd.Parameters.AddWithValue("@gender", gender.Text);
                    cmd.Parameters.AddWithValue("@contact", contact.Text);
                    cmd.Parameters.AddWithValue("@dob", dob.Value);
                    cmd.Parameters.AddWithValue("@course_type", course_type.Text);
                    cmd.Parameters.AddWithValue("@course_name", course_name.Text);
                    cmd.Parameters.AddWithValue("@course_duration", course_duration.Text);

                    int i = 0;
                    i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    ClearField();
                }
            }             

            
        }

        private void Id_Enter(object sender, EventArgs e)
        {

        }

        private void Fname_MouseHover(object sender, EventArgs e)
        {

        }

        private void Fname_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Fname_Enter(object sender, EventArgs e)
        {
            fname.BackColor = Color.LightPink;
        }

        private void Fname_Leave(object sender, EventArgs e)
        {
            fname.BackColor = Color.White;
        }

        private void Lname_Enter(object sender, EventArgs e)
        {
            lname.BackColor = Color.LightPink;
        }

        private void Gender_Enter(object sender, EventArgs e)
        {
            gender.BackColor = Color.LightPink;
        }

        private void Contact_Enter(object sender, EventArgs e)
        {
            contact.BackColor = Color.LightPink;
        }

        private void Course_type_Enter(object sender, EventArgs e)
        {
            course_type.BackColor = Color.LightPink;
        }

        private void Course_name_Enter(object sender, EventArgs e)
        {
            course_name.BackColor = Color.LightPink;
        }

        private void Course_duration_Enter(object sender, EventArgs e)
        {
            course_duration.BackColor = Color.LightPink;
        }

        private void Lname_Leave(object sender, EventArgs e)
        {
            lname.BackColor = Color.White;
        }

        private void Gender_Leave(object sender, EventArgs e)
        {
            gender.BackColor = Color.White;
        }

        private void Contact_Leave(object sender, EventArgs e)
        {
            contact.BackColor = Color.White;
        }

        private void Course_type_Leave(object sender, EventArgs e)
        {
            course_type.BackColor = Color.White;
        }

        private void Course_name_Leave(object sender, EventArgs e)
        {
            course_name.BackColor = Color.White;
        }

        private void Course_duration_Leave(object sender, EventArgs e)
        {
            course_duration.BackColor = Color.White;
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            id.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Techofab;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand("select * from Techofab where lname='" + lname.Text + "'", con))
            {


                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    if (reader.Read())
                    {



                        id.Text = reader.GetValue(0).ToString();
                        fname.Text = reader.GetValue(1).ToString();
                        lname.Text = reader.GetValue(2).ToString();
                        gender.Text = reader.GetValue(3).ToString();
                        contact.Text = reader.GetValue(4).ToString();

                        course_type.Text = reader.GetValue(6).ToString();
                        course_name.Text = reader.GetValue(7).ToString();
                        course_duration.Text = reader.GetValue(8).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No data found");
                }

                con.Close();

            }



        }

        
        public void Button2_Click(object sender, EventArgs e)
        {
            id.Text = "";
            fname.Text = "";
            lname.Text = "";
            gender.Text = "";
            contact.Text = "";

            course_type.Text = "";
            course_name.Text = "";
            course_duration.Text = "";
            
        }

        //PRE-DEFINED METHODS BELOW.....................


        private void ClearField()
        {
                                   
            fname.Clear();
            lname.Clear();
            gender.Text = "";
            contact.Clear();
            course_type.Text = "";
            course_name.Text = "";
            course_duration.Clear();
        }

        public string ID(string fname, string dob, string lname, string contact_number)
        {
            string id = fname.Substring(0, 2) + dob + lname.Substring(0,2) + contact_number.Substring(4, 5);                       
            return id;
        }

        
        
    }
}
