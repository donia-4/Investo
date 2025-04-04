namespace Investo.Models
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string Url { get; set; }           // e.g., "https//storage.com/voice_123.mp3"
        public string FileName { get; set; }      // "voice_message.mp3"
        public string ContentType { get; set; }   // "audio/mpeg"
        public long FileSizeBytes { get; set; }   // 102400 (100KB)
        public int? DurationSeconds { get; set; } // For voice: 30 (sec)
    }

}
