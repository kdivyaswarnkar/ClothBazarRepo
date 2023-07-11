﻿using ClothBazar.Database;
using ClothBazar.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClothBazar.Services
{
    public class ProductService
    {

        #region Singleton
        public static ProductService Instance
        {
            get
            {
                if (instance == null) instance = new ProductService();
                return instance;
            }
        }
        private static ProductService instance { get; set; }
        private ProductService()
        {
        }
        #endregion
        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(x => x.ID == ID).Include(x => x.Category).FirstOrDefault();
            }
        }
        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }
        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;// int.Parse(ConfigurationsService.Instance.GetConfig("ListingPageSize").Value);

            using (var context = new CBContext())
            {
                return context.Products.OrderBy(x=>x.ID).Skip((pageNo-1)* pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }


        }

        public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

    }
}
