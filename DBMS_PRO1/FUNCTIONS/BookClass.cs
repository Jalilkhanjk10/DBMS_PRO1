using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DBMS_PRO1.Models;

namespace DBMS_PRO1.FUNCTIONS
{
    public class BookClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False");

        public int addbook(BookModel bm)
        {
            con.Open();

            string que = $"insert into book values('{bm.BookTitle}', '{bm.publishedDate}')";

            SqlCommand cmd = new SqlCommand(que, con);

            int a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public List<BookModel> viewbook()
        {
            List<BookModel> lst = new List<BookModel>();

            con.Open();

            string que = "Select * from book";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                BookModel bm = new BookModel();

                bm.BookID = int.Parse(dt.Rows[i][0].ToString());
                bm.BookTitle = dt.Rows[i][1].ToString();
                bm.publishedDate = DateTime.Parse(dt.Rows[i][2].ToString());

                lst.Add(bm);
            }

            con.Close();

            return lst;
        }

        public void deletebook(int id)
        {
            con.Open();

            string que = $"delete from Book where [book id] = '{id}'";

            SqlCommand cmd = new SqlCommand(que, con);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        public BookModel getbook(int id)
        {
            BookModel em = new BookModel();

            con.Open();

            string que = $"select * from book where [book id] = '{id}' ";

            SqlCommand cmd = new SqlCommand(que, con);
            
            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            sda.Fill(dt);

            em.BookID = int.Parse(dt.Rows[0][0].ToString());
            em.BookTitle = dt.Rows[0][1].ToString();
            em.publishedDate = DateTime.Parse(dt.Rows[0][2].ToString());

            con.Close();

            return em;
        }
        
        public int updatebook(BookModel em)
        {
            int a;

            con.Open();

            string que = $"UPDATE book SET [book title] = '{em.BookTitle}', [publish date] = '{em.publishedDate}' WHERE [book id] = '{em.BookID}'";

            SqlCommand cmd = new SqlCommand(que, con);
         
            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }


        /// <summary>
        /// 
        /// VIEW ALL BOOK TO USER WITH AUTHOR
        /// 
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        

        //public List<ViewBookToUserModel> viewbooktouser()
        //{
        //    List<ViewBookToUserModel> lst = new List<ViewBookToUserModel>();

        //    con.Open();

        //    string que = $"SELECT b.[book id], b.[book title], b.[publish date], a.[author id], a.[author name]\r\nFROM Book b\r\nJOIN book_author ba ON b.[book id] = ba.[book id]\r\nJOIN author a ON a.[author id] = ba.[author id];";

        //    SqlCommand cmd = new SqlCommand(que, con);

        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    DataTable dt = new DataTable();

        //    sda.Fill(dt);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ViewBookToUserModel bm = new ViewBookToUserModel();

        //        bm.Bookid = int.Parse(dt.Rows[i][0].ToString());
        //        bm.BookTitle = dt.Rows[i][1].ToString();
        //        bm.PublicationDate = DateTime.Parse(dt.Rows[i][2].ToString());
        //        bm.Authorid = int.Parse(dt.Rows[i][3].ToString()); 
        //        bm.AuthorName = dt.Rows[i][4].ToString();

        //        lst.Add(bm);
        //    }

        //    con.Close();

        //    return lst;
        //}
    }
}