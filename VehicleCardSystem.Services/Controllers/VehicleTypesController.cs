using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCardSystem.Core.Models;
using VehicleCardSystem.Data;

namespace VehicleCardSystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly VehicleCardSystemDbContext _context;
        public VehicleTypesController(VehicleCardSystemDbContext context)
        {
            _context = context;
        }

        //Listeleme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleTypes()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        //İd ye göre listeleme
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleTypeById(Guid id)
        {
            var vehicleType = await _context.VehicleTypes.FirstOrDefaultAsync(v => v.VehicletypeId == id);

            if (vehicleType == null)
            {
                return NotFound(); 
            }

            return vehicleType;
        }

        //Ekleme
        [HttpPost]
        public async Task<ActionResult<VehicleType>> PostVehicleType(VehicleType vehicleType)
        {
            _context.VehicleTypes.Add(vehicleType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehicleTypeById), new { id = vehicleType.VehicletypeId }, vehicleType);
        }

        //Güncelleme 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleType(Guid id, VehicleType vehicleType)
        {
            if (id != vehicleType.VehicletypeId)
            {
                return BadRequest("ID mismatch");
            }

            _context.Entry(vehicleType).State = EntityState.Modified; 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetVehicleTypeByIdExists(id))
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
        public async Task<IActionResult> DeleteVehicleType(Guid id)
        {
            var vehicleType = await _context.VehicleTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound(); 
            }

            _context.VehicleTypes.Remove(vehicleType);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        //Güncelleme metodunun yardımcı metodu
        private bool GetVehicleTypeByIdExists(Guid id)
        {
            return _context.VehicleTypes.Any(e => e.VehicletypeId == id);
        }
    }
}
