using AspDotNetCore_Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspDotNetCore_Pagination.Controllers
{
    public class HomeController : Controller
    {
        private DBCtx Context { get; }
        public HomeController(DBCtx _context)
        {
                this.Context = _context;
        }

        public IActionResult Index()
        {
            return View(this.GetCustomers(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(this.GetCustomers(currentPageIndex));
        }

        private CustomerModel GetCustomers(int currentPage)
        {
            int maxRows = 10;
            CustomerModel customerModel = new CustomerModel();

            customerModel.Customers = (from customer in this.Context.Customers
                                       select customer)
                 .OrderBy(customer => customer.CustomerID)
                 .Skip((currentPage - 1) * maxRows)
                 .Take(maxRows).ToList();

            double pageCount = (double)((decimal)this.Context.Customers.Count() / Convert.ToDecimal(maxRows));

            customerModel.PageCount = (int)Math.Ceiling(pageCount);

            customerModel.CurrentPageIndex = currentPage;

            return customerModel;
        }
    }
}