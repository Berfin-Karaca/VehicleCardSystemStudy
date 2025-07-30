using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace VehicleCardSystem.Core.Models
{
    public class VehicleType
    {
        public Guid VehicletypeId { get; set; }
        [Required(ErrorMessage = "Marka zorunludur.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model adı zorunludur.")]
        public string ModelName { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "KG kapasitesi pozitif olmalıdır.")]
        public double CapacityKg { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "M3 kapasitesi pozitif olmalıdır.")]
        public double CapacityM3 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
