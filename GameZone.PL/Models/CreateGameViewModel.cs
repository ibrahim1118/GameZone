using DAL.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.PL.Models
{
    public class CreateGameViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        [AllowNull]
        public string? ImageName { get; set; } = string.Empty.ToString();

        public IFormFile? Image { get; set; } = default;   
        public int CategoryId { get; set; }

        public SelectList? Categorys { get; set; } 

        public List<int> SelectedDevices { get; set; } = new List<int>(); 
        
        public SelectList? Devices { get; set; } 
    }
}
