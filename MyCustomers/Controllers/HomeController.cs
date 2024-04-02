using Microsoft.AspNetCore.Mvc;
using MyCustomers.Models;
using System.Collections.Generic;
using MyCustomers; // Make sure to replace YourNamespace with the actual namespace of your models

namespace MyCustomers.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyCustomersDbContext _dbContext;

        // Constructor to inject MyCustomersDbContext into the controller
        public HomeController(MyCustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Action method to display the list of customers on the home page(HTTP GET)
        //public IActionResult Index()
        //{
        // Retrieve the list of all customers from the database
        //    List<Customer> customers = _dbContext.Customers.ToList();
        // Pass the list of customers to the view for display
        //    return View(customers);
        //}

        public IActionResult Index()
        {
            var viewModel = new CustomersVehiclesListViewModel();

            viewModel.customers = _dbContext.Customers.ToList();



            return View("Index", viewModel);
        }
    }
}