using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roma
{
    public class Program
    {
        
        
        public static void Main(string[] args)
        {
            List<int> PlayerBets = new List<int>();
            List<int> PlayerNominalBets = new List<int>();
            Engine engine = new Engine();
            Console.WriteLine("введите количество игроков");

            int LastBetNominal = 0;
            int LastBetCount = 0;
            int PlayersCount = Convert.ToInt32(Console.ReadLine());

            engine.InitPlayers(PlayersCount);

            while (true)
            {
                Turn();
                CheckWinner();
            }
            return;



            void Turn()
            {
                engine.ThrowDices();
                for (int i = 0; i < PlayersCount; i++)
                {
                    Console.WriteLine($"\n================================================");
                    Console.WriteLine($"(Игрок {i+1}, введите количество кубиков номинала)  (0 = не верю)");
                    int DiceCount = Convert.ToInt32(Console.ReadLine());
                    engine.players[i].BetCount = DiceCount;
                    PlayerBets.Add(DiceCount);

                    if (i == PlayersCount - 1)
                    {
                        Console.WriteLine("Последний игрок всегда должен проверять");
                        DiceCount = 0;
                    }

                    if (i == 0 && DiceCount == 0)
                    {
                        Console.WriteLine("Так не можно на первом ходе");
                        Turn();
                        return;
                    }

                    if (DiceCount == 0)
                    {
                        Check();
                        Console.ReadLine();
                        return;
                    }

                    Console.WriteLine($"\n=================================================");
                    Console.WriteLine($"(Игрок {i+1}, введите номинал кубиков)");
                    int DiceValue = Convert.ToInt32(Console.ReadLine());


                   

                    engine.players[i].BetValue = DiceValue;
                    PlayerNominalBets.Add(DiceValue);
                    

                    if (DiceCount != 0)
                    {
                        LastBetCount = DiceCount;
                        LastBetNominal = DiceValue;
                    }
                }
                
            }


            void Check()
            {
                if(LastBetCount <= engine.CheckDices(LastBetNominal))
                {
                    Player playr = engine.players.Find(x => x.BetValue == 0);
                    Console.WriteLine($"Проверяющий не угадал и лишается кубика");
                    playr.DiceCount--;
                }

                if(LastBetCount > engine.CheckDices(LastBetNominal))
                {
                    Player playr = engine.players.Find(x => x.BetValue == LastBetNominal);
                    Console.WriteLine($"Проверяющий угадал и игрок лишается кубика");
                    playr.DiceCount--;
                }
            }

            void CheckWinner()
            {
                List<Player> winner = engine.players.FindAll(x => x.DiceCount >= 1);

                if(winner.Count == 1)
                {
                    Console.WriteLine($"Победил игрок {winner[0].PlayerID}");
                }
            }
        }

     
    }
}
