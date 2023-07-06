﻿using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        // GET: Category

        [HttpGet]
        public ActionResult Index()
        {
          //  var categories = categoryService.GetCategories();
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            model.Categories = categoryService.GetCategories();
            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;
                model.Categories= model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView("CategoryTable",model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModel model = new NewCategoryViewModel();
            return PartialView(model);
            //return View();
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            //categoryService.SaveCategory(category);
            //return View();
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;
            newCategory.ImageURL = model.ImageURL;
            newCategory.isFeatured = model.isFeatured;
            categoryService.SaveCategory(newCategory);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();

            var category = categoryService.GetCategory(ID);
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            model.ImageURL = category.ImageURL;
            model.isFeatured = category.isFeatured;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = categoryService.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.Description = model.Description;
            existingCategory.ImageURL = model.ImageURL;
            existingCategory.isFeatured = model.isFeatured;
            categoryService.UpdateCategory(existingCategory);
            return RedirectToAction("CategoryTable");
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    var category = categoryService.GetCategory(ID);
        //    return View(category);
        //}
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }

    }
}