using DBMS_PRO1.Controllers;
using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace DBMS_PRO1.FUNCTIONS
{
    public class BookAuthorClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False");
        
        public int addbookauthor(BookAuthorModel bm)
        {
            con.Open();

            string que = $"insert into book_author values('{bm.BookID}', '{bm.AuthorID}')";

            SqlCommand cmd = new SqlCommand(que, con);

            int a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public List<BookAuthorModel> viewbookauthor()
        {
            List<BookAuthorModel> lst = new List<BookAuthorModel>();

            con.Open();

            string que = "Select * from book_author";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BookAuthorModel bm = new BookAuthorModel();

                bm.BookID = int.Parse(dt.Rows[i][0].ToString());
                bm.AuthorID = int.Parse(dt.Rows[i][1].ToString());

                lst.Add(bm);
            }

            con.Close();

            return lst;
        }

        public void deletebookauthor(int bid, int aid)
        {
            con.Open();

            string que = $"delete from book_author where [book id] = '{bid}' and [author id] = '{aid}'";

            SqlCommand cmd = new SqlCommand(que, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public BookAuthorModel getbookauthor(int bid, int aid)
        {
            BookAuthorModel em = new BookAuthorModel();

            con.Open();

            string que = $"select * from book_author where [book id] = '{bid}' and [author id] = '{aid}' ";

            SqlCommand cmd = new SqlCommand(que, con);

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(dt);

            em.BookID = int.Parse(dt.Rows[0][0].ToString());
            em.AuthorID = int.Parse(dt.Rows[0][1].ToString());

            con.Close();

            return em;
        }

        public int updatebookauthor(BookAuthorModel em, int bid, int aid)
        {
            int a;

            con.Open();

            string que = $"UPDATE book_author SET [book id] = '{em.BookID}', [author id] = '{em.AuthorID}' WHERE [book id] = '{bid}' and [author id] = '{aid}'";

            SqlCommand cmd = new SqlCommand(que, con);

            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }
    }
}