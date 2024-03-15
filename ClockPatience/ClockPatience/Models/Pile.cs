namespace ClockPatience.Models
{
    public class Pile
    {
        // Stack of cards in the pile
        private Stack<Card> cards = new Stack<Card>();

        // Method to add a card to the pile
        public void AddCard(Card card) => cards.Push(card);

        // Method to get the top card from the pile
        // Returns null if the pile is empty
        public Card GetTopCard() => cards.Count > 0 ? cards.Pop() : null;

        // Method to check if the pile is empty
        public bool IsEmpty() => cards.Count == 0;
    }
}