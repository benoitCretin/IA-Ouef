using IA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IA.Network;

namespace IA.Strategies
{
    public class StrategyUntouchable : IStrategie
    {
        #region attributes

        private Game game;
        private string message;
        private List<Road> roads;
        private Player player;
        private Road road;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"></param>
        public StrategyUntouchable(Game game)
        {
            this.game = game;
            this.roads = new List<Road>();
        }

        public void Executer()
        {
            bool endTurn = false;
            string joueur = Connection.RecevoirMessage();
            int num = Convert.ToInt32(joueur.Split("|")[1]);
            message = "";
            while (message != "FIN")
            {
                //When the turn is active
                while (!endTurn)
                {
                    message = Connection.RecevoirMessage(); // get message "DEBUT_TOUR"
                    if (message.StartsWith("DEBUT_TOUR"))
                    {
                        this.game.UpdatePlayers();
                        // If the player has 500 score or more and can buy a member
                        if (this.game.Players[num].Score >= 500 && this.game.Players[num].Attack < 100)
                        {
                            Connection.EnvoyerMessage("RECRUTER"); // The player hire a member
                            Connection.RecevoirMessage(); // Get a message from the server
                            endTurn = true;
                        }

                        // If the hp of the player are less than 3, he must to repair his ship
                        if (this.game.Players[num].Hp < 3)
                        {
                            Connection.EnvoyerMessage("REPARER");
                            Connection.RecevoirMessage();
                            endTurn = true;
                        }
                        
                        else if (this.game.Players[num].ChestNumber <= 1) // If the player has less than 500 score
                        {
                            this.game.UpdateRoads(); // Updating info of all roads

                            roads = new List<Road>();
                            //Verify if the road has a monster AND if the road has more attack than the player
                            foreach (Road r in this.game.Roads)
                            {
                                if (r.HasMonster == false &&
                                    r.AttackValue <= this.game.Players[num].Attack)
                                {
                                    this.roads.Add(r);
                                }
                            }

                            road = this.roads[0];
                            // Get and compare all info of roads
                            foreach (Road r in roads)
                            {
                                if (r.ChestValue1 > road.ChestValue1)
                                {
                                    road = r;
                                }
                            }

                            Connection.EnvoyerMessage($"PILLER|{road.Number}"); // The player loot the road 2
                            Connection.RecevoirMessage(); //End of the turn with the message "Ok"
                            endTurn = true;
                        }
                        
                        if(this.game.Players[num].ChestNumber <= 1)
                        {
                            Connection.EnvoyerMessage("RECELER");
                            Connection.RecevoirMessage();
                            endTurn = true;
                        }
                        else
                        {
                            Connection.EnvoyerMessage("REPARER");
                            Connection.RecevoirMessage();
                            endTurn = true;
                        }
                    }

                    endTurn = false;
                }
            }
        }
    }
}