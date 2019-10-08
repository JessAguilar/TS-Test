using System;

namespace SnakeAndLadders
{
    public class Dice
    {
        public int ValueDice { get; set; }
        public int GetValueDice()
        {
            Random randomNumber = new Random();
            this.ValueDice = randomNumber.Next(1, 7);
            return ValueDice;
        }
    }
}
