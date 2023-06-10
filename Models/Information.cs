using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Information
    {

        [Key]
        public int Id { get; set; }

        public string name { get; set; }
        public string? description { get; set; }
        public string Status { get; set; }

        public string EntryDate{ get; set; }

    }
}
