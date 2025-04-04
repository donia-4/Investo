namespace Investo.Models
{
    public class Investor : User
    {
        public string FullLegalName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] NationalID { get; set; }

        public string RiskTolerance { get; set; }
        public string InvestmentGoals { get; set; }
        public List<Category> PreferredIndustries { get; set; } // not navigation properity
        public GeographicFocus GeographicFocus { get; set; } = GeographicFocus.local;
        public decimal MinInvestmentAmount { get; set; }
        public decimal MaxInvestmentAmount { get; set; }
        public string LiquidityPreferences { get; set; }

        public List<string> InvestmentHistory { get; set; } = new List<string>();
        public List<Project> SavedProjects { get; set; } // not navigation properity
        public int PageViews { get; set; }
        public List<string> IPAddressLogs { get; set; } = new List<string>();
        public string AccreditationStatus { get; set; }
        public decimal NetWorth { get; set; }
        public decimal AnnualIncome { get; set; }
        public string TaxID { get; set; }
        public byte[] BankAccountDetails { get; set; }
        public byte[] SourceOfFundsDocument { get; set; } // إثبات دخل
        public string KYCAMLStatus { get; set; }

        // navigation properties
        public List<Offer> Offers { get; set; } = new List<Offer>(); // list of offers he made to different projects
        public List<Message> Messages { get; set; }

    }
    public enum GeographicFocus
    {
        local,
        regional,
        global
    }
}
