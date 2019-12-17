﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spectrum.Model.Model;
using Spectrum.Bll.Bll;
using Spectrum.Models;
using AutoMapper;
using Spectrum.DatabaseContext.DatabaseContext;


namespace Spectrum.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProjectDbContext _dbContext = new ProjectDbContext();


        // GET: Product
        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();

            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();


            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Add(product))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "Create Failed";
            }

            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(productViewModel);
        }
        public ActionResult ViewProduct(Product product)
        {
            ProductManager _productManager = new ProductManager();
            ModelState.Clear();
            return View(_productManager.GetAll());
        }




        [HttpGet]
        public ActionResult Update(int id)
        {

            var product = _productManager.getById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);
            productViewModel.Products = _productManager.GetAll();

            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();

            return View(productViewModel);


        }
        // POST: Student/Edit/5	
        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Update(product))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Update Failed";
            }

            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();
            return View(productViewModel);
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            var product = from s in _dbContext.Product
                          select s;
            if (!String.IsNullOrEmpty(searching))
            {
                product = product.Where(s => s.Code.Contains(searching) || s.Name.Contains(searching));
            }

            return View(product.ToList());
        }
        public ActionResult Delete(int id)
        {
            try
            {
                ProductManager productManager = new ProductManager();
                if (productManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("ViewProduct");
            }
            catch
            {
                return View();
            }

        }
    }
}