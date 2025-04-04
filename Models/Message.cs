using System.ComponentModel.DataAnnotations.Schema;

namespace Investo.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        // Message metadata
        public MessageType MessageType { get; set; } = MessageType.Text; // text is default type
        public Attachment? Attachment { get; set; }

        // Navigation properties
        [ForeignKey("SenderId")]
        public int SenderId { get; set; }  // Can be either Investor or BusinessOwner
        public User Sender { get; set; } = new User();

        [ForeignKey("ReceiverId")]
        public int ReceiverId { get; set; } // Can be either Investor or BusinessOwner
        public User Receiver { get; set; } = new User();

        // Optional: Reference to related Project if messages are project-specific
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

    }
    public enum MessageType
    {
        Text,       // Plain text
        Voice,      // Audio message
        Document,   // PDF/DOCX
        Image,      // PNG/JPG
        Video       // MP4/MOV
    }
}
