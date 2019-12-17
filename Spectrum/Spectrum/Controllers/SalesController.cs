using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spectrum.Model.Model;
using Spectrum.Bll.Bll;
using Spectrum.Models;
using AutoMapper;

namespace Spectrum.Controllers
{
    public class SalesController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();

        [HttpGet]
        public ActionResult AddSales()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();



            salesViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.Category = salesViewModel.CategorySelectListItems;
            ViewBag.SalesCode = 2019;
            ViewBag.emptyData = 0;
            return View(salesViewModel);
        }

        [HttpPost]
        public ActionResult AddSales(SalesViewModel salesViewModel)
        {
            salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.Customer = salesViewModel.CustomerSelectListItems;



            salesViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();


            var message = "";

            Sales sales = Mapper.Map<Sales>(salesViewModel);
            if (_salesManager.AddSales(sales))
            {
                ResetLoyaltyPoint(sales.CustomerId, sales.Id);
                message = "Sales Data Save Successfully!!";

            }
            else
            {
                message = "Not Save";
            }

            ViewBag.Category = salesViewModel.CategorySelectListItems;
            ViewBag.SalesCode = 2019;
            ViewBag.Message = message;

            return View(salesViewModel);
        }

        public void ResetLoyaltyPoint(int id, int SalesId)
        {
            var salesdetailsList = _salesManager.GetAllSalesDetails().Where(c => c.SalesId == SalesId).ToList();
            var grandtotal = ((from s in salesdetailsList select s.TotalMrp).Sum()) / 1000;

            var customer = _customerManager.GetById(id);
            var loyaltyPoint = customer.LoyaltyPoint / 10;

            customer.LoyaltyPoint += grandtotal - loyaltyPoint;
            _customerManager.UpdateLoyaltyPoint(customer);
        }
        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = from p in productList select (new { p.Id, p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoyaltyPointByCustomerId(int customerId)
        {
            var customerList = _customerManager.GetAll().Where(c => c.Id == customerId).ToList();
            var loyaltyPoint = from c in customerList select (new { c.LoyaltyPoint, c.Name });
            return Json(loyaltyPoint, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductAvailableQuantityAndMrp(int productId)
        {

            var productList = _purchaseManager.GetAll().Where(c => c.ProductId == productId).ToList();
            var availavleQty = from p in productList select (new { p.Quantity, p.MRP });
            return Json(availavleQty, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductName(int productId)
        {
            var productList = _productManager.GetAll().Where(c => c.Id == productId).ToList();
            var productName = from p in productList select (p.Name);
            return Json(productName, JsonRequestBehavior.AllowGet);
        }
    }
}