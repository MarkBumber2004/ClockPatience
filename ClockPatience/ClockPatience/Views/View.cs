namespace ClockPatience.Views
{
    public class View
    {
        // Method to display the welcome message
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Clock Patience! Enter your deck(s), and type '#' when finished:");
        }

        // Method to get user input from the console
        public string GetUserInput() => Console.ReadLine();

        // Method to display the result of the game
        public void DisplayResult(int exposedCount, string lastCard)
        {
            Console.WriteLine($"{exposedCount:D2},{lastCard}");
        }
    }
}