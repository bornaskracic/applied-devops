using TicketApi.Models;

namespace TicketApi.Services
{
    public class TicketService
    {
        public bool IsTicketValid(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            var now = DateTime.UtcNow;

            if (ticket.ExpiryDate <= ticket.IssueDate)
                throw new InvalidOperationException("Expiry date cannot be earlier than issue date.");

            return now >= ticket.IssueDate && now <= ticket.ExpiryDate;
        }
    }
}

