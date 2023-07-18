using CatalogExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogExercise
{
    public class CatalogService
    {
        /// <summary>
        /// fetch products based on category for json format.
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public static List<ProductCategory> GroupProductsByCategory(List<Category> categories, List<Product> products)
        {
            var productCategories = new List<ProductCategory>();

            foreach (var category in categories)
            {
                var productCategory = new ProductCategory
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Products = products
                        .Where(p => p.CategoryId == category.Id)
                        .Select(p => new Product
                        {
                            Id = p.Id,
                            CategoryId = p.CategoryId,
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                };

                productCategories.Add(productCategory);
            }

            return productCategories;
        }

        /// <summary>
        /// Generate catelog data for XML format
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public static Catalog GenerateCatalog(List<ProductCategory> categories, List<Product> products)
        {
            Catalog catalog = new Catalog();

            foreach (var category in categories)
            {
                var categoryProducts = products.Where(p => p.CategoryId == category.Id).ToList();
                category.Products.AddRange(categoryProducts);

                catalog.Categories.Add(category);
            }

            return catalog;
        }

        public static XDocument GenerateCatalogXml(List<ProductCategory> productCategories)
        {
            XDocument catalogXml = new XDocument(new XElement("ArrayOfCategory"));

            foreach (var category in productCategories)
            {
                XElement categoryElement = new XElement("Category",
                    new XElement("Description", category.Description),
                    new XElement("Id", category.Id),
                    new XElement("Name", category.Name));
                new XElement("Products");

                foreach (var product in category.Products)
                {
                    if (product.CategoryId == category.Id)
                    {
                        XElement productElement = new XElement("Product",
                            new XElement("CategoryId", category.Id),
                            new XElement("Id", product.Id),
                            new XElement("Name", product.Name),
                            new XElement("Price", Convert.ToDecimal(product.Price.ToString().Contains(",") ? product.Price.ToString().Replace(",", "") : product.Price)));

                        categoryElement.Add(productElement);
                    }
                }

                catalogXml.Root?.Add(categoryElement);
            }

            return catalogXml;
        }
    }
}
