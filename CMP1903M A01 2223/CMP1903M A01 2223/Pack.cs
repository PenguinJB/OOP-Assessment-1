using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        //Opens list of cards
        public List<Card> pack;

        //Initialises Pack
        public Pack()
        {
            //Creates new empty pack list
            pack = new List<Card>();
            //For each value in CardSuit 
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
            
            {
                //For each value in CardValue
                foreach (Card.CardValue value in Enum.GetValues(typeof(Card.CardValue)))
                
                {
                    //Create  a new card
                    Card card = new Card(value, suit);
                    //Add to pack. 52 ordered unique cards
                    pack.Add(card);
                    
                }
            }
        }

       
        public List<Card> GetPack()
        {
            //Returns pack for use by other methods
            return pack;
        }

        public static bool ShuffleCardPack(List<Card> pack)
        {
            //Ensures correct shuffle input
            bool validshuffle = false;
            while (validshuffle == false)
            {
                Console.WriteLine("Choose a Shuffle");
                Console.WriteLine("1 for Fisher-Yates, 2 for Riffle, 3 for No Shuffle");
                int UserShuffleInput = int.Parse(Console.ReadLine());

                if (UserShuffleInput == 1)
                {

                    //Fisher-Yates
                    Console.WriteLine("Doing Fisher-Yates Shuffle");
                    //Add randomness
                    Random random = new Random();
                    //For length of pack -1, while length is >0, length taking 1 each time
                    for (int length = pack.Count - 1; length > 0; length--)
                    {
                        //Choose a card
                        int x = random.Next(0, length + 1);
                        //Swap with last card
                        (pack[x], pack[length]) = (pack[length], pack[x]);
                    }
                    
                    return true;
                }

                else if (UserShuffleInput == 2)
                {
                    //Riffle
                    
                    Console.WriteLine("Doing Riffle Shuffle");

                    //Split the deck in half
                    List<Card> firstHalf = pack.GetRange(0, 26);
                    List<Card> secondHalf = pack.GetRange(26, 26);

                    //Interleave the two halves
                    List<Card> shuffledPack = new List<Card>();
                    for (int i = 0; i < 26; i++)
                    {
                        shuffledPack.Add(firstHalf[i]);
                        shuffledPack.Add(secondHalf[i]);
                    }

                    //Update the original pack with the shuffled cards
                    pack = shuffledPack;
                    return true;

                }


                else if (UserShuffleInput == 3)
                {
                    //No Shuffle
                    
                    Console.WriteLine("Doing No Shuffle");
                    return true;
                }

                else
                {
                    Console.WriteLine("Invalid Shuffle");
                    validshuffle = false;
                }
            }   
            return false;

        }
        public static Card Deal(List<Card> pack)
        {
            //Deals one card
            //Get the first card in the pack
            Card cardToDeal = pack[0];

            //Remove the card from the pack
            pack.RemoveAt(0);

            //Print the card that was dealt to the user
            Console.WriteLine("Dealt Card: " + cardToDeal.Suit + " of " + cardToDeal.Value);

            //Return the card that was dealt
            return cardToDeal;
        }
        public static List<Card> DealCard(List<Card> pack)
        {
            //User input of cards to deal
            Console.WriteLine("How many cards would you like to deal? ");
            int numCardsToDeal = int.Parse(Console.ReadLine());
            //Ensures doesnt exceed the amount of cards (52)
            if (numCardsToDeal > pack.Count)
            {
                Console.WriteLine("There are only" + pack.Count + "cards left in the pack. Cannot deal" + numCardsToDeal + "cards.");
                return null;
            }
            //Uses Deal method for amount of times user wants to deal a card
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < numCardsToDeal; i++)
            {
                //Adds to new dealtCard list and prints it back to user
                Card dealtCard = Deal(pack);
                dealtCards.Add(dealtCard);
                Console.WriteLine("Dealt Card: " + dealtCard.Suit + " of " + dealtCard.Value);
            }

            return dealtCards;
        }
    }
}
