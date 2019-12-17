using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Spectrum.Models;
using Spectrum.Model.Model;
using Spectrum.Bll.Bll;

namespace Spectrum.Controllers
{
    public class PurchaseController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();

        [HttpGet]
        public ActionResult AddPurchase()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();


            purchaseViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.Category = purchaseViewModel.CategorySelectListItems;



            //purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem
            //                                                                        {
            //                                                                            Value = c.Id.ToString(),
            //                                                                            Text = c.Name
            //                                                                        }).ToList();

            //if(purchaseViewModel.ProductSelectListItems)


            return View(purchaseViewModel);
        }

        public JsonResult GetSupplierNameBySupplierId(int supplierId)
        {
            var supplierList = _supplierManager.GetAll().Where(c => c.Id == supplierId).ToList();
            var supplier = from s in supplierList select (s.Name);
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = from p in productList select (new { p.Id, p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductCodeByProductId(int productId)
        {
            var productList = _productManager.GetAll().Where(c => c.Id == productId).ToList();
            var productCode = from p in productList select (new { p.Code, p.Name });
            return Json(productCode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPreviousProductPurchaseInfoByCode(int productId)
        {
            var purchaseProductCodeList = _purchaseManager.GetAll().Where(c => c.ProductId == productId).ToList();
            var purchaseProductCode = from p in purchaseProductCodeList select (new { p.UnitPrice, p.MRP });
            return Json(purchaseProductCode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurchaseAvailableQuantity(int productId)
        {
            var purchaseProductCodeList = _purchaseManager.GetAll().Where(c => c.ProductId == productId).ToList();
            var availableQuantity = (from p in purchaseProductCodeList select p.Quantity).Sum();
            return Json(availableQuantity, JsonRequestBehavior.AllowGet);
            //return availableQuantity;
        }

        [HttpPost]
        public ActionResult AddPurchase(PurchaseViewModel purchaseViewModel)
        {
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();


            purchaseViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.Category = purchaseViewModel.CategorySelectListItems;

            //purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem
            //                                                                        {
            //                                                                            Value = c.Id.ToString(),
            //                                                                            Text = c.Name
            //                                                                        }).ToList();




            string message = "";
            Purchase purchase = Mapper.Map<Purchase>(purchaseViewModel);
            if (_purchaseManager.Add(purchase))
            {
                message = "Data Save Successfully";
            }
            else
            {
                message = "not save";
            }

            ViewBag.Message = message;

            purchaseViewModel.Purchases = _purchaseManager.GetPurchaseReportAll();

            return View(purchaseViewModel);
        }

        [HttpGet]
        public ActionResult PurchaseInfo()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchases = _purchaseManager.GetPurchaseReportAll();
            return View(purchaseViewModel);
        }
        [HttpPost]
        public ActionResult PurchaseInfo(PurchaseViewModel purchaseViewModel)
        {
            //PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchases = _purchaseManager.GetPurchaseReportAll();
            return View(purchaseViewModel);
        }

        [HttpGet]
        public ActionResult PurchaseDetails(int Id)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.PurchaseDetailses = _purchaseManager.GetAll().Where(c => c.PurchaseId == Id).ToList();
            return View(purchaseViewModel);
        }
        [HttpPost]
        public ActionResult PurchaseDetails(PurchaseViewModel purchaseViewModel)
        {
            purchaseViewModel.PurchaseDetailses = _purchaseManager.GetAll();
            return View(purchaseViewModel);
        }
        ////public ActionResult GetPurchaseDetailsByPurchaseId(int purchaseId)
        ////{
        ////    PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
        ////    purchaseViewModel.PurchaseDetailses = _purchaseManager.GetAll().Where(c => c.PurchaseId == purchaseId).ToList();
        ////    return PartialView("Purchase/_purchaseReport", purchaseViewModel);
        ////}
    }
}