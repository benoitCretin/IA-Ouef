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
            this.roads = new List<Road>();
            this.turnNumber = 1;
        }
    }
}
