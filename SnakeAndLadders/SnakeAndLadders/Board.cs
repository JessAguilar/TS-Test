using System;
using System.Collections.Generic;

namespace SnakeAndLadders
{
    public class Board
    {
        public int SizeBoard { get; set; }
        public int NumberOfLadders { get; set; }
        public int NumberOfSnakes { get; set; }
        public List<Snake> snakesInBoard = new List<Snake>();
        public List<Ladder> laddersInBoard = new List<Ladder>();
        private SnakeAndLaddersRules snakeAndLaddersRules = new SnakeAndLaddersRules();
        public Board(int sizeboard,int numberofladders,int numberofsnakes)
        {
            this.SizeBoard = sizeboard;
            this.NumberOfLadders = numberofladders;
            this.NumberOfSnakes = numberofsnakes;
        }
        public void GenerateSnakes()
        {
            for (int i = 0; i < NumberOfSnakes; i++)
            {
                bool available = true;
                int sizeSnake;
                Snake newSnake = new Snake();
                Random randomNumber = new Random();
                newSnake.InitialPosition = randomNumber.Next(6, SizeBoard);
                if (newSnake.InitialPosition < 20)
                {
                    sizeSnake = randomNumber.Next(5, newSnake.InitialPosition - 1);
                }
                else
                {
                    sizeSnake = randomNumber.Next(5, 20);
                }
                newSnake.EndPosition = newSnake.InitialPosition - sizeSnake;
                foreach (var ControllerColisions in snakesInBoard)
                {
                    if (ControllerColisions.InitialPosition.Equals(newSnake.InitialPosition) ||
                        ControllerColisions.InitialPosition.Equals(newSnake.EndPosition) ||
                        ControllerColisions.EndPosition.Equals(newSnake.InitialPosition) ||
                        ControllerColisions.EndPosition.Equals(newSnake.EndPosition))
                    {
                        available = false;
                    }
                }
                foreach (var ControllerColisions in laddersInBoard)
                {
                    if (ControllerColisions.InitialPosition.Equals(newSnake.InitialPosition) ||
                        ControllerColisions.InitialPosition.Equals(newSnake.EndPosition) ||
                        ControllerColisions.EndPosition.Equals(newSnake.InitialPosition) ||
                        ControllerColisions.EndPosition.Equals(newSnake.EndPosition))
                    {
                        available = false;
                    }

                }
                if (available == true)
                {
                    snakesInBoard.Add(newSnake);
                }
                else
                {
                    i--;
                }
            }
        }
        public void GenerateLadders()
        {
            for (int i = 0; i < NumberOfLadders; i++)
            {
                bool available = true;
                int sizeLadder;
                Ladder newLadder = new Ladder();
                Random randomNumber = new Random();
                newLadder.InitialPosition = randomNumber.Next(6, SizeBoard);
                if (newLadder.InitialPosition < 20)
                {
                    sizeLadder = randomNumber.Next(5, newLadder.InitialPosition - 1);
                }
                else
                {
                    sizeLadder = randomNumber.Next(5, 20);
                }
                newLadder.EndPosition = newLadder.InitialPosition + sizeLadder;
                foreach (var ControllerColisions in snakesInBoard)
                {
                    if (ControllerColisions.InitialPosition.Equals(newLadder.InitialPosition) ||
                        ControllerColisions.InitialPosition.Equals(newLadder.EndPosition) ||
                        ControllerColisions.EndPosition.Equals(newLadder.InitialPosition) ||
                        ControllerColisions.EndPosition.Equals(newLadder.EndPosition))
                    {
                        available = false;
                    }
                }
                foreach (var ControllerColisions in laddersInBoard)
                {
                    if (ControllerColisions.InitialPosition.Equals(newLadder.InitialPosition) ||
                        ControllerColisions.InitialPosition.Equals(newLadder.EndPosition) ||
                        ControllerColisions.EndPosition.Equals(newLadder.InitialPosition) ||
                        ControllerColisions.EndPosition.Equals(newLadder.EndPosition))
                    {
                        available = false;
                    }

                }
                if (available == true)
                {
                    laddersInBoard.Add(newLadder);
                }
                else
                {
                    i--;
                }
            }
        }
        public void PlayerMovemenst(Player player)
        {
            player.diceOwn.ValueDice = player.diceOwn.GetValueDice();
            if(player.positionInBoard + player.diceOwn.ValueDice > SizeBoard)
            {
                snakeAndLaddersRules.BounceWithTheEnd(player, this);
            }
            else
            {
                player.positionInBoard += player.diceOwn.ValueDice;
                Console.WriteLine("{0} saco un {1} y se movio a la casilla {2}", player.Name, player.diceOwn.ValueDice, player.positionInBoard);
                foreach (var CurrentCell in snakesInBoard)
                {
                    if (player.positionInBoard == CurrentCell.InitialPosition)
                    {
                        snakeAndLaddersRules.ImpactWithSnake(player, CurrentCell);
                    }
                    else
                    {
                        player.positionInBoard = player.positionInBoard;
                    }
                }
                foreach (var CurrentCell in laddersInBoard)
                {
                    if (player.positionInBoard == CurrentCell.InitialPosition)
                    {
                        snakeAndLaddersRules.ImpactWithLadder(player, CurrentCell);
                    }
                    else
                    {
                        player.positionInBoard = player.positionInBoard;
                    }
                }
            }
        }
    }
}
