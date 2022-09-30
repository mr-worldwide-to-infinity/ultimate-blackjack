using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_1._0
{
    public class speler
    {
        public String naam;
        public int score;
        List<string> hand = new List<string>();
        List<string> hbank = new List<string>();
        
        public void leeghand()
        {
            hand.Clear();
        }
        public void leeghbank()
        {
            hbank.Clear();
        }

        public speler()
        {
            Console.WriteLine("vul je naam in");
            naam= Console.ReadLine();
            Console.WriteLine("Welkom "+naam);
        }
        public List<string> handspeler(String a)
        { 
            hand.Add(a);
            return hand;
        }
        public List<string> handbank(String a)
        {
            hbank.Add(a);
            return hbank;
        }
        public void leeshand()
        {
            foreach(string s in hand)
                Console.WriteLine(s);
        }
        public int waardekaart(List<string> g)
        {
            int b = 0 ;
            int p=0;
            int h=g.Count() ;
            for (int i = 0; i < h; i++)
            {
                String a=g[i] ;
                p = 0;
                try
                {
                    p = int.Parse(a.Substring(1));
                }
                catch
                {
                    char c = char.Parse(a.Substring(1));
                    if (c == 'b' || c == 'v' || c == 'h')
                    {
                        p = 10;
                    }
                    if (c == 'w')
                    {
                        p = 11;
                    }
                    if (c == 'q')
                    {
                        p = 1;
                    }
                }
                b = (b + p);
            }
            
        return b;
        }
       


    }
}
