using LewachBookTrading.Model;
using System.ComponentModel.DataAnnotations;

public class FriendRequest
{
    [Key]
    public int Id { get; set; }

    public int SenderId { get; set; }  // User who sent the request
    public int ReceiverId { get; set; }  // User who received the request
    public DateTime CreatedAt { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsDeclined { get; set; }
    
    public User? Sender { get; set; }
    public User? Receiver { get; set; }
}
