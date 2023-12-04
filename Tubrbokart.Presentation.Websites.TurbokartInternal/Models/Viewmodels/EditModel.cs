using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tubrbokart.Presentation.Websites.TurbokartInternal.Models.Viewmodels
{
    public class EditModel
    {
        [BindProperty, Required]
        public string Grandprix { get; set; }
        [BindProperty, Required, EmailAddress]
        public string Email { get; set; }
        [BindProperty, Required]
        public string Phonenumber { get; set; }
        [BindProperty, Required]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [BindProperty, Required]
        public string Time { get; set; } = "10:00";
        [BindProperty, Required, Range(1, 20)]
        public byte Amount { get; set; } = 1;
    }
}
