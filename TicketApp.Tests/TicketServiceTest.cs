using TicketApi.Models;
using TicketApi.Services;
using Xunit;

public class TicketServiceTests
{
    private readonly TicketService _service;

    public TicketServiceTests()
    {
        _service = new TicketService();
    }

    [Fact]
    public void IsTicketValid_ShouldReturnTrue_WhenTicketIsWithinValidityPeriod()
    {
        // Arrange
        var ticket = new Ticket
        {
            TicketId = "A123",
            HolderName = "John Doe",
            IssueDate = DateTime.UtcNow.AddHours(-1),
            ExpiryDate = DateTime.UtcNow.AddHours(2)
        };

        // Act
        var isValid = _service.IsTicketValid(ticket);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsTicketValid_ShouldReturnFalse_WhenTicketExpired()
    {
        var ticket = new Ticket
        {
            TicketId = "B456",
            IssueDate = DateTime.UtcNow.AddHours(-5),
            ExpiryDate = DateTime.UtcNow.AddHours(-1)
        };

        var isValid = _service.IsTicketValid(ticket);

        Assert.False(isValid);
    }

    [Fact]
    public void IsTicketValid_ShouldThrowException_WhenExpiryBeforeIssue()
    {
        var ticket = new Ticket
        {
            TicketId = "C789",
            IssueDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMinutes(-10)
        };

        Assert.Throws<InvalidOperationException>(() => _service.IsTicketValid(ticket));
    }

    [Fact]
    public void IsTicketValid_ShouldThrowException_WhenTicketIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _service.IsTicketValid(null));
    }
}
