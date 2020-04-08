using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult TreeListPartial(string ddeValue) {
            ViewData["ddeValue"] = ddeValue;
            return PartialView("_TreeListPartial", LicensesDataProvider.GetLicenses());
        }
        public ActionResult GridViewPartial() {
            return PartialView("_GridViewPartial", CustomersDataProvider.GetCustomers());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewAddNewPartial(Customer customer) {
            CustomersDataProvider.InsertCustomer(customer);
            return GridViewPartial();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUpdatePartial(Customer customer) {
            CustomersDataProvider.UpdateCustomer(customer);
            return GridViewPartial();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDeletePartial(int ID = -1) {
            if (ID != -1)
                CustomersDataProvider.DeleteCustomer(new Customer { CustomerID = ID });
            return GridViewPartial();
        }
    }
}