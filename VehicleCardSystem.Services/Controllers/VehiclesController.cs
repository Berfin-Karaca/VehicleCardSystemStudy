using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCardSystem.Core.Models;
using VehicleCardSystem.Data;

namespace VehicleCardSystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleCardSystemDbContext _context;

        public VehiclesController(VehicleCardSystemDbContext context)
        {
            _context = context;
        }

        //Listeleme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.AsNoTracking().Include(v => v.VehicleTypes).ToListAsync();
        }

        //İd ye göre listeleme
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(Guid id)
        {
            var vehicle = await _context.Vehicles.Include(v => v.VehicleTypes).FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        //Ekleme
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId }, vehicle);
        }

        //Güncelleme
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(Guid id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return BadRequest("ID mismatch");
            }

            //_context.Entry(vehicle).State = EntityState.Modified;
            var existingVehicle = await _context.Vehicles.FindAsync(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            // Sadece gerekli alanlar güncelleniyor
            existingVehicle.Plate = vehicle.Plate;
            existingVehicle.ModelYear = vehicle.ModelYear;
            existingVehicle.Color = vehicle.Color;
            existingVehicle.VehicletypeId = vehicle.VehicletypeId;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }
        //Silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(Guid id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}
