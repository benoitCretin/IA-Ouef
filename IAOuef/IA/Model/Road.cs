using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Model
{
    public class Road
    {
        /// <summary>
        /// Get and set the number of the road
        /// </summary>
        public int Number { get => this.number; set => this.number = value; }
        private int number;

        /// <summary>
        /// Get and set the level of the road
        /// </summary>
        public int Level { get => this.level; set => this.level = value; }
        private int level;

        /// <summary>
        /// Get and set the attack of the ship on the road
        /// </summary>
        public int AttackValue { get => this.attackValue; set => this.attackValue = value; }
        private int attackValue;

        /// <summary>
        /// Get and set the value of the first chest
        /// </summary>
        public int ChestValue1 { get => this.chestValue1; set => this.chestValue1 = value; }
        private int chestValue1;

        /// <summary>
        /// Get and set the value of the second chest
        /// </summary>
        public int ChestValue2 { get => this.chestValue2; set => this.chestValue2 = value; }
        private int chestValue2;

        /// <summary>
        /// Get and set the value of the third chest
        /// </summary>
        public int ChestValue3 { get => this.chestValue3; set => this.chestValue3 = value; }
        private int chestValue3;

        /// <summary>
        /// Get and set the presence of a monster on the road
        /// </summary>
        public bool HasMonster { get => this.hasMonster; set => this.hasMonster = value; }
        private bool hasMonster;
    }
}
