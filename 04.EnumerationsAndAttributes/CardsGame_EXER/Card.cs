using System;

namespace CardsGame_EXER
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        private readonly CardRank rank;
        private readonly CardSuit suit;

        public Card(string rank, string suit)
        {
            this.rank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            this.suit = (CardSuit)Enum.Parse(typeof(CardSuit), suit);
        }

        public CardRank Rank => this.rank;
        public CardSuit Suit => this.suit;
        public int Power => (int)this.rank + (int)this.suit;

        public int CompareTo(Card other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var result = this.suit.CompareTo(other.suit);
            if (result != 0)
            {
                return result;
            }

            return this.rank.CompareTo(other.rank);
        }

        public bool Equals(Card other)
        {
            return this.Power.Equals(other.Power);
        }

        public override string ToString()
        {
            return $"{this.rank} of {this.suit}";
        }
    }
}