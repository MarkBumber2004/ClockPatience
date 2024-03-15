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
            List<Card> currentDeck = new List<Card>();
            string line;

            // Loop to get user input until '#' is entered
            while ((line = view.GetUserInput()) != "#")
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentDeck.Any())
                    {
                        // Play the deck if any cards are present
                        PlayDeck(new Deck(currentDeck));
                        currentDeck.Clear();
                    }
                }
                else
                {
                    // Parse the cards from the input line
                    currentDeck.AddRange(ParseCardsFromLine(line));
                }
            }

            // Play the deck if any cards are left
            if (currentDeck.Any())
            {
                PlayDeck(new Deck(currentDeck));
            }
        }

        // Method to play a deck
        private void PlayDeck(Deck deck)
        {
            game.SetupDeck(deck);
            var (exposedCount, lastCard) = game.Play();
            view.DisplayResult(exposedCount, lastCard?.ToString() ?? "null");
        }

        // Method to parse cards from a line of input
        private IEnumerable<Card> ParseCardsFromLine(string line)
        {
            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(cardStr =>
                {
                    // Parse the rank of the card
                    Rank rank = cardStr[0] switch
                    {
                        'A' => Rank.Ace,
                        '2' => Rank.Two,
                        '3' => Rank.Three,
                        '4' => Rank.Four,
                        '5' => Rank.Five,
                        '6' => Rank.Six,
                        '7' => Rank.Seven,
                        '8' => Rank.Eight,
                        '9' => Rank.Nine,
                        'T' => Rank.Ten,
                        'J' => Rank.Jack,
                        'Q' => Rank.Queen,
                        'K' => Rank.King,
                        _ => throw new ArgumentException("Invalid card rank")
                    };

                    // Parse the suit of the card
                    Suit suit = cardStr[1] switch
                    {
                        'H' => Suit.Hearts,
                        'D' => Suit.Diamonds,
                        'C' => Suit.Clubs,
                        'S' => Suit.Spades,
                        _ => throw new ArgumentException("Invalid card suit")
                    };

                    // Return a new card with the parsed rank and suit
                    return new Card(rank, suit);
                });
        }

    }
}