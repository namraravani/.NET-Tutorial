using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SQLConnectionADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            string cs = "Data Source=EV-LAP-00122;Initial Catalog=sqlPractice;User ID=sa;Password=Welcome@123;Encrypt=False;";

            try
            {
                SqlConnection conn = new SqlConnection(cs);
                // ctrl-d
                {
                    string name=  Console.ReadLine();


                    string query = "SearchStudent";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlParameter param1 = new SqlParameter
                        {
                            ParameterName = "@student",
                            SqlDbType = SqlDbType.VarChar,
                            Value = name,
                            Direction = ParameterDirection.Input,

                        };
                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(param1);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read()) {
                            Console.WriteLine("Name :-"+ reader[0]);
                        }
                        conn.Close();




                    }
                }
            }
            catch (Exception ex)
            {
                // Print the error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
