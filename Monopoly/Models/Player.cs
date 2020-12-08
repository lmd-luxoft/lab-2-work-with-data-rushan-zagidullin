namespace Monopoly.Models
{
    public class Player
    {
        public Player(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }

        public string Name { get; set; }
        public int Balance { get; set; }
        
        
        public override bool Equals(object obj)
        {
            return Equals(obj as Player);
        }

        public bool Equals(Player other)
        {
            return other != null
                   && Name == other.Name
                   && Balance == other.Balance;
        }
    }
}