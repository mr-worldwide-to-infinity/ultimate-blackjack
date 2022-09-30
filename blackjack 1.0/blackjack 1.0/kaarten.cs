using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_1._0
{
    internal class kaarten
    {

        // Create a List and add a collection
        List<string> deck = new List<string>();
        List<string> banker = new List<string>();
        Random random = new Random();
        public kaarten()
        {
            List<string> animalsList = new List<string>();
            string[] animals = { "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "hb", "hv", "hh", "ha", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "sb", "sv", "sh", "sa", "r2", "r3", "r4", "r5", "r6", "r7", "r8", "r9", "r10", "rb", "rv", "rh", "ra", "k2", "k3", "k4", "k5", "k6", "k7", "k8", "k9", "k10", "kb", "kv", "kh", "ka" };
            animalsList.AddRange(animals);
            deck = animalsList;
         }
        public bool deal()
        {
            Console.WriteLine("wilt u nog een kaart? y/n");
            String antw = Console.ReadLine();
            if (antw == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string trekkaart()
        {
            Console.OutputEncoding= System.Text.Encoding.UTF8;
            int index = random.Next(deck.Count);
            String uwkaart = deck[index];
            if (uwkaart.StartsWith("s"))
            {
                String nummer= uwkaart.Substring(1);
                uwkaart = "\u2660"+nummer;
            }
            if (uwkaart.StartsWith("r"))
            {
                String nummer = uwkaart.Substring(1);
                uwkaart = "\u2666" + nummer;
            }
            if (uwkaart.StartsWith("h"))
            {
                String nummer = uwkaart.Substring(1);
                uwkaart = "\u2665" + nummer;
            }
            if(uwkaart.StartsWith("k"))
            {
                String nummer = uwkaart.Substring(1);
                uwkaart = "\u2663" + nummer;
            }
            Console.WriteLine("gepakt: "+ uwkaart);
            deck.RemoveAt(index);
            return uwkaart;
        }

        public void leeskaart()
        {
            Console.WriteLine(deck.Count);
            foreach (string c in deck) 
            Console.WriteLine(c);
         }
      

    }
}
