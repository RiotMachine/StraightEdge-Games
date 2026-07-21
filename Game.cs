namespace Games
{
    public abstract class Game
    {
        public readonly int Turns { get; };
        public bool Won { get; private set; } = false;
        
        protected Game(int turns) { Turns = turns; }
    
        public abstract void Play();
    }
}