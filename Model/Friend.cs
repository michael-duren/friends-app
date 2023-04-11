namespace FriendsApp.FriendModels
{
    public class FriendModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
