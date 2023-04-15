using FriendsApp.FriendClass;
using FriendsApp.FriendModels;

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

    public static bool BackToMenu(bool run)
    {
        string separatorString = new string('*', 40);
        string separator = $"\n{separatorString}\n";

        WriteLine(separator);
        WriteLine("Press Enter to go back, x to exit");
        WriteLine(separator);
        string? answer = ReadLine();
        if (answer == "x")
        {
            run = false;
        }

        return run;
    }

    public static void ListFriends(List<FriendModel> friendsList)
    {
        foreach (FriendModel friend in friendsList)
        {
            WriteLine(
                $"Name: {friend.Name} Age: {friend.Age} Email: {friend.Email} Phone: {friend.Phone}"
            );
        }
    }
}
