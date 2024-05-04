using IA.Model;
using IA.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Strategies
{
    public class StrategyLootingStack : IStrategie
    {
        private int playerNumber;
        public void Executer()
        {
            Player myPlayer = new Player();
            Game game = new Game();
            string message = Connection.RecevoirMessage();
            if (message.StartsWith("Bonjour"))
            {
                string number = message.Split("|")[1];
                playerNumber = Convert.ToInt32(number);
            }

            while ((message = Connection.RecevoirMessage()) != "FIN")
            {
                if (message.StartsWith("DEBUT_TOUR"))
                {
                    string[] number = message.Split('|');
                    game.TurnNumber = Convert.ToInt32(number[1]);
                    game.UpdatePlayers();
                    game.UpdateRoads();
                    if (game.Players[playerNumber].ChestNumber == 5)
                    {
                        Connection.EnvoyerMessage("RECELER");
                    }
                    else 
                    if (game.Players[playerNumber].Hp <= 3)
                    {
                        Connection.EnvoyerMessage("REPARER");
                    }
                    else
                    {
                        int nbactions = 0;
                        bool hasMoreAttack = true;
                        while (game.Players[playerNumber].Score >= 500 && hasMoreAttack && nbactions < 14)
                        {
                            hasMoreAttack = false;
                            foreach(Player player in game.Players.Values)
                            {
                                if (player.Attack > game.Players[playerNumber].Attack) hasMoreAttack = true;
                            }
                            if (hasMoreAttack)
                            {
                                Connection.EnvoyerMessage("RECRUTER");
                                nbactions++;
                            }
                        }
                        int nbPillage = 0;
                        int butin = 0;
                        foreach (Road road in game.Roads)
                        {
                            if (game.Players[playerNumber].Attack >= road.AttackValue)
                            {
                                if (road.ChestValue1 > butin && !road.HasMonster)
                                {
                                    nbPillage = road.Number;
                                    butin = road.ChestValue1;
                                }
                            }
                        }
                        if (nbPillage == 0)
                        {
                            Connection.EnvoyerMessage("REPARER");
                        }
                        else
                        {
                            Connection.EnvoyerMessage("PILLER|" +  Convert.ToString(nbPillage));
                        }
                    }
                }
            }

        }
    }
}
