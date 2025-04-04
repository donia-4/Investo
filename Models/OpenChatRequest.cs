using System.ComponentModel.DataAnnotations;

namespace Investo.Models
{ 
        public class OpenChatRequest
        {
            [Key]
            public int RequestId { get; set; }
            public int InvestorId { get; set; }
            public int BusinessOwnerId { get; set; }
            public int ProjectId { get; set; }

            // Request Metadata
            public DateTime RequestDate { get; set; } = DateTime.UtcNow;
            public RequestStatus Status { get; set; } = RequestStatus.Pending;
            [StringLength(500)]
            public string InitialMessage { get; set; }

            // Policy Enforcement
            public bool IsInvestorVerified { get; set; }
            public bool IsProjectActive { get; set; }
            public bool PassedAutomatedScan { get; set; }
            public string PolicyViolationReasons { get; set; }

            // Admin Controls
            public int? ReviewedByAdminId { get; set; }
            public DateTime? ReviewDate { get; set; }
            public string? AdminComments { get; set; }
        }

        public enum RequestStatus
        {
            Pending,        // Waiting for review
            Approved,       // Chat opened
            Rejected,       // Admin denied
            FlaggedForReview, // Requires manual check
            AutoRejected    // Blocked by system
        }

        public enum ViolationType
        {
            None,
            Profanity,
            FinancialSolicitation,
            PersonalInformationRequest,
            Other
        }
}