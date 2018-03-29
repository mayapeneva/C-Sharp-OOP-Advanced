using System.Collections.Generic;
using System.Linq;

namespace CardsGame_EXER
{
    public class Player
    {
        private readonly List<Card> cards;
        private Card strongestCard;

        public Player(string name)
        {
            this.Name = name;
            this.cards = new List<Card>();
            this.strongestCard = new Card("Two", "Clubs");
        }

        public string Name { get; }

        public Card StrongestCard => this.cards.OrderByDescending(c => c).First();

        public List<Card> Cards
        {
            get { return this.cards; }
        }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }
    }
}