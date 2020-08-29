namespace ProvaMG.Infrasctructure.Data
{
    public abstract class BaseRepository
    {
        protected BaseRepository(ProvaMGContext context)
        {
            Context = context;
        }

        public ProvaMGContext Context { get; private set; }
    
    }
}