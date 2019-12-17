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
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();

        [HttpGet]
        public ActionResult Add()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);

        }


        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Add(supplier))
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
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }


        [HttpGet]
        public ActionResult Search()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Search(SupplierViewModel supplierViewModel)
        {
            var suppliers = _supplierManager.GetAll();
            if (supplierViewModel.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.Contains(supplierViewModel.Code)).ToList();
            }
            if (supplierViewModel.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.Contains(supplierViewModel.Name)).ToList();
            }
            if (supplierViewModel.Contact != null)
            {
                suppliers = suppliers.Where(c => c.Contact.Contains(supplierViewModel.Contact)).ToList();
            }
            if (supplierViewModel.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email.Contains(supplierViewModel.Email)).ToList();
            }

            supplierViewModel.Suppliers = suppliers;

            return View(supplierViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.getById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);

        }
        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
                if (_supplierManager.Update(supplier))
                {
                    message = "Updated!";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var supplier = _supplierManager.getById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);

        }
        [HttpPost]
        public ActionResult Delete(SupplierViewModel supplierViewModel)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
                if (_supplierManager.Delete(supplier.Id))
                {
                    message = "Deleted!!";
                }
                else
                {
                    message = "Not Deleted";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }
    }
}

