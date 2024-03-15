using ClockPatience.Models;
using ClockPatience.Views;

namespace ClockPatience.Controllers
{
    public class GameController
    {
        // Singleton instance of GameController
        private static GameController instance = new GameController();
        private View view; // View for the game
        private Game game; // Model for the game

        // Private constructor to enforce singleton pattern
        private GameController()
        {
            view = new View();
            game = new Game();
        }
        
        // Public property to get the singleton instance
        public static GameController Instance => instance;

        // Method to start the game
        public void Start()
        {
            view.DisplayWelcome();
            string line;

            // Loop to get user input until '#' is entered
            while ((line = view.GetUserInput()) != "#")
            {
            }
        }
    }
}