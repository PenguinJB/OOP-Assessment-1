using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Create Pack class
            var pack = new Pack();
            //Get List of cards
            var cards = pack.GetPack();
            //Shuffles cards based on users choice
            Pack.ShuffleCardPack(cards);
            //Asks user to deal one card or multiple
            Console.WriteLine("Would you like to deal one card or multiple?");
            Console.WriteLine("1) One Card");
            Console.WriteLine("2) Multiple Cards");
            //Ensures integer value
            int UserChoice = int.Parse(Console.ReadLine());
            if (UserChoice == 1)
            //Deals one card using Deal Method
            {
                Pack.Deal(cards);
            }
            //Deals multiple cards based on user input using DealCard method
            else if (UserChoice == 2)
            {
                Pack.DealCard(cards);
            }



        }
    }
}
