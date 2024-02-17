using System.ComponentModel.DataAnnotations;

namespace ChatDB
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        
        public string SenderId { get; set; }
        public string ReceverId { get; set; }
        
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public User Sender { get; set; }
        public User Recever { get; set; }

    }
}
