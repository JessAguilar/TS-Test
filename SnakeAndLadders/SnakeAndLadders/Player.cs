namespace SnakeAndLadders
{
    public class Player
    {
        public string Name { get; set; }
        public int positionInBoard { get; set; }
        public int turnInGame { get; set; }
        public Dice diceOwn { get; set; }
        public Player(string name, int positioninboard,int turningame,Dice diceown)
        {
            this.Name = name;
            this.positionInBoard = positioninboard;
            this.turnInGame = turningame;
            this.diceOwn = diceown;
        }
    }
}
