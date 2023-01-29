using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShadPractice.Core.Interfaces;
using ShadPractice.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShadPractice.Core.Models;
using System.Net;

namespace ShadPractice.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CustomersController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customersTypes = _repositoryWrapper.CustomerTypes.FindAll().ToList();
            ViewBag.CustomerTypesList = BindCustomerTypes(customersTypes).CustomerTypesSelectList;
            return View();
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _repositoryWrapper.Customer.FindAll().ToList();
            return Json(customers);
        }

        //this method fill dropdown customertypes
        private CustomerTypeModels BindCustomerTypes(List<CustomerTypes> customersTypes)
        {
            var model = new CustomerTypeModels();

            model.CustomerTypesSelectList = new List<SelectListItem>();

            foreach (var customerType in customersTypes)
            {
                model.CustomerTypesSelectList.Add(new SelectListItem { Text = customerType.Description, Value = customerType.Id.ToString() });
            }

            return model;
        }

        [HttpPost]
        public ActionResult Create(Customer model)
        {
            try
            {
                _repositoryWrapper.Customer.Create(model);
                _repositoryWrapper.Save();
                return Ok(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Json("");
            }
        }

        [HttpGet]
        public ActionResult EditDetail(int id)
        {
            try
            {
                var customer = _repositoryWrapper.Customer.FindByCondition(e => e.Id == id).FirstOrDefault();
                return Json(customer);
            }
            catch
            {
                return Json("");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Customer model)
        {
            try
            {
                var customer = _repositoryWrapper.Customer.FindByCondition(c => c.Id == id).FirstOrDefault();
                customer.CustName = model.CustName;
                customer.Adress = model.Adress;
                customer.CustomerTypeId = model.CustomerTypeId;

                _repositoryWrapper.Customer.Update(customer);
                _repositoryWrapper.Save();
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return Json("");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var customer = _repositoryWrapper.Customer.FindByCondition(c => c.Id == id).FirstOrDefault();
                _repositoryWrapper.Customer.Delete(customer);
                _repositoryWrapper.Save();
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                return Json("");
            }
        }
    }
}
