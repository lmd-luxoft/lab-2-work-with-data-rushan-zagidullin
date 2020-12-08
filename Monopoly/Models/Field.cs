namespace Monopoly.Models
{
    public class Field
    {
        public Field(string name, Type type, Player player = null)
        {
            Name = name;
            Type = type;
            Player = player;
        }

        public string Name { get; set; }
        public Type Type { get; set; }
        public Player Player { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Field);
        }
        
        public bool Equals(Field other)
        {
            return other != null
                   && Name == other.Name
                   && Type == other.Type
                   && Player?.Name == other.Player?.Name;
        }
    }
}