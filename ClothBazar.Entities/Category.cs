using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Category :BaseEntity
    {
        public string ImageURL { get; set; }
        //one category multiple products
        public List<Product> Products { get; set; }
        public bool isFeatured { get; set; }

    }
}
