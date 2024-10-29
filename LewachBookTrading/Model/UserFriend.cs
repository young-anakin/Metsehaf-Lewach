using LewachBookTrading.Model;

public class UserFriend
{
    public int UserId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public User User { get; set; }

    public int FriendId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public User Friend { get; set; }
}
