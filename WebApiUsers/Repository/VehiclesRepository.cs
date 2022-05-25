using Microsoft.EntityFrameworkCore;
using WebApiUsers.Context;
using WebApiUsers.Interface;
using WebApiUsers.Models;
namespace WebApiUsers.Repository
{
    public class VehiclesRepository : IVehicles
    {
        readonly DatabaseContext _dbContext = new();

        public VehiclesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Vehicles> GetVehiclesDetails()
        {
            try
            {
                return _dbContext.vehiculos.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Vehicles GetVehicleDetails(int id)
        {
            try
            {
                Vehicles? vehiculo = _dbContext.vehiculos.Find(id);
                if (vehiculo != null)
                {
                    return vehiculo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddVehicle(Vehicles vehiculo)
        {
            try
            {
                _dbContext.vehiculos.Add(vehiculo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateVehicle(Vehicles vehiculo)
        {
            try
            {
                _dbContext.Entry(vehiculo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Vehicles DeleteVehicle(int id)
        {
            try
            {
                Vehicles? employee = _dbContext.vehiculos.Find(id);

                if (employee != null)
                {
                    _dbContext.vehiculos.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckVehicle(int id)
        {
            return _dbContext.vehiculos.Any(e => e.Id == id);
        }
    }
}
