
namespace MyCustomers.Models
{
    public class CustomerVehicleViewModel

    {
        public int CustomerID { get; set; }
        public Vehicle CustomerVehicle { get; set; }

        public Customer Customer { get; set; }
        public List<VehicleMake> VehicleMakes  { get; set; }

        

    }
}
