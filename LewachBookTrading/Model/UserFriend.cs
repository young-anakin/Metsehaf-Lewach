using LewachBookTrading.Model;
using System.ComponentModel.DataAnnotations;

public class UserFriend
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FriendId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]

    public User User { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]

    public User Friend { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Now;
}
