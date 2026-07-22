namespace Games
{
    public abstract class Game
    {
        public string Name { get; }
        public bool Won    { get; protected set; }
        
        protected Game(string name)
        {
            Name = name;
            Won = false;
        }

        public abstract void Play();
        public abstract void PrintResult();
    }
}