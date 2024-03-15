namespace ClockPatience.Models
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public class Card
    {
        // Enum for the rank of the card (Ace, Two, ..., King)
        public Rank Rank { get; }

        // Enum for the suit of the card (Hearts, Diamonds, Clubs, Spades)
        public Suit Suit { get; }

        // Constructor for the Card class, requires a rank and a suit
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        // Override of the ToString method to display the card's rank and suit and use substring to get the first character of the rank and suit
        public override string ToString() => $"{Rank.ToString().Substring(0, 1)}{Suit.ToString().Substring(0, 1)}";    
    }
}