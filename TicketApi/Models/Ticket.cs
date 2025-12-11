namespace TicketApi.Models
{

    public class Ticket
    {
        public string TicketId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string HolderName { get; set; }
    }
}