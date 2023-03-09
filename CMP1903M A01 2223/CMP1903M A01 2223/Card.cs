using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.

        //Suits in enums
        public enum CardSuit { Hearts = 1, Diamonds, Clubs, Spades }




        //Values in enums
        public enum CardValue { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }


        //Getting and Setting Values
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }



        //Method Which creates a card having two values, Value and Suit
        public Card(CardValue _value, CardSuit _suit)
        {
            Value = _value;
            Suit = _suit;



        }



        public override string ToString()
        {
            return Value + " of " + Suit;
        }
    }
}
