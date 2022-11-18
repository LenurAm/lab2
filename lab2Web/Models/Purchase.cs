using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab2Web.Models
{
    public class Purchase
    {
        [Key]
        //[DisplayName("Id")]
        //[Range(1,100, ErrorMessage="Id is out of range!")]
        public int UserId { get; set; }
        public int? PurchaseNumber  { get; set; }
       
        [Required]
        public int? SupplierId { get; set; }
        [Required]
        public int? InvoiceNumber { get; set; }
        public double Cost { get; set; }
        public DateTime CreateDateTime { get; set; }

    }
}
