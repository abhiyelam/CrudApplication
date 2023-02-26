using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace CrudApplication.Models
{
    public class DepartmentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public DepartmentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }




        public List<Department> DeptList()
        {
            List<Department> deptlist = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.DeptId = Convert.ToInt32(dr["DeptId"]);
                    dept.DeptName = dr["DeptName"].ToString();
                    deptlist.Add(dept);
                }
            }
            con.Close();
            return deptlist;
        }
        public Department GetDeptById(int id)
        {
            Department dept = new Department();
            string qry = "select * from Department where deptid=@deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptid", id);
                    con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.DeptId = Convert.ToInt32(dr["DeptId"]);
                    dept.DeptName = dr["DeptName"].ToString();
                }
            }
            con.Close();
            return dept;
        }
        public int AddDept(Department dept)
        {
            int result = 0;
            string qry = "insert into Department values(@DeptName)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateDept(Department dept)
        {
            int result = 0;
            string qry = "update Department set deptname=@deptname where deptid=@deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptid", dept.DeptId);
            cmd.Parameters.AddWithValue("@deptname", dept.DeptName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDept(int id)
        {
            int result = 0;
            string qry = "delete from  Department where deptid=@deptid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@deptid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        
    }
}
