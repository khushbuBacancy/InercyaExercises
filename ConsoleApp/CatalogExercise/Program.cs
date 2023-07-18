using CatalogExercise;
using CatalogExercise.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace CatalogGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var categories = ReadFileData.ReadCategoriesFromCsv("./Files/Categories.csv");
            var products = ReadFileData.ReadProductsFromCsv("./Files/Products.csv");

            var productList = CatalogService.GroupProductsByCategory(categories, products);

            // Generate and save Catalog.json
            string catalogJson = JsonConvert.SerializeObject(productList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Catalog.json", catalogJson);
            Console.WriteLine("Catalog.json generated successfully.");

            // Generate and save Catalog.xml
            Catalog catalog = CatalogService.GenerateCatalog(productList, products);

            XDocument catalogXml = CatalogService.GenerateCatalogXml(productList);
            catalogXml.Save("Catalog.xml");
            Console.WriteLine("Catalog.xml generated successfully.");
        }
    }
}
