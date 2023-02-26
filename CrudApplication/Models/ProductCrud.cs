using System.Data.SqlClient;

namespace CrudApplication.Models
{
    public class ProductCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private IConfiguration configuration;
        public ProductCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Category> GetAllProduct()
        {
            List<Category> clist = new List<Category>();
            string qry = "select * from category";
            cmd = new SqlCommand(qry, con);
            // cmd.Parameters.AddWithValue("@id",Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category ct = new Category();
                    ct.CId = Convert.ToInt32(dr["CId"]);
                    ct.Name = dr["Name"].ToString();

                    clist.Add(ct);
                }
            }
            con.Close();
            return clist;
        }
        public Category GetCategoryById(int id)
        {
            Category ct = new Category();
            string qry = "select * from category where cid=@CId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@CId", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    ct.CId = Convert.ToInt32(dr["CId"]);
                    ct.Name = dr["Name"].ToString();


                }
            }
            con.Close();
            return ct;
        }


        public int AddCategory(Category ct)
        {
            int result = 0;
            string qry = "insert into category values(@Name)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", ct.Name);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCategory(Category ct)
        {
            int result = 0;
            string qry = "update category set Name=@name where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@CId", ct.CId);
            cmd.Parameters.AddWithValue("@Name", ct.Name);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            string qry = "delete from category where cid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@CId", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}

