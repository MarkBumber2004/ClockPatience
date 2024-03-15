namespace ClockPatience.Models
{
    public class Game
    {
        // List of piles for each rank of cards (Ace to King)
        private List<Pile> piles = Enumerable.Range(0, 13).Select(_ => new Pile()).ToList();

        // Method to setup the game with a deck of cards
        public void SetupDeck(Deck deck)
        {
            // Distribute the cards in the deck to the corresponding piles based on their rank
            foreach (var card in deck.GetCards())
            {
                int pileIndex = (int)card.Rank - 1;
                piles[pileIndex].AddCard(card);
            }
        }

        // Method to play the game and return the count of exposed cards and the last card
        public (int exposedCount, Card lastCard) Play()
        {
            int exposedCount = 0;
            // Start with the top card of the King pile
            Card currentCard = piles[12].GetTopCard();

            // Continue to the pile of the current card's rank until a pile is empty
            while (currentCard != null)
            {
                exposedCount++;
                int nextPileIndex = (int)currentCard.Rank - 1;
                if (piles[nextPileIndex].IsEmpty()) break;
                currentCard = piles[nextPileIndex].GetTopCard();
            }

            // Return the count of exposed cards and the last card
            return (exposedCount, currentCard);
        }
    }
}