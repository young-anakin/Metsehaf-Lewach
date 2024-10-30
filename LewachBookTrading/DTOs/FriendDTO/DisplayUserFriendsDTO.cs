namespace LewachBookTrading.DTOs.FriendDTO
{

    public class DisplayUserFriendsDTO
    {
        public List<FriendsDTO> Friends { get; set; }

    }

    public class FriendsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Photo { get; set; }
    }


}
