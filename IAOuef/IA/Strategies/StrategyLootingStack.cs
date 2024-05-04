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
        public void Executer()
        {
            Player myPlayer = new Player();
            Game game = new Game();
            string message = Connection.RecevoirMessage();
            if (message.StartsWith("Bonjour"))
            {
                string number = message.Split("|")[1];
                myPlayer.Number = Convert.ToInt32(number);
            }

            while ((message = Connection.RecevoirMessage()) != "FIN") ;
            {
                if (message.StartsWith("DEBUT_TOUR"))
                {
                    string[] number = message.Split('|');
                    game.TurnNumber = Convert.ToInt32(number[1]);
                }
            }

        }
    }
}
