using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_PRO1.FUNCTIONS
{
    public class BookCopyClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False");

        public int insertcopybookid(BookCopyModel model)
        {
            int a;

            con.Open();

            string que = $"insert into book_copy values('{model.Copyid}','{model.Bookid}')";

            SqlCommand cmd = new SqlCommand(que, con);

            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public List<BookCopyModel> ViewCopyBookid()
        {
            List<BookCopyModel> lst = new List<BookCopyModel>();

            con.Open();

            string que = "Select * from book_copy";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BookCopyModel bm = new BookCopyModel();

                bm.Copyid = int.Parse(dt.Rows[i][0].ToString());
                bm.Bookid = int.Parse(dt.Rows[i][1].ToString());

                lst.Add(bm);
            }

            con.Close();

            return lst;
        }

        public int deletecopybookid(int id)
        {
            int a;

            con.Open();

            string que = $"delete from book_copy where [copy id] = '{id}'";

            SqlCommand cmd = new SqlCommand(que, con);

            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }
    }
}