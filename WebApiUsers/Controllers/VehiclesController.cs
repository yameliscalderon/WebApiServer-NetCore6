using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUsers.Interface;
using WebApiUsers.Models;

namespace WebApiUsers.Controllers
{
    [Authorize]
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicles _IVehicle;

        public VehiclesController(IVehicles IVehicle)
        {
            _IVehicle = IVehicle;
        }

        // GET: api/vehicles> Todos los vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicles>>> Get()
        {
            return await Task.FromResult(_IVehicle.GetVehiclesDetails());
        }

        // GET api/vehicles/id Obterner un vehiculo por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> Get(int id)
        {
            var vehicle = await Task.FromResult(_IVehicle.GetVehicleDetails(id));
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // POST api/vehicle Agregar un vehiculo
        [HttpPost]
        public async Task<ActionResult<Vehicles>> Post(Vehicles vehiculo)
        {
            _IVehicle.AddVehicle(vehiculo);
            return await Task.FromResult(vehiculo);
        }

        // PUT api/vehicle/id Modificar un vehiculo por id
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicles>> Put(int id, Vehicles vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }
            try
            {
                _IVehicle.UpdateVehicle(vehiculo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(vehiculo);
        }

        // DELETE api/vehicle/id Eliminar un vehiculo por id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicles>> Delete(int id)
        {
            var vehiculo = _IVehicle.DeleteVehicle(id);
            return await Task.FromResult(vehiculo);
        }

        //Chequear si el id del vehiculo existe.
        private bool VehicleExists(int id)
        {
            return _IVehicle.CheckVehicle(id);
        }


    }//fin clase
} // fin namespace
