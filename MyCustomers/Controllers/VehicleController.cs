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

        [HttpGet]

        public async Task<IActionResult> Reports()
        {
            var viewModel = new VehiclesListViewModel()
            {
                vehicles = await _dbContext.Vehicles.Include(v => v.VehicleMake).ToListAsync()
            };

            return View("Reports", viewModel);
        }


        // Action method to display the form for editing a vehicle (HTTP GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the vehicle with the specified ID from the database
            var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.VehicleID == id);
            var makes = _dbContext.VehicleMakes.ToList();
            if (vehicle == null)
            {
                // If customer not found, return a 404 Not Found response
                return NotFound();

            }
            var viewModel = new VehicleEditViewModel
            {
                Vehicle = vehicle,

                VehicleMakes = makes
            };
            // Display the edit view for the vehicle
            return View(viewModel);
        }

        // Action method to handle form submission for editing a vehicle (HTTP POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VehicleEditViewModel viewModel)
        {
            var vehicle = viewModel.Vehicle;
            // Check if the submitted data is valid
            if (vehicle is not null)
            {
                // Update the vehicle in the database
                _dbContext.Vehicles.Update(vehicle);
                _dbContext.SaveChanges();
                // Redirect to the details page of the edited customer
                return RedirectToAction("Details", "Customer", new { id = vehicle.CustomerID });
            }
            // If data is not valid, return the same view with validation errors
            return View(vehicle);
        }

        // Action to delete a vehicle
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int vehicleId)
        {
            var vehicleToDelete = await _dbContext.Vehicles.FindAsync(vehicleId);
            if (vehicleToDelete == null)
            {
                // Handle case where vehicle is not found
                return NotFound();
            }

            _dbContext.Vehicles.Remove(vehicleToDelete);
            await _dbContext.SaveChangesAsync();

            // Redirect to the updated list of vehicles
            return RedirectToAction(nameof(DetailsAsync));
        }
    }
}


