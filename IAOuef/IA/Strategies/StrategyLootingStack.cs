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
            Connection.RecevoirMessage();
            string message = Connection.RecevoirMessage();
            if (message.StartsWith("DEBUT_TOUR"))
            {
                string number = message.Split('|')[1];
            }
        }
    }
}
