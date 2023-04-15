using FriendsApp.FriendClass;
using static FriendsApp.ConsoleUtilities.Utilities;
using FriendsApp.Data;
using FriendsApp.FriendModels;

namespace FriendsApp;

class Program
{
    static void Main(string[] args)
    {
        // instantiate new context
        FriendsContext context = new();
        // instantiate new list for session
        List<Friend> friendsList = new();

        // for testing, creating on each launch
        // friendsList.Add(new Friend("Tom", new DateTime(1990, 1, 1)));
        // friendsList.Add(new Friend("Josh", new DateTime(1990, 1, 1)));

        bool run = true;
        string separatorString = new string('*', 40);
        string separator = $"\n{separatorString}\n";

        // welcome
        WriteLine(separator);
        WriteLine("Welcome to FriendsApp");
        WriteLine(separator);

        // program loop
        while (run)
        {
            // menu
            WriteLine("Menu:");
            WriteLine("   [1] ------------ List Friends");
            WriteLine("   [2] ------------ Add Friends");
            WriteLine("   [3] ------------ Remove Friends");
            WriteLine("   [x] ------------ Exit");

            // choice
            string? userChoice = ReadLine();

            // menu
            switch (userChoice)
            {
                // Listing Friends
                case "1":
                {
                    WriteLine(separator);
                    WriteLine("Here are your friends!");
                    // Output("Friends: ", friendsList);
                    List<FriendModel> dbFriends = context.Friends.ToList();
                    foreach (FriendModel friend in dbFriends)
                    {
                        WriteLine($"{friend.Name} - {friend.Age} - {friend.DateOfBirth}");
                    }

                    WriteLine(separator);

                    break;
                }

                // Adding Friends
                case "2":
                {
                    WriteLine(separator);
                    WriteLine("Name?: ");
                    string? name = ReadLine();
                    WriteLine("Email: ");
                    string? email = ReadLine();
                    WriteLine("Phone");
                    string? phone = ReadLine();
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
                        WriteError("Incorrect Date Format");
                    }

                    // add new Friend to list
                    Friend newFriend = new(name!, parsedDateOfBirth, email!, phone!);
                    // add new Friend to database
                    FriendModel friendModel =
                        new()
                        {
                            Name = newFriend.Name!,
                            Age = newFriend.Age,
                            DateOfBirth = newFriend.DateOfBirth,
                            Email = newFriend.Email,
                            Phone = newFriend.Phone,
                        };
                    friendsList.Add(newFriend);
                    context.Friends.Add(friendModel);
                    context.SaveChanges();

                    // output friendsList
                    Output("Friends: ", friendsList);

                    // back to menu
                    run = BackToMenu(run);
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
                        WriteError(
                            "Please try again, enter the index value for the friend you want to remove"
                        );
                    }

                    OutputOptions("Friends List: ", friendsList);

                    // back to menu
                    run = BackToMenu(run);
                    break;
                }
                case "x":
                    WriteLine("Goodbye");
                    run = false;
                    break;
                default:
                    WriteError("Please pick a valid option and try again");
                    break;
            }
        }
    }
}
