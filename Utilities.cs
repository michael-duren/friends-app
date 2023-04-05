using FriendsApp.FriendClass;

namespace FriendsApp.ConsoleUtilities;

public static class Utilities
{
    public static void WriteError(string value)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(value);

        // Reset colors
        ResetColor();
    }

    public static void Output(string title, List<Friend> friends)
    {
        WriteLine(title);
        foreach (Friend friend in friends)
        {
            WriteLine($"   {friend.Name}");
        }
    }

    public static void OutputOptions(string title, List<Friend> friends)
    {
        WriteLine(title);
        for (int i = 0; i < friends.Count; i++)
        {
            WriteLine($"[{i}] ------------ {friends[i].Name}");
        }
    }
}
