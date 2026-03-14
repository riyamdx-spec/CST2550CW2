namespace BettingSystem.Models
{
    //represent player to be displayed in comboBox on main page
    public class PlayerComboItem
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public Odd PlayerOdd { get; set; }

        public PlayerComboItem(string name, string position, Odd playerOdd)
        {
            Name = name;
            Position = position;
            PlayerOdd = playerOdd;
        }

        public override string ToString()
        {
            return $"{Name} - {Position} - Odd: {PlayerOdd.OddValue}";
        }
    }
}