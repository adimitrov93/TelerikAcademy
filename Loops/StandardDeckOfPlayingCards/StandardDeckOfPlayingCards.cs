//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for
//loops and switch-case.

using System;

class StandardDeckOfPlayingCards
{
    static void Main()
    {
        string[] cards = {"Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
        string[] suits = {"Spades", "Hearts", "Clubs", "Diamonds"};

        foreach (var suit in suits)
        {
            foreach (var card in cards)
            {
                Console.WriteLine("{0} of {1}", card, suit);
            }
        }
    }
}