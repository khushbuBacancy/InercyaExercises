using CsvHelper;
using CustomersExercise;
//using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = CustomerService.CustomerDataTable("./Files/Customers.csv");

            // Set connection string and table name
            string connectionString = "Server=.;Database=ExcerciseDemo_db;Integrated Security=True";
            string tableName = "Customers";

            // Create a SqlConnection and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlBulkCopy instance with the connection and table name
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = tableName;

                    try
                    {
                        // Write the data from the DataTable to the table
                        bulkCopy.WriteToServer(dataTable);
                        Console.WriteLine("Data imported successfully in Customers table.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}