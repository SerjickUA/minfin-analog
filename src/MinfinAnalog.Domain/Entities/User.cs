namespace MinfinAnalog.Domain.Entities;
public class User
{
    public User() { 
        UserWatchlists = new List<UserWatchlist>();
        ExchangeOperations = new List<UserExchangeOperation>();
    }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public virtual ICollection<UserWatchlist> UserWatchlists { get; set; }
    public virtual ICollection<UserExchangeOperation> ExchangeOperations { get; set; }
}

