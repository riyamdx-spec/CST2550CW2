namespace BettingSystem.Models
{
    public class AddMatchComboItems
    {
        public int ID { set; get; }
        private string _name { set; get;  }

        public AddMatchComboItems(int id, string name)
        {
            ID = id;
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
    }
}