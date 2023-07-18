using CatalogExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogExercise
{
    public static class ReadFileData
    {
        public static List<Category> ReadCategoriesFromCsv(string filePath)
        {
            var categories = new List<Category>();

            StreamReader reader = new StreamReader(filePath);
            var fullPath = new FileInfo(filePath).FullName;
            try
            {
                if (File.Exists(fullPath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {

                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        if (values.Length > 0)
                        {
                            var category = new Category
                            {
                                Id = int.Parse(values[0]),
                                Name = values[1],
                                Description = values[2]
                            };

                            categories.Add(category);
                        }
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
            return categories;
        }
        public static List<Product> ReadProductsFromCsv(string filePath)
        {
            var products = new List<Product>();

            StreamReader reader = new StreamReader(filePath);
            var fullPath = new FileInfo(filePath).FullName;

            try
            {
                if (File.Exists(fullPath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        if (values.Length > 0)
                        {
                            string price = values[3].Contains(",") ? values[3].Replace(",", "") : values[3];

                            var product = new Product
                            {
                                Id = int.Parse(values[0]),
                                CategoryId = int.Parse(values[1]),
                                Name = values[2],
                                Price = Convert.ToDecimal(price)

                            };
                            products.Add(product);
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException("Products.csv file does not exist.", fullPath);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }
    }
}
