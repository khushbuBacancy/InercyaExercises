using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogExercise.Models
{
    public class Catalog
    {
        public List<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
    }
}
