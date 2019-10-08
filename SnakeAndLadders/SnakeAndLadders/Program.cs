using System;

namespace SnakeAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentTurn = 1;
            int throwDiceOne;
            int throwDiceTwo;
            SnakeAndLaddersRules snakeAndLaddersRules = new SnakeAndLaddersRules();
            Board board = new Board(50, 4, 4);
            Dice diceOfPlayerOne = new Dice();
            Dice diceOfPlayerTwo = new Dice();
            Player playerOne = new Player("Jesus",0, 0, diceOfPlayerOne);
            Player playerTwo = new Player("Rodrigo",0, 0, diceOfPlayerTwo);
            do
            {
                throwDiceOne = playerOne.diceOwn.GetValueDice();
                System.Threading.Thread.Sleep(500);
                throwDiceTwo = playerTwo.diceOwn.GetValueDice();
                Console.WriteLine("{0} saco {1}",playerOne.Name, throwDiceOne);
                Console.WriteLine("{0} saco {1}",playerTwo.Name, throwDiceTwo);
                if (throwDiceOne > throwDiceTwo)
                {
                    Console.WriteLine("{0} empieza el juego",playerOne.Name);
                    snakeAndLaddersRules.ChoiceInitialPlayer(playerOne,playerTwo);
                }
                else if(throwDiceOne < throwDiceTwo)
                {
                    Console.WriteLine("{0} empieza el juego", playerTwo.Name);
                    snakeAndLaddersRules.ChoiceInitialPlayer(playerTwo, playerOne);
                }
            } while (throwDiceOne == throwDiceTwo);
            Console.WriteLine("Empieza el Juego");
            board.GenerateSnakes();
            board.GenerateLadders();
            do
            {
                if (playerOne.turnInGame == currentTurn)
                {
                    board.PlayerMovemenst(playerOne);
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    board.PlayerMovemenst(playerTwo);
                    System.Threading.Thread.Sleep(500);
                }
                if(currentTurn == 1)
                {
                    currentTurn = 2;
                }
                else
                {
                    currentTurn = 1;
                }
                if (playerOne.positionInBoard == board.SizeBoard || playerTwo.positionInBoard == board.SizeBoard)
                {
                    break;
                }
            } while (playerOne.positionInBoard!=board.SizeBoard || playerTwo.positionInBoard != board.SizeBoard);
            if (playerOne.positionInBoard==board.SizeBoard)
            {
                Console.WriteLine("{0} ha ganado", playerOne.Name);
            }
            else
            {
                Console.WriteLine("{0} ha ganado", playerTwo.Name);
            }
            Console.ReadKey();
        }
    }
}
