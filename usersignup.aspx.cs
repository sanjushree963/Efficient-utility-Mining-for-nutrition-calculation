using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class usersignup : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    string query,gen;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }
    //private int randomnumber(int min, int max)
    //{
    //    Random random = new Random();
    //    return random.Next(min, max);
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        if (RadioButton1.Checked == true)
        {
            gen = "male";
        }
        else
        {
            gen = "female";
        }
        data();
        query = "insert into userdet(name,gender,phone,email,uname,pwd,age)values('" + txtname.Text + "','" + gen + "','" + txtphone.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + txtage.Text + "')";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        data();
        query = "insert into dailytab(uname,workhr,sleephr,resthr,sithr,height,weight,bmi)values('" + txtusername.Text + "','0','0','0','0','0','0','0')";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("index.aspx");
    }
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    txtusername.Text = txtname.Text.Substring(0, 2) + randomnumber(100, 999).ToString();
    //    txtpassword.Text = randomnumber(0000, 99999).ToString();
    //}
    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        data();
        query = "select uname from userdet where uname='" + txtusername.Text + "'";
        cmd = new SqlCommand(query, con);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            lblack.Visible = true;
            Button1.Enabled = false;
        }
        else
        {
            lblack.Visible = false;
            Button1.Enabled = true;
        }
        rd.Close();
        con.Close();
    }
}