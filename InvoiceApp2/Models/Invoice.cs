using System.ComponentModel.DataAnnotations;

namespace InvoiceApp2.Models
{
    public class Invoice
    {
        
        public int Id { get; set; }

        [Required]
        public string? FileName { get; set; }

        public DateTime Date { get; set; }

        public string? FilePath { get; set; }
        
        public string? InvoiceNumber { get; set; }

        public decimal Amount { get; set; }

        public string? Vendor {  get; set; }

        public string? Status { get; set; }

        public string? Email { get; set; }

        public string? ExtractedText { get; set; }
    }
}
