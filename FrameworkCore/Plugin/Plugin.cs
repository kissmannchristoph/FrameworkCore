namespace FrameworkCore.Plugin
{
    public abstract class Plugin
    {
        public readonly string Name;

        public Plugin(string name)
        {
            this.Name = name;
        }

        public void OnLoad()
        {

        }

        public void OnUnload()
        {

        }

        public abstract bool OnStart();
        public abstract bool OnStop();
    }
}
