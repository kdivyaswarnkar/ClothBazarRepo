using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Product :BaseEntity
    {
        public decimal Price { get; set; }

        //product class belongs to one category
        //creating object as category type 

        //public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string ImageURL { get; set; }


    }
}
