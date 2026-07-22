namespace Games
{
    public abstract class Game
    {
        public int Turns { get; }
        public bool Won { get; protected set; } = false;
        
        protected Game(int turns) { Turns = turns; }
    
        public abstract void Play();
    }
}