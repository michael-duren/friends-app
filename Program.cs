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

            switch (userChoice)
            {
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
                case "2":
                    WriteLine("Adding Friends");
                    // Additional logic goes here
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
