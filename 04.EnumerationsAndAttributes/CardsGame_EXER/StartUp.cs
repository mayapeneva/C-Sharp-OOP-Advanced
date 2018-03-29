using System;
using System.Collections.Generic;

namespace CardsGame_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var firstPlayer = new Player(Console.ReadLine());
            var secondPlayer = new Player(Console.ReadLine());

            var deck = new List<Card>();
            while (firstPlayer.Cards.Count < 5 || secondPlayer.Cards.Count < 5)
            {
                var cardInput = Console.ReadLine().Split();
                try
                {
                    var card = new Card(cardInput[0], cardInput[cardInput.Length - 1]);
                    if (!deck.Contains(card))
                    {
                        if (firstPlayer.Cards.Count < 5)
                        {
                            firstPlayer.AddCard(card);
                        }
                        else
                        {
                            secondPlayer.AddCard(card);
                        }
                        deck.Add(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            var winner = firstPlayer.StrongestCard.CompareTo(secondPlayer.StrongestCard);
            Console.WriteLine(winner > 0
                ? $"{firstPlayer.Name} wins with {firstPlayer.StrongestCard}."
                : $"{secondPlayer.Name} wins with {secondPlayer.StrongestCard}.");
        }
    }
}