using Microsoft.AspNetCore.Mvc;
using VehicleCardSystem.Core.Models;
using VehicleCardSystem.Services; 
using System; 
using System.Threading.Tasks; 
using System.Collections.Generic; 
namespace VehicleCardSystem.Web.Controllers
{
    public class VehicleTypesController : Controller
    {
        private readonly IVehicleTypeApiService _vehicleTypeApiService;

        public VehicleTypesController(IVehicleTypeApiService vehicleTypeApiService)
        {
            _vehicleTypeApiService = vehicleTypeApiService;
        }

        //list
        public async Task<IActionResult> Index()
        {
            
            var vehicleTypes = await _vehicleTypeApiService.GetVehicleTypesAsync();
            return View(vehicleTypes);
        }
        //detail
        public async Task<IActionResult> Details(Guid id)
        {
            var vehicleType = await _vehicleTypeApiService.GetVehicleTypeByIdAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        //create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("Brand,ModelName,CapacityKg,CapacityM3")] VehicleType vehicleType)
        {
            vehicleType.VehicletypeId = Guid.NewGuid();
            if (vehicleType.Vehicles != null)
            {
                vehicleType.Vehicles = null;
            }

            if (ModelState.IsValid)
            {
                var success = await _vehicleTypeApiService.AddVehicleTypeAsync(vehicleType);
                if (success)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                ModelState.AddModelError("", "Araç tipi eklenirken bir hata oluştu.");
            }
            return View(vehicleType); 
        }

        //Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicleType = await _vehicleTypeApiService.GetVehicleTypeByIdAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VehicletypeId,Brand,ModelName,CapacityKg,CapacityM3")] VehicleType vehicleType)
        {
            if (id != vehicleType.VehicletypeId) 
            {
                return NotFound();
            }
            if (vehicleType.Vehicles != null)
            {
                vehicleType.Vehicles = null;
            }

            if (ModelState.IsValid)
            {
                var success = await _vehicleTypeApiService.UpdateVehicleTypeAsync(vehicleType);
                if (success)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                ModelState.AddModelError("", "Araç tipi güncellenirken bir hata oluştu."); 
            }
            return View(vehicleType); 
        }

        //Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicleType = await _vehicleTypeApiService.GetVehicleTypeByIdAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var success = await _vehicleTypeApiService.DeleteVehicleTypeAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index)); 
            }
            ModelState.AddModelError("", "Araç tipi silinirken bir hata oluştu."); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
