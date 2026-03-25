namespace BettingSystem.Models
{
    public class AddMatchComboItems
    {
        public int ID { set; get; }
        private string Name { set; get;  }

        public AddMatchComboItems(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}