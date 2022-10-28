namespace CarAssembler
{
    public class LeaderBoardRecord
    {
        public LeaderBoardRecord(int orderNumber, string name, int score)
        {
            OrderNumber = orderNumber;
            Name = name;
            Score = score;
        }

        public int OrderNumber { get; }
        public string Name { get; }
        public int Score { get; }
    }
}