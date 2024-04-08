using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCustomers.Models;

namespace MyCustomers.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyCustomersDbContext _dbContext;

        // Constructor to inject MyCustomersDbContext into the controller
        public CustomerController(MyCustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //NEW CUSTOMER CREATION---------------------------------------------------------------------- Action method to display the form for creating a new customer (HTTP GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action method to handle form submission for creating a new customer (HTTP POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            // Check if the submitted data is valid
            if (ModelState.IsValid)
            {
                // Add the new customer to the database
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                // Redirect to the details page of the newly added customer
                return RedirectToAction("Details", new { id = customer.Id });
            }
            // If data is not valid, return the same view with validation errors
            return View(customer);
        }

        //CUSTOMER DETAILS----------------------------------------------------------------------------- Action method to display details of a specific customer (HTTP GET)
        [HttpGet]

        public async Task<IActionResult> DetailsAsync(int id)
        {
            // Retrieve the customer with the specified ID from the database
            var customer = await _dbContext.Customers.Include(c => c.Vehicles).ThenInclude(v => v.VehicleMake).FirstOrDefaultAsync(c => c.Id == id);
            var vehicleMakes = await _dbContext.VehicleMakes.ToListAsync();
            if (customer == null)
            {
                // If customer not found, return a 404 Not Found response
                return NotFound();
            }
            var viewModel = new CustomerVehicleViewModel
            {
                Customer = customer,
                VehicleMakes = vehicleMakes
            };
            // Display the details view for the customer
            return View(viewModel);
        }



        //CUSTOMER EDIT------------------------------------------------------------------------------------ Action method to display the form for editing a customer (HTTP GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the customer with the specified ID from the database
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                // If customer not found, return a 404 Not Found response
                return NotFound();
            }
            // Display the edit view for the customer
            return View(customer);
        }

        // Action method to handle form submission for editing a customer (HTTP POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            // Check if the submitted data is valid
            if (ModelState.IsValid)
            {
                // Update the customer in the database
                _dbContext.Update(customer);
                _dbContext.SaveChanges();
                // Redirect to the details page of the edited customer
                return RedirectToAction("Details", new { id = customer.Id });
            }
            // If data is not valid, return the same view with validation errors
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(CustomerVehicleViewModel customerVehicleViewModel)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == customerVehicleViewModel.CustomerVehicle.CustomerID);
            await _dbContext.Vehicles.AddAsync(customerVehicleViewModel.CustomerVehicle);

            await _dbContext.SaveChangesAsync();

            var vehicleMakes = await _dbContext.VehicleMakes.ToListAsync();

            var viewModel = new CustomerVehicleViewModel

            {
                Customer = customer,
                VehicleMakes = vehicleMakes
            };

            return RedirectToAction("Details", new { id = customer.Id });

        }


    }
}
