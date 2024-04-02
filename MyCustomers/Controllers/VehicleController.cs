using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCustomers.Models;

namespace MyCustomers.Controllers
{
    public class VehicleController : Controller
    {
        private readonly MyCustomersDbContext _dbContext;

        public VehicleController(MyCustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Action to display the list of vehicles
        [HttpGet]

        public async Task<IActionResult> DetailsAsync()
        {
            var viewModel = new VehiclesListViewModel()
            {
                vehicles = await _dbContext.Vehicles.Include(v => v.VehicleMake).ToListAsync()
            };

            return View("Details", viewModel);
        }


        // Action method to display the form for editing a vehicle (HTTP GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the vehicle with the specified ID from the database
            var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.VehicleID == id);
            if (vehicle == null)
            {
                // If customer not found, return a 404 Not Found response
                return NotFound();
            }
            // Display the edit view for the vehicle
            return View(vehicle);
        }

        // Action method to handle form submission for editing a vehicle (HTTP POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vehicle vehicle)
        {
            // Check if the submitted data is valid
            if (ModelState.IsValid)
            {
                // Update the vehicle in the database
                _dbContext.Update(vehicle);
                _dbContext.SaveChanges();
                // Redirect to the details page of the edited customer
                return RedirectToAction("Details", new { id = vehicle.VehicleID });
            }
            // If data is not valid, return the same view with validation errors
            return View(vehicle);
        }

    }
}