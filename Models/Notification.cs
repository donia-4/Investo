using System.ComponentModel.DataAnnotations.Schema;

namespace Investo.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }  // PK
        public int ReceiverUserId { get; set; }  // FK to User
        public UserType ReceiverUserType { get; set; }  // Investor or BusinessOwner
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public NotificationStatus Status { get; set; } = NotificationStatus.Unread;

        // Link to related entity (e.g., ProjectId, OfferId, MessageId) 
        public string EntityType { get; set; } = string.Empty; // "Project", "Offer", "Message", etc.
        public int? EntityId { get; set; }     // ID of the related entity

        // Navigation property
        [ForeignKey("ReceiverUserId")]
        public User Receiver { get; set; }
    }

    public enum UserType
    {
        Investor,
        BusinessOwner
    }

    public enum NotificationStatus
    {
        Unread,
        Read,
        Archived
    }
}
