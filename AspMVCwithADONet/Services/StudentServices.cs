using AspMVCwithADONet.Models;
using System.Data;
using System.Data.SqlClient;

namespace AspMVCwithADONet.Services
{

 

    public class StudentServices :IStudentService
	{
		public string Constr {  get; set; }
		public IConfiguration _configuration;
		public SqlConnection con;

		public StudentServices(IConfiguration configuration) 
		{ 
			_configuration=configuration;
			Constr = _configuration.GetConnectionString("DBConnection");
		}

        public List<Students> GetStudentsRecord()
        {
            List<Students> studentsList = new List<Students>();

            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_GetStudentsRecords", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Students std = new Students();
                                std.StudentId = rdr["StudentId"] != DBNull.Value ? Convert.ToInt32(rdr["StudentId"]) : 0;
                                std.StudentName = rdr["StudentName"].ToString();
                                std.EmailAddress = rdr["EmailAddress"].ToString();

                                studentsList.Add(std);
                            }
                        }
                    }
                }

                return studentsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    public interface IStudentService
    {
        public List<Students> GetStudentsRecord();
    }

}
