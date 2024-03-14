using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MvcEcommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        [DataType(DataType.Text)]
        public string? Color { get; set; }
        [DataType(DataType.Text)]
        public string? ImagePath { get; set; }
    }
}
