using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFS.BAL.interfaces;


namespace KFS.BAL.Repo
{
    public class InternRepo : IInterns
    {
        string ConnectionString = null;
        SqlConnection connection = null;
        SqlCommand command = null;

        public InternRepo()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["praticedbEntities"].ConnectionString;
            connection = new SqlConnection(ConnectionString);

        }
        public int AddInter(InternInfo model)
        {
            int i = 0;
            string sqlQuery = "insert into InternInfo(First_Name,Last_Name,College) values(@First_Name,@Last_Name,@College)";
            connection.Open();
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@First_Name", model.First_Name);
            command.Parameters.AddWithValue("@Last_Name", model.Last_Name);
            command.Parameters.AddWithValue("@College", model.College);

            try
            {
               i=command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public int DeleteInter(int iid)
        {
            int i = 0;
            string sqlQuery = "delete InternInfo where Id=@id";
            connection.Open();
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@id", iid);
            

            try
            {
                i = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public List<InternInfo> GetAllIntern()
        {
            List<InternInfo> interdata = new List<InternInfo>();
            connection.Open();
            string sqlQuery = "select *from InternInfo";
            command = new SqlCommand(sqlQuery, connection);
            
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        InternInfo intern = new InternInfo();
                        intern.Id = Convert.ToInt32(dataReader["Id"]);
                        intern.First_Name = dataReader["First_Name"].ToString();
                        intern.Last_Name = dataReader["Last_Name"].ToString();
                        intern.College = dataReader["College"].ToString();

                        interdata.Add(intern);

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return interdata;
        }

        public InternInfo GetPerticulartInter(int iid)
        {
            InternInfo internInfo = new InternInfo();
            connection.Open();
            string query = String.Format("select *from InternInfo where Id={0}", iid);
            command = new SqlCommand(query, connection);

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        internInfo.Id = Convert.ToInt32(dataReader["Id"]);
                        internInfo.First_Name = dataReader["First_Name"].ToString();
                        internInfo.Last_Name = dataReader["Last_Name"].ToString();
                        internInfo.College = dataReader["College"].ToString();                   
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return internInfo;
        }

        public int UpdateInter(InternInfo model)
        {
            int i = 0;
            string sqlQuery = "Update InternInfo set First_Name=@First_Name,Last_Name=@Last_Name,College=@College where Id=@Id";
            connection.Open();
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@First_Name", model.First_Name);
            command.Parameters.AddWithValue("@Last_Name", model.Last_Name);
            command.Parameters.AddWithValue("@College", model.College);
            command.Parameters.AddWithValue("@Id", model.Id);
            try
            {
                i = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return i;
        }
    }
}
