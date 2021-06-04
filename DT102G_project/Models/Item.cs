using System;
using System.ComponentModel.DataAnnotations;

namespace DT102G_project.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public int Qty { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Item()
        {
        }
    }
}
