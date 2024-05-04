using IA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Strategies
{
    public class StrategieBetrayal : IStrategie
    {
        private Game game;

        public StrategieBetrayal(Game game)
        {
            this.game = game;
        }

        public void Executer()
        {

        }
    }
}
