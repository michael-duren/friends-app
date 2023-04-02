namespace FriendsApp.ConsoleUtilities;

public class Utilities
{
    static void WriteError(string value)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(value);

        // Reset colors
        ResetColor();
    }
}
