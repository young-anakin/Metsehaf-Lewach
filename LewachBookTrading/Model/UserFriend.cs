namespace LewachBookTrading.Model
{
    public class UserFriend
    {
        public int UserId { get; set; }

        public int FriendId { get; set; }

        public User? Friend { get; set; }
    }
}
