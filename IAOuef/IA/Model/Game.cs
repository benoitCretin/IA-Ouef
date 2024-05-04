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
        public List<Player> Players { get => this.players; set => this.players = value; }
        private List<Player> players;

        public List<Road> Roads { get => this.roads; set => this.roads = value; }
        private List<Road> roads;

        public int TurnNumber { get => this.turnNumber; set => this.turnNumber = value; }
        private int turnNumber;

        public Game()
        {
            this.players = new List<Player>();
            for(int i = 0; i < 4; i++)
            {
                this.players.Add(new Player());

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

            this.players[2].Score = Convert.ToInt32(player1[0]);
            this.players[2].Attack = Convert.ToInt32(player1[1]);
            this.players[2].Hp = Convert.ToInt32(player1[2]);
            this.players[2].Activity = player1[3];
            this.players[2].ChestNumber = Convert.ToInt32(player1[4]);
            this.players[2].LootValue = Convert.ToInt32(player1[5]);

            this.players[3].Score = Convert.ToInt32(player1[0]);
            this.players[3].Attack = Convert.ToInt32(player1[1]);
            this.players[3].Hp = Convert.ToInt32(player1[2]);
            this.players[3].Activity = player1[3];
            this.players[3].ChestNumber = Convert.ToInt32(player1[4]);
            this.players[3].LootValue = Convert.ToInt32(player1[5]);

            this.players[4].Score = Convert.ToInt32(player1[0]);
            this.players[4].Attack = Convert.ToInt32(player1[1]);
            this.players[4].Hp = Convert.ToInt32(player1[2]);
            this.players[4].Activity = player1[3];
            this.players[4].ChestNumber = Convert.ToInt32(player1[4]);
            this.players[4].LootValue = Convert.ToInt32(player1[5]);

        }
    }
}
