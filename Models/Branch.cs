using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public DateTime? AddingDate { get; set; }
        public bool IsActive { get; set; }
    }
}
