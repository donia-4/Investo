namespace Investo.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; }
        public string Subtitle { get; set; }
        public string ProjectLocation { get; set; }
        public byte[] ProjectImageURL { get; set; }
        public string? ProjectVideo { get; set; } // Optional
        public decimal FundingGoal { get; set; }
        public string FundingExchange { get; set; }
        public List<string> AdditionalNeeds { get; set; } // Multiple entries
        public string ProjectVision { get; set; }
        public bool PackagesInvestment { get; set; }
        public bool InvestmentNegotiation { get; set; }
        public string ProjectStory { get; set; }
        public string CurrentVision { get; set; }
        public string Goals { get; set; }
        public string BankAccountInformation { get; set; }

        // Relationships
        public byte CategoryId { get; set; }
        public Category Category { get; set; } // One-to-one with Category
        public int UserId { get; set; } // Foreign key to BusinessOwner (inherits from User)
        public BusinessOwner Owner { get; set; } // One-to-one with BusinessOwner

    }
}
