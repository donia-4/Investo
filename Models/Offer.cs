using System.ComponentModel.DataAnnotations;

namespace Investo.Models
{
    public class Offer
    {
        // Primary Key
        public int OfferId { get; set; }

        // ========== FINANCIAL TERMS ==========
        [Range(0.01, double.MaxValue, ErrorMessage = "Offer amount must be positive")]
        public decimal OfferAmount { get; set; }

        [Range(0, 100, ErrorMessage = "Equity must be 0-100%")]
        public decimal EquityPercentage { get; set; }

        [Range(0, 100, ErrorMessage = "Profit share must be 0-100%")]
        public decimal ProfitShare { get; set; }

        // ========== OFFER DETAILS ==========
        public InvestmentType InvestmentType { get; set; }

        [Required]
        [StringLength(2000)]
        public string OfferTerms { get; set; }

        [StringLength(1000)]
        public string? AdditionalServices { get; set; }

        // ========== STATUS & TIMING ==========
        public OfferStatus Status { get; set; } = OfferStatus.Pending;
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;

        [FutureDate(ErrorMessage = "Expiration must be in the future")]
        public DateTime ExpirationDate { get; set; }

        // ========== NOTES & TRACKING ==========
        [StringLength(4000)]
        public string? Notes { get; set; }

        // ========== RELATIONSHIPS ==========
        public int InvestorId { get; set; }
        public Investor Investor { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }

    public enum InvestmentType
    {
        Equity,
        Debt,
        ConvertibleNote,
        ProfitShare,
        SAFE,
        Custom
    }

    public enum OfferStatus
    {
        Pending,      // Waiting for owner response
        Accepted,
        Rejected,
        Countered,    // Owner made counter-offer
        Expired,
        Withdrawn,    // Investor canceled
        UnderReview,
        negotiated    // Legal/compliance check
    }

    // Custom validation attribute
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
            => value is DateTime date && date > DateTime.UtcNow;
    }
}