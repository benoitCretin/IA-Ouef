using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IA.Model
{
    public class Player
    {
        /// <summary>
        /// Get and set the number of the player
        /// </summary>
        public int Number { get => this.number; set => this.number = value; }
        private int number;

        /// <summary>
        /// Get and set the score of the player
        /// </summary>
        public int Score { get => this.score; set => this.score = value; }
        private int score;

        /// <summary>
        /// get and set the value attack of the player
        /// </summary>
        public int Attack { get => this.attack; set => this.attack = value; }
        private int attack;

        /// <summary>
        /// Get and set the number of Hp of the player
        /// </summary>
        public int Hp { get => this.hp; set => this.hp = value; }
        private int hp;

        /// <summary>
        /// Get and set the activity the player will do
        /// </summary>
        public string Activity { get => this.activity; set => this.activity = value; }
        private string activity;

        /// <summary>
        /// Get and set the number of chest the player has
        /// </summary>
        public int ChestNumber { get => this.chestNumber; set => this.chestNumber = value; }
        private int chestNumber;

        /// <summary>
        /// Get and set the Value of chest the player has
        /// </summary>
        public int LootValue { get => this.lootValue; set => this.lootValue = value; }
        private int lootValue;

    }
}
