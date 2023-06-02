// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;
using System.Xml.Linq;


String connectionString = "Data Source=LAPTOP-276J3PA6;Initial Catalog=WBA_DatabaseConcepts_1_yehia_ali;User ID=sa;Password=SHIMshim99@99";
using (SqlConnection connection = new SqlConnection(connectionString))
{
  //  string query = "SELECT Id, Name FROM WBA.Students";
    string Union_SQL_Injection = "SELECT * FROM WBA.Students WHERE name = '' UNION SELECT Id, Name FROM WBA.Articles--'";
    
    using (SqlCommand command = new SqlCommand(Union_SQL_Injection, connection))
    {
        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
               
            { 
                string Name = (string)reader["Name"];
                
                Console.WriteLine( Name);

            }
        }
    }

    using (SqlConnection connection2 = new SqlConnection(connectionString))
    {
        //  string query = "SELECT Id, Name FROM WBA.Students";
        string Inband_SQL_Injection = "SELECT * FROM WBA.Students WHERE id = 1 OR 1=1--";

        using (SqlCommand command = new SqlCommand(Inband_SQL_Injection, connection2))
        {
            connection2.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())

                {
                    string Name = (string)reader["Name"];

                    Console.WriteLine(Name);

                }
            }
        }



    }


}

