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
            int nbactions = 0;
            Dictionary<int, int> presences = new Dictionary<int, int>();
            string message = Connection.RecevoirMessage();
            if (message.StartsWith("Bonjour"))
            {
                string number = message.Split("|")[1];
                playerNumber = Convert.ToInt32(number);
            }

            while ((message = Connection.RecevoirMessage()) != "FIN")
            {
                nbactions = 0;
                for (int i = 1; i <= 4; i++)
                {
                    presences[i] = 0;
                }
                if (message.StartsWith("DEBUT_TOUR"))
                {
                    string[] number = message.Split('|');
                    game.TurnNumber = Convert.ToInt32(number[1]);
                    game.UpdatePlayers();
                    foreach (Player player in game.Players.Values)
                    {
                        switch (player.Activity)
                        {
                            case "PILLER1": presences[1]++; break;
                            case "PILLER2": presences[2]++; break;
                            case "PILLER3": presences[3]++; break;
                            case "PILLER4": presences[4]++; break;
                        }
                    }
                    game.UpdateRoads();

                    if (game.TurnNumber == 120) Connection.EnvoyerMessage("RECELER");
                    else
                    {

                        while (game.Players[playerNumber].Attack < 100 && game.Players[playerNumber].Score > 500 && nbactions < 14)
                        {
                            Connection.EnvoyerMessage("RECRUTER");
                            game.Players[playerNumber].Attack += 5;
                            game.Players[playerNumber].Score -= 500;
                            nbactions++;
                        }
                        if (game.Players[playerNumber].ChestNumber == 5)
                        {
                            Connection.EnvoyerMessage("RECELER");
                        }
                        else if (game.Players[playerNumber].Hp <= 3)
                        {
                            Connection.EnvoyerMessage("REPARER");
                        }
                        else
                        {
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
                                    game.Players[playerNumber].Attack += 5;
                                    game.Players[playerNumber].Score -= 500;
                                    nbactions++;
                                }
                            }
                            int nbPillage = 0;
                            int butin = 0;
                            foreach (Road road in game.Roads)
                            {
                                if (game.Players[playerNumber].Attack >= road.AttackValue)
                                {
                                    int chest = road.ChestValue1;
                                    if (presences[road.Number] == 1) { chest = road.ChestValue2; }
                                    if (presences[road.Number] == 2) { chest = road.ChestValue3; }
                                    if (presences[road.Number] == 3) { chest = 0; }
                                    if (chest > butin && !road.HasMonster)
                                    {
                                        nbPillage = road.Number;
                                        butin = chest;
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
}
