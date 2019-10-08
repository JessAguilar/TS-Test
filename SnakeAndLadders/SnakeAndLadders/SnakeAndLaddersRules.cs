using System;

namespace SnakeAndLadders
{
    public class SnakeAndLaddersRules
    {
        public void ChoiceInitialPlayer(Player playerWinFirstTurn,Player playerLoserFirstTurn)
        {
            playerWinFirstTurn.turnInGame = 1;
            playerLoserFirstTurn.turnInGame = 2;
        }
        public void ImpactWithSnake(Player player,Snake snakeImpacted)
        {
            player.positionInBoard = snakeImpacted.EndPosition;
            Console.WriteLine("{0} se a topado con una serpiente se mueve a la casilla {1}", player.Name, player.positionInBoard);
        }
        public void ImpactWithLadder(Player player, Ladder ladderImpacted)
        {
            player.positionInBoard = ladderImpacted.EndPosition;
            Console.WriteLine("{0} se a topado con una escalera se mueve a la casilla {1}", player.Name, player.positionInBoard);
        }
        public void BounceWithTheEnd(Player player, Board board)
        {
            int remainingSpaces = player.diceOwn.ValueDice-(board.SizeBoard - player.positionInBoard);
            player.positionInBoard = board.SizeBoard - remainingSpaces;
        }
    }
}
