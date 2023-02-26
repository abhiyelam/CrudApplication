using System.Data.SqlClient;

namespace CrudApplication.Models
{
    public class EmpCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private IConfiguration configuration;
        public EmpCrud(IConfiguration configuration) 
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Employee1> GetList()
        {
             {
                List<Employee1> emplist = new List<Employee1>();
                string qry = "select * from tblEmp where isactive=1";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee1 emp = new Employee1();
                        emp.Id = Convert.ToInt32(dr["Id"]);
                        emp.Name = dr["Name"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.Createpassword = dr["Password"].ToString();
                        emp.Mobile = dr["Mobile"].ToString();
                        emp.Age = Convert.ToInt32(dr["Age"]);
                        emplist.Add(emp);
                    }
                }
                con.Close();
                return emplist;
            }
        }
        public Employee1 GetEmployeeById(int id)
        {
            {
                Employee1 emp = new Employee1();
                string qry = "select * from tblEmp where Id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp.Id = Convert.ToInt32(dr["Id"]);
                        emp.Name = dr["Name"].ToString();
                        emp.Email = dr["Email"].ToString();
                        emp.Createpassword = dr["Password"].ToString();
                        emp.Mobile = dr["Mobile"].ToString();
                        emp.Age = Convert.ToInt32(dr["Age"]);
                    }
                }
                con.Close();
                return emp;
            }
        }

        public int AddEmp(Employee1 emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "insert into tblEmp values(@name,@email,@password,@mobile,@age,@isactive)";
            cmd=new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@password", emp.Createpassword);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee1 emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "update tblEmp set Name=@name,Email=@email,Password=@password,Mobile=@mobile,Age=@age,isactive=@isactive where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@password", emp.Createpassword);
            cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "update tblEmp set isactive=0 where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
