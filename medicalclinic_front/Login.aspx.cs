using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace medicalclinic
{
    public partial class Login : System.Web.UI.Page
    {
        static User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            IncorrectDataLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    IncorrectDataLabel.Visible = true;
                    IncorrectDataLabel.Text = "Wprowadź dane!";
                }
                else
                {
                    Database.openConnection();
                    MySqlDataReader sdr = Database.loginReader(TextBox1.Text, TextBox2.Text);
                    if (sdr.Read())
                    {
                        Session["id"] = TextBox1.Text;
                        Response.Redirect("Default.aspx");
                        Session.RemoveAll();
                        sdr.Close();
                    }
                    //MySqlCommand command = Database.executeQuery("SELECT * FROM user_credentials where login = @username AND password = @password");
                    //command.Parameters.AddWithValue("@username", TextBox1.Text);
                    //command.Parameters.AddWithValue("@password", TextBox2.Text);
                    //MySqlDataAdapter sda = new MySqlDataAdapter(command);
                    //DataTable dt = new DataTable();
                    //sda.Fill(dt);
                    //int i = cmd.ExecuteNonQuery();
                    IncorrectDataLabel.Visible = true;
                    if (user.checkAttempt())
                    {
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        Button1.Enabled = false;
                        IncorrectDataLabel.Text = user.showInfo();                      
                    } 
                    else
                        IncorrectDataLabel.Text = user.wrongData();   
                    
                    Database.closeConnection();
                }
            }
            catch
            {
                IncorrectDataLabel.Text = "Błąd";
            }
        }
    }
}