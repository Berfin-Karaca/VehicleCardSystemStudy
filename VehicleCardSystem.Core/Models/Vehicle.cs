using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace VehicleCardSystem.Core.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        [Required(ErrorMessage = "Plaka zorunludur")]
        [StringLength(20, ErrorMessage = "Plaka en fazla 10 karakter olabilir")]
        public string Plate { get; set; }
        [Required(ErrorMessage = "Model yılı zorunludur")]
        [Range(1900, 2100, ErrorMessage = "(1900- 2100) Geçerli bir yıl girin")]
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Renk zorunludur")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Araç tipi seçilmelidir")]
        public Guid? VehicletypeId { get; set; }

      
        public virtual VehicleType? VehicleTypes { get; set; }
    }
}
