using CrudApplication.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace CrudApplication.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentCrud(IConfiguration configuration) 
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Student> GetAllStudent()
        {
            List<Student> studlist = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student s = new Student();
                   s.Id = Convert.ToInt32(dr["id"]);
                   s.Name = dr["Name"].ToString();
                    s.Email = dr["Email"].ToString();
                    s.Phone = dr["Phone"].ToString();
                   s.City = dr["City"].ToString();
                   s.Marks = Convert.ToDouble(dr["Marks"]);
                  
                    studlist.Add(s);
                }
            }
            con.Close();
            return studlist;
        }
        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    s.Id = Convert.ToInt32(dr["id"]);
                    s.Name = dr["Name"].ToString();
                    s.Email = dr["Email"].ToString();
                    s.Phone = dr["Phone"].ToString();
                    s.City = dr["City"].ToString();
                    s.Marks = Convert.ToDouble(dr["Marks"]);

                    
                }
            }
            con.Close();
            return s;
        }
        public int AddStudent(Student s)
        {
            int result = 0;
           string qry = "insert into Student values(@Name,@Email,@Phone,@City,@Marks)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Email",s.Email);
            cmd.Parameters.AddWithValue("@Phone",s.Phone);
            cmd.Parameters.AddWithValue("@City",s.City );
            cmd.Parameters.AddWithValue("@Marks",s.Marks);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student s)
        {
            int result = 0;

            string qry = "update Student set Name=@name,Email=@email,Phone=@Phone,City=@city,Marks=@marks where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",s.Id);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Email", s.Email);
            cmd.Parameters.AddWithValue("@Phone", s.Phone);
            cmd.Parameters.AddWithValue("@City", s.City);
            cmd.Parameters.AddWithValue("@Marks", s.Marks);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
    }
}
