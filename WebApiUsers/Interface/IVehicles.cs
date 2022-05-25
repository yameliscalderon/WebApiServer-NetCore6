using WebApiUsers.Models;
namespace WebApiUsers.Interface
{
    public interface IVehicles
    {
        public List<Vehicles> GetVehiclesDetails();

        public Vehicles GetVehicleDetails(int id);

        public void AddVehicle(Vehicles vehiculo);

        public void UpdateVehicle(Vehicles vehiculo);

        public Vehicles DeleteVehicle(int id);

        public bool CheckVehicle(int id);
    }
}
