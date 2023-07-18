using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersExercise
{
    public class CustomerService
    {
        public static DataTable CustomerDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();

            StreamReader reader = new StreamReader(filePath);
            var fullPath = new FileInfo(filePath).FullName;
            try
            {
                if (File.Exists(fullPath))
                {
                    // Create a DataTable to hold the data from the CSV file
                    dataTable.Columns.Add("Id", typeof(string));
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Address", typeof(string));
                    dataTable.Columns.Add("City", typeof(string));
                    dataTable.Columns.Add("Country", typeof(string));
                    dataTable.Columns.Add("PostalCode", typeof(string));
                    dataTable.Columns.Add("Phone", typeof(string));

                    reader.ReadLine();

                     // Read the remaining lines and add them to the DataTable
                     while (!reader.EndOfStream)
                     {
                         string line = reader.ReadLine();
                         string[] values = line.Split(';');

                         string id = values[0];
                         string name = values[1];
                         string address = values[2];
                         string city = values[3];
                         string country = values[4];
                         string postalCode = values[5];
                         string phone = values[6];

                         dataTable.Rows.Add(id, name, address, city, country, postalCode, phone);
                     }
                }
                else
                {
                    throw new FileNotFoundException("Category.csv file does not exist.", fullPath);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataTable;
        }
    }
}
