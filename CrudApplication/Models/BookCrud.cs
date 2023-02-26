using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CrudApplication.Models;
namespace CrudApplication.Models
{
    public class BookCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public BookCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Book> GetAllBooks()
        {
            List<Book> blist = new List<Book>(); 
            string qry = "select * from tblbook";
            cmd=new SqlCommand(qry,con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows) 
            {
                while(dr.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["Name"].ToString();
                    book.Price = Convert.ToDouble(dr["price"]);
                    blist.Add(book);
                }
            }
            con.Close();
            return blist;
        }
        public Book GetBookById(int id) 
        {
            Book book = new Book();
            string qry = "select * from tblbook where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Price = Convert.ToDouble(dr["price"]);
                    
                }
            }
            con.Close();
            return book;
        }
        public int AddBook(Book book) 
        {
            int result = 0;
            string qry = "insert into tblbook values(@Name,@Price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            con.Open();
             result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateBook(Book book) 
        {
            int result = 0;
            string qry = "update tblbook set Name=@name,Price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", book.Id);
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
            
        }
        public int DeleteBook(int id) 
        {
            int result = 0;
            string qry = "delete from tblbook where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
