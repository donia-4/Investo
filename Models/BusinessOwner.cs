namespace Investo.Models
{
    public class BusinessOwner : User
    {
        public string KYCStatus { get; set; }
        public byte[] PassportDocument { get; set; }
        public byte[] NationalIDDocument { get; set; }
        public DateTime LastActivity { get; set; }
        public int projectId { get; set; }
        public Project project { get; set; }

        public List<Offer> offers { get; set; }
        public List<Message> Messages { get; set; }

    }
}
