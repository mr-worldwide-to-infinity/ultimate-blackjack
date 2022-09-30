using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_1._0
{
    internal class Program

    {
        static void Main(string[] args)
        {
            speler player = new speler();
            bool Iop=false;
            int kl = 0;
            do
            {
                kl++;
                if (kl != 1)
                {
                    Console.Clear();
                }
                kaarten cards = new kaarten();
                player.leeghand();
                player.leeghbank();
                int waardevdkaarten = 0;
                int waardevdbank = 0;
                bool u;
                Console.WriteLine("de bank pakt een kaart:");
                String kaartje = cards.trekkaart();
                if (kaartje.EndsWith("a") == true)
                {
                    kaartje = "aw";
                }
                waardevdbank = player.waardekaart(player.handbank(kaartje));
                Console.WriteLine(player.naam +" pakt nu een kaart:");
                kaartje = cards.trekkaart();
                if (kaartje.Substring(1) == "a")
                {
                    Console.WriteLine("wilt u 1 of 11?");
                    String antwboe = Console.ReadLine();
                    if (antwboe == "1")
                    {
                        kaartje = "aq";
                    }
                    else
                    {
                        kaartje = "aw";
                    }
                }
                player.handspeler(kaartje);
                do
                {
                    u = cards.deal();
                    if (u == true)
                    {
                        kaartje = cards.trekkaart();
                        if (kaartje.Substring(1) == "a")
                        {
                            Console.WriteLine("wilt u 1 of 11?");
                            String antwboe = Console.ReadLine();
                            if (antwboe == "1")
                            {
                                kaartje = "aq";
                            }
                            else
                            {
                                kaartje = "aw";
                            }
                        }
                        waardevdkaarten = player.waardekaart(player.handspeler(kaartje));

                    }
                    Console.WriteLine("u heeft totaal: " + waardevdkaarten);
                } while (waardevdkaarten < 21 && u == true);

                if (waardevdkaarten > 21)
                {
                    Console.WriteLine("bust for player, bank wins!");
                    player.score--;
                }

                if (waardevdkaarten <= 21)
                {
                    Console.WriteLine("de bank pakt nu:");
                    do
                    {
                        kaartje = cards.trekkaart();
                        if (kaartje.Substring(1) == "a")
                        {

                            if (waardevdbank <= 10)
                            {
                                kaartje = "aw";
                            }
                            else
                            {
                                kaartje = "aq";
                            }
                        }
                        waardevdbank = player.waardekaart(player.handbank(kaartje));
                    } while (waardevdbank < 17);
                    Console.WriteLine("de bank heeft " + waardevdbank + " gepakt.");
                    if (waardevdbank > 21)
                    {
                        Console.WriteLine("bust for bank, " + player.naam + " wins!");
                        player.score++;
                    }
                    else
                    {
                        if (waardevdbank < waardevdkaarten)
                        {
                            Console.WriteLine(player.naam + " heeft gewonnen!");
                            player.score++;
                        }
                        if (waardevdbank == waardevdkaarten)
                        {
                            Console.WriteLine("gelijkspel, geen winnaars of verlizers.");
                        }
                        if(waardevdbank > waardevdkaarten)
                        {
                            Console.WriteLine("De bank heeft gewonnen!");
                            player.score--;
                        }
                    }
                }

                Console.WriteLine("u heeft in totaal: " + player.score + " keer gewonnen.");
                Console.WriteLine("wilt u nogmaals spelen? y/n");
                String atw = Console.ReadLine();
                if (atw == "y")
                {
                    Iop = true;
                }
                else
                {
                    Iop = false;
                }
            } while (Iop == true);
        }
    }
}
