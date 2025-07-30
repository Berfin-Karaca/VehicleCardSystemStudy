using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleCardSystem.Core.Models;
using VehicleCardSystem.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VehicleCardSystem.Web.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleApiService _vehicleApiService;
        private readonly IVehicleTypeApiService _vehicleTypeApiService;

        public VehiclesController(IVehicleApiService vehicleApiService, IVehicleTypeApiService vehicleTypeApiService)
        {
            _vehicleApiService = vehicleApiService;
            _vehicleTypeApiService = vehicleTypeApiService;
        }
        //list
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleApiService.GetVehiclesAsync();
            if (vehicles == null)
            {
                return View(new List<Vehicle>());
            }
            return View(vehicles);
        }
        //detail
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var vehicle = await _vehicleApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }
        //create
        public async Task<IActionResult> Create()
        {
            await PopulateVehicleTypesDropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Plate,VehicletypeId,ModelYear,Color")] Vehicle vehicle)
        {            
            if (vehicle.VehicleId == Guid.Empty)
            {
                vehicle.VehicleId = Guid.NewGuid();
            }
           

            if (ModelState.IsValid)
            {
                var success = await _vehicleApiService.AddVehicleAsync(vehicle);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Araç eklenirken bir hata oluştu.");
            }
            await PopulateVehicleTypesDropdown();
            return View(vehicle);
        }
        //edit
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var vehicle = await _vehicleApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            await PopulateVehicleTypesDropdown(vehicle.VehicletypeId);
            return View(vehicle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VehicleId,Plate,VehicletypeId,ModelYear,Color")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                var success = await _vehicleApiService.UpdateVehicleAsync(vehicle);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Araç güncellenirken bir hata oluştu.");
            }

            await PopulateVehicleTypesDropdown(vehicle.VehicletypeId);
            return View(vehicle);
        }
        //delete
        //Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var vehicle = await _vehicleApiService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var success = await _vehicleApiService.DeleteVehicleAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Araç silinirken bir hata oluştu.");
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateVehicleTypesDropdown(Guid? selectedVehicleTypeId = null)
        {
            var vehicleTypes = await _vehicleTypeApiService.GetVehicleTypesAsync();
            if (vehicleTypes != null)
            {
                ViewBag.VehicleTypeId = new SelectList(vehicleTypes, "VehicletypeId", "ModelName", selectedVehicleTypeId);                
            }
            else
            {
                ViewBag.VehicleTypeId = new SelectList(new List<VehicleType>(), "VehicletypeId", "ModelName");
            }
        }
    }
}
