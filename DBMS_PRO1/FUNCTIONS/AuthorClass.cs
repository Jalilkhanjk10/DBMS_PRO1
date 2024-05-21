using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DBMS_PRO1.Models;

namespace DBMS_PRO1.FUNCTIONS
{
    public class AuthorClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False");

        public int addauthor(AuthorModel am)
        {
            con.Open();

            string que = $"insert into author values('{am.AuthorName}')";

            SqlCommand cmd = new SqlCommand(que, con);

            int a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public List<AuthorModel> viewauthor()
        {
            List<AuthorModel> lst = new List<AuthorModel>();

            con.Open();

            string que = "Select * from author";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AuthorModel bm = new AuthorModel();

                bm.AuthorID = int.Parse(dt.Rows[i][0].ToString());
                bm.AuthorName = dt.Rows[i][1].ToString();
                
                lst.Add(bm);
            }

            con.Close();

            return lst;
        }

        public void deleteauthor(int id)
        {
            con.Open();

            string que = $"delete from author where [author id] = '{id}'";

            SqlCommand cmd = new SqlCommand(que, con);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        public AuthorModel getauthor(int id)
        {
            AuthorModel em = new AuthorModel();

            con.Open();

            string que = $"select * from author where [author id] = '{id}' ";

            SqlCommand cmd = new SqlCommand(que, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            em.AuthorID = int.Parse(dt.Rows[0][0].ToString());
            em.AuthorName = dt.Rows[0][1].ToString();
            
            con.Close();

            return em;
        }

        public int updateauthor(AuthorModel em)
        {
            int a;

            con.Open();

            string que = $"UPDATE author SET [author name] = '{em.AuthorName}' WHERE [author id] = '{em.AuthorID}'";

            SqlCommand cmd = new SqlCommand(que, con);

            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }
    }
}