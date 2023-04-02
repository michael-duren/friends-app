namespace FriendsApp.Friend;

public class Friend
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public readonly DateTime Instantiated;

    // constructors

    public Friend()
    {
        Name = "Unknown";
        Age = 0;
        DateOfBirth = DateTime.Now;
        Instantiated = DateTime.Now;
    }

    public Friend(string name, DateTime dateOfBirth)
    {
        Name = name;
        Age = GetAge(dateOfBirth);
        DateOfBirth = dateOfBirth;
        Instantiated = DateTime.Now;
    }

    // private methods

    private int GetAge(DateTime dateOfBirth)
    {
        int years = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
        return years;
    }

    // public methods

    public void Hello()
    {
        WriteLine(
            $"Hello, I'm your new friend. My name is {this.Name}, I'm {this.Age} years old. Nice to meet you :) "
        );
    }
}
