using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_for_Information_Managment
{
    class DB
    {
        string connectionString = "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=postgres;" +
            "Database=IMBD;";
        
        public void ConnectionDB()
        {
            using(var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Succesful connection to BD");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



    }
}
