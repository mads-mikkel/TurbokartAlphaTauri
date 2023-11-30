using System.ComponentModel.DataAnnotations;
using Turbokart.Domain.Entities;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels
{
    public class DeleteModel
    {
        public Booking Booking { get; set; }
        [Required, MinLength(1)]
        public string Reason { get; set; }
    }
}
