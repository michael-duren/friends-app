using FriendsApp.FriendClass;
using FriendsApp.ConsoleUtilities;

namespace FriendsApp;

class Program
{
    static void Output(string title, List<Friend> friends)
    {
        WriteLine(title);
        foreach (Friend friend in friends)
        {
            WriteLine($"   {friend.Name}");
        }
    }

    static void OutputOptions(string title, List<Friend> friends)
    {
        WriteLine(title);
        for (int i = 0; i < friends.Count; i++)
        {
            WriteLine($"[{i}] ------------ {friends[i].Name}");
        }
    }

    static void Main(string[] args)
    {
        List<Friend> friendsList = new();

        friendsList.Add(new Friend("Tom", new DateTime(1990, 1, 1)));
        friendsList.Add(new Friend("Josh", new DateTime(1990, 1, 1)));

        bool run = true;
        string separatorString = new string('*', 40);
        string separator = $"\n{separatorString}\n";

        // welcome
        WriteLine(separator);
        WriteLine("Welcome to FriendsApp");
        WriteLine(separator);

        while (run)
        {
            // menu
            WriteLine("Menu:");
            WriteLine("[1] ------------ List Friends");
            WriteLine("[2] ------------ Add Friends");
            WriteLine("[3] ------------ Remove Friends");
            WriteLine("[x] ------------ Quit");

            // choice
            string? userChoice = ReadLine();

            switch (userChoice)
            {
                // Listing Friends
                case "1":
                {
                    WriteLine("Here are your friends!");
                    Output("Friends: ", friendsList);

                    WriteLine("Press Enter to go back, x to quit");
                    string? answer = ReadLine();
                    if (answer == "x")
                    {
                        run = false;
                    }
                    break;
                }

                // Adding Friends
                case "2":
                {
                    WriteLine("Name?: ");
                    string? name = ReadLine();
                    WriteLine("Date of birth (yyyy/mm/dd): ");
                    string? dateOfBirth = ReadLine();
                    if (
                        DateTime.TryParse(dateOfBirth, out DateTime parsedDateOfBirth)
                        && (name is not null)
                    )
                    {
                        WriteLine("Adding Friend");
                    }
                    else
                    {
                        WriteLine("Incorrect Date Format");
                    }

                    Friend newFriend = new(name!, parsedDateOfBirth);
                    friendsList.Add(newFriend);
                    // Additional logic goes here
                    WriteLine("Press Enter to go back, x to quit");
                    string? answer = ReadLine();
                    if (answer == "x")
                    {
                        run = false;
                    }
                    break;
                }
                case "3":
                {
                    OutputOptions("Friends List: ", friendsList);
                    WriteLine("Enter friend to remove from list");
                    string? removedFriend = ReadLine();

                    if (Int32.TryParse(removedFriend, out int removeIndex))
                    {
                        WriteLine($"Removing {friendsList[removeIndex].Name}");
                        friendsList.RemoveAt(removeIndex);
                    }
                    else
                    {
                        WriteLine(
                            "Please try again, enter the index value for the friend you want to remove"
                        );
                    }

                    OutputOptions("Friends List: ", friendsList);

                    // back to menu
                    WriteLine("Press Enter to go back, x to quit");
                    string? answer = ReadLine();
                    if (answer == "x")
                    {
                        run = false;
                    }
                    break;
                }
                case "x":
                    WriteLine("Goodbye");
                    run = false;
                    break;
                default:
                    WriteLine("Please pick a valid option and try again");
                    break;
            }
        }
    }
}
