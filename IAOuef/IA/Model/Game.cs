using IA.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Model
{
    public class Game
    {
        public Dictionary<int,Player> Players { get => this.players; set => this.players = value; }
        private Dictionary<int,Player> players;

        public List<Road> Roads { get => this.roads; set => this.roads = value; }
        private List<Road> roads;

        public int TurnNumber { get => this.turnNumber; set => this.turnNumber = value; }
        private int turnNumber;

        public Game()
        {
            this.players = new Dictionary<int, Player>();
            for(int i = 0; i < 4; i++)
            {
                this.players.Add(i+1,new Player());

            }
            this.roads = new List<Road>();
            for(int i = 0; i < 4; i++)
            {
                this.roads.Add(new Road());
            }
            this.turnNumber = 1;
        }

        public void UpdatePlayers()
        {
            Connection.EnvoyerMessage("JOUEURS");
            string message = Connection.RecevoirMessage();

            string[] firstSplit = message.Split('|');
            string[] player1 = firstSplit[0].Split(';');
            string[] player2 = firstSplit[1].Split(';');
            string[] player3 = firstSplit[2].Split(';');
            string[] player4 = firstSplit[3].Split(';');

            this.players[1].Score = Convert.ToInt32(player1[0]);
            this.players[1].Attack = Convert.ToInt32(player1[1]);
            this.players[1].Hp = Convert.ToInt32(player1[2]);
            this.players[1].Activity = player1[3];
            this.players[1].ChestNumber = Convert.ToInt32(player1[4]);
            this.players[1].LootValue = Convert.ToInt32(player1[5]);

            
            this.players[2].Score = Convert.ToInt32(player2[0]);
            this.players[2].Attack = Convert.ToInt32(player2[1]);
            this.players[2].Hp = Convert.ToInt32(player2[2]);
            this.players[2].Activity = player2[3];
            this.players[2].ChestNumber = Convert.ToInt32(player2[4]);
            this.players[2].LootValue = Convert.ToInt32(player2[5]);

            this.players[3].Score = Convert.ToInt32(player3[0]);
            this.players[3].Attack = Convert.ToInt32(player3[1]);
            this.players[3].Hp = Convert.ToInt32(player3[2]);
            this.players[3].Activity = player3[3];
            this.players[3].ChestNumber = Convert.ToInt32(player3[4]);
            this.players[3].LootValue = Convert.ToInt32(player3[5]);

            this.players[4].Score = Convert.ToInt32(player4[0]);
            this.players[4].Attack = Convert.ToInt32(player4[1]);
            this.players[4].Hp = Convert.ToInt32(player4[2]);
            this.players[4].Activity = player4[3];
            this.players[4].ChestNumber = Convert.ToInt32(player4[4]);
            this.players[4].LootValue = Convert.ToInt32(player4[5]);
        }

        public void UpdateRoads()
        {
            Connection.EnvoyerMessage("ROUTES");
            string message = Connection.RecevoirMessage();

            string[] firstSplit = message.Split('|');
            string[] road1 = firstSplit[0].Split(';');
            string[] road2 = firstSplit[1].Split(';');
            string[] road3 = firstSplit[2].Split(';');
            string[] road4 = firstSplit[3].Split(';');

            this.roads[0].Number = 1;
            this.roads[0].Level = Convert.ToInt32(road1[0]);
            this.roads[0].AttackValue = Convert.ToInt32(road1[1]);
            this.roads[0].ChestValue1 = Convert.ToInt32(road1[2]);
            this.roads[0].ChestValue2 = Convert.ToInt32(road1[3]);
            this.roads[0].ChestValue3 = Convert.ToInt32(road1[4]);
            this.roads[0].HasMonster = Convert.ToBoolean(road1[5]);

            this.roads[1].Number = 2;
            this.roads[1].Level = Convert.ToInt32(road2[0]);
            this.roads[1].AttackValue = Convert.ToInt32(road2[1]);
            this.roads[1].ChestValue1 = Convert.ToInt32(road2[2]);
            this.roads[1].ChestValue2 = Convert.ToInt32(road2[3]);
            this.roads[1].ChestValue3 = Convert.ToInt32(road2[4]);
            this.roads[1].HasMonster = Convert.ToBoolean(road2[5]);

            this.roads[2].Number = 3;
            this.roads[2].Level = Convert.ToInt32(road1[0]);
            this.roads[2].AttackValue = Convert.ToInt32(road3[1]);
            this.roads[2].ChestValue1 = Convert.ToInt32(road3[2]);
            this.roads[2].ChestValue2 = Convert.ToInt32(road3[3]);
            this.roads[2].ChestValue3 = Convert.ToInt32(road3[4]);
            this.roads[2].HasMonster = Convert.ToBoolean(road3[5]);

            this.roads[3].Number = 4;
            this.roads[3].Level = Convert.ToInt32(road4[0]);
            this.roads[3].AttackValue = Convert.ToInt32(road4[1]);
            this.roads[3].ChestValue1 = Convert.ToInt32(road4[2]);
            this.roads[3].ChestValue2 = Convert.ToInt32(road4[3]);
            this.roads[3].ChestValue3 = Convert.ToInt32(road4[4]);
            this.roads[3].HasMonster = Convert.ToBoolean(road4[5]);

        }
    }
}
