using DBMS_PRO1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_PRO1.FUNCTIONS
{
    public class IssueBookClass
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-VH2TT86\\SQLEXPRESS;Initial Catalog=DBMS_PRO_DB;Integrated Security=True;Encrypt=False");

        public int issuebook(int userid, int bookid, DateTime futuredate )
        {
            int a = 0;

            con.Open();

            string que = $"insert into [Issuance_Book] values(GETDATE(), '{userid}', '{bookid}', '{futuredate}')";

            SqlCommand cmd = new SqlCommand( que, con );

            a = cmd.ExecuteNonQuery();

            con.Close();

            return a;
        }

        public List<ViewBookToUserModel> viewbooktouser()
        {
            List<ViewBookToUserModel> lst = new List<ViewBookToUserModel>();

            con.Open();

            string que = $"SELECT b.[book id], b.[book title], b.[publish date], a.[author id], a.[author name]\r\nFROM Book b\r\nJOIN book_author ba ON b.[book id] = ba.[book id]\r\nJOIN author a ON a.[author id] = ba.[author id];";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewBookToUserModel bm = new ViewBookToUserModel();

                bm.Bookid = int.Parse(dt.Rows[i][0].ToString());
                bm.BookTitle = dt.Rows[i][1].ToString();
                bm.PublicationDate = DateTime.Parse(dt.Rows[i][2].ToString());
                bm.Authorid = int.Parse(dt.Rows[i][3].ToString());
                bm.AuthorName = dt.Rows[i][4].ToString();

                lst.Add(bm);
            }

            con.Close();

            return lst;
        }

        public List<UserIssuedBookModel> userissuedbook(int userid)
        {
            List<UserIssuedBookModel> lst = new List<UserIssuedBookModel>();

            con.Open();

            string que = "SELECT u.[User Name], b.[book title], bi.[bk issuance date]," +
                " bi.[bk due date] FROM Issuance_Book bi " +
                "JOIN LoginSignUp u ON bi.[member id] = u.[User ID] " +
                "JOIN detail_book bd ON bi.[bk issuance id] = bd.[bk issuance id] " +
                "JOIN book_copy bc ON bd.[copy id] = bc.[copy id] " +
                "JOIN Book b ON bc.[book id] = b.[book id] " +
                $"WHERE bi.[member id] = '{userid}'";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                UserIssuedBookModel obj = new UserIssuedBookModel();

                obj.Username = dt.Rows[i][0].ToString();
                obj.Booktitle = dt.Rows[i][1].ToString();
                obj.Bookissuancedate = DateTime.Parse(dt.Rows[i][2].ToString());
                obj.Bookduedate = DateTime.Parse(dt.Rows[i][3].ToString());

                lst.Add(obj);                
            }

            con.Close();

            return lst;
        }

        public List<IssueModel> ViewBookIssuanceToAdmin()
        {
            List<IssueModel> lst = new List<IssueModel>();

            con.Open();

            string que = "Select * from Issuance_book";

            SqlCommand cmd = new SqlCommand(que, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IssueModel bm = new IssueModel();

                bm.BookIssuanceid = int.Parse(dt.Rows[i][0].ToString());
                bm.BookIssuancedate = DateTime.Parse(dt.Rows[i][1].ToString());
                bm.Bookid = int.Parse(dt.Rows[i][2].ToString());
                bm.Memberid = int.Parse(dt.Rows[i][3].ToString());
                bm.Bookduedate = DateTime.Parse(dt.Rows[i][1].ToString());

                lst.Add(bm);
            }

            con.Close();

            return lst;
        }
    }
}