using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asztali_projekt_2026.Model
{
    internal class AdatbazisCsatlakozas
    {

        private static string connectionString;
        private static string table;
        private static string query_parameters;

        public static void DbConnectionCheck(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SIkertelen kapcs");
                Console.WriteLine(ex);

            }

        }
    }
}
