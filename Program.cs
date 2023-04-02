using FriendsApp.FriendClass;

namespace FriendsApp;

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        string separatorString = new string('*', 40);
        string separator = $"\n{separatorString}\n";

        while (run)
        {
            // welcome
            WriteLine(separator);
            WriteLine("Welcome to FriendsApp");
            WriteLine(separator);

            // menu
            WriteLine("Menu:");
            WriteLine("[1] ------------ List Friends");
            WriteLine("[2] ------------ Add Friends");
            WriteLine("[3] ------------ Remove Friends");
            WriteLine("[x] ------------ Quit");

            // choice
            string? userChoice = ReadLine();

            List<Friend> friendsList = new();

            switch (userChoice)
            {
                // Listing Friends
                case "1":
                    WriteLine("Here are your friends!");
                    // Additional logic goes here
                    WriteLine("Press Enter to go back, x to quit");
                    string? answer = ReadLine();
                    if (answer == "x")
                    {
                        run = false;
                    }
                    break;

                // Adding Friends
                case "2":
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
                    string? answerT = ReadLine();
                    if (answerT == "x")
                    {
                        run = false;
                    }
                    break;
                case "3":
                    WriteLine("Removing Friends");
                    // Additional logic goes here
                    break;
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
