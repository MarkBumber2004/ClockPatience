namespace ClockPatience.Models
{
    public class Deck
    {
        // List of cards in the deck
        private List<Card> cards;

        // Constructor for the Deck class, requires a list of cards
        public Deck(List<Card> cards)
        {
            this.cards = cards;
        }

        // Method to add a card to the deck
        public void AddCard(Card card) => cards.Add(card);

        // Method to get all cards in the deck
        public IEnumerable<Card> GetCards() => cards;
    }
}