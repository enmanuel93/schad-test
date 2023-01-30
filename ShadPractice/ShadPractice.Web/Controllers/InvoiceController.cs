using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShadPractice.Core;
using ShadPractice.Core.Interfaces;
using ShadPractice.Core.Models;
using ShadPractice.Core.ViewModels;
using ShadPractice.Infrastructure.Dtos;
using System.Net;

namespace ShadPractice.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InvoiceController(IRepositoryWrapper repositoryWrapper, IWebHostEnvironment webHostEnvironment)
        {
            _repositoryWrapper = repositoryWrapper;
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _repositoryWrapper.Customer.FindAll().ToList();
            ViewBag.CustomersList = BindCustomer(customers).CustomersSelectList;
            return View();
        }

        [HttpGet]
        public ActionResult GetInvoices()
        {
            List<DetailsDtos> detailsDtos = new List<DetailsDtos>();
            var invoices = _repositoryWrapper.Invoice.FindAll().ToList();
            invoices.ForEach(x =>
            {
                string name = _repositoryWrapper.Customer.FindByCondition(c => c.Id == x.CustomerId).FirstOrDefault().CustName;
                detailsDtos.Add(new DetailsDtos
                {
                    Id = x.Id,
                    CustName = name
                });
            });

            return Json(detailsDtos);
        }

        //this method fill dropdown customertypes
        private CustomersViewModels BindCustomer(List<Customer> customers)
        {
            var model = new CustomersViewModels();

            model.CustomersSelectList = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                model.CustomersSelectList.Add(new SelectListItem { Text = customer.CustName, Value = customer.Id.ToString() });
            }

            return model;
        }

        [HttpPost]
        public ActionResult Create(InvoiceDetail model)
        {
            try
            {
                var totalItbis = model.Price * ITBIS.ITBIS_PRICE;
                var subTotal = model.Qty * model.Price;
                var total = totalItbis + subTotal;

                //create invoice
                _repositoryWrapper.Invoice.Create(new Invoice
                {
                    CustomerId = model.CustomerId,
                    TotalItbis = totalItbis,
                    SubTotal = subTotal,
                    Total = total
                });

                _repositoryWrapper.Save();

                //create invoice detail
                model.TotalItbis = totalItbis;
                model.SubTotal = subTotal;
                model.Total = total;
                model.InvoiceId = _repositoryWrapper.Invoice.FindAll().OrderByDescending(r => r.Id).FirstOrDefault().Id; 
                _repositoryWrapper.InvoiceDetail.Create(model);
                _repositoryWrapper.Save();
                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Print(int id)
        {
            string mimtype = "";
            int extension = 1;
            var invoiceDetail = _repositoryWrapper.InvoiceDetail.FindByCondition(i => i.InvoiceId == id).ToList();
            var total = invoiceDetail.Sum(x => x.Total);

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\RptInvoice.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("total", total.ToString());

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", invoiceDetail);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        #region useless methods
        //[HttpGet]
        //public ActionResult EditDetail(int id)
        //{
        //    try
        //    {
        //        var customer = _repositoryWrapper.Customer.FindByCondition(e => e.Id == id).FirstOrDefault();
        //        return Json(customer);
        //    }
        //    catch
        //    {
        //        return Json("");
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, Customer model)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

    }
}
