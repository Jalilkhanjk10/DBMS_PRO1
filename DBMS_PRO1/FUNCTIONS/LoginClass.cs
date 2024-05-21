using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBMS_PRO1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DBMS_PRO1.FUNCTIONS
{
    public class LoginClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False"); 

        public int signup(LoginModel lm)
        {
            int a;

            con.Open();

            string que = $"Insert into LoginSignUp values('{lm.User_Name}', '{lm.User_Password}', '{lm.UserType}')";

            SqlCommand cmdjk = new SqlCommand(que, con);

            a = cmdjk.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public int login(LoginModel lm)
        {
            int a;

            con.Open();

            string que = $"Select * from LoginSignup where [User Name] = '{lm.User_Name}' and [User Password] = '{lm.User_Password}'";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            a = dt.Rows.Count;

            con.Close();

            return a;
        }

        public int adminlogin(AdminLoginModel lm)
        {
            int a;

            con.Open();

            string que = $"Select * from Admin where [Admin Name] = '{lm.Admin_Name}' and [Password] = '{lm.Password}'";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            a = dt.Rows.Count;

            con.Close();

            return a;
        }

        public int getuserid(LoginModel lm)
        {
            int a;

            con.Open();

            string que = $"Select [User id] from LoginSignUp where [User Name] = '{lm.User_Name}' and" +
                $"[User Password] = '{lm.User_Password}'";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            a = int.Parse(dt.Rows[0][0].ToString());

            return a;
        }
    }
}