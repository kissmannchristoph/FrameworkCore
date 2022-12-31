namespace FrameworkCore.Plugin
{
    public abstract class Plugin: PluginBase
    {
        public readonly string Name;

        private Base fCoreBase;

        public Base FCoreBase
        {
            get
            {
                return this.fCoreBase;
            }
            set
            {
                if (fCoreBase == null)
                {
                    this.fCoreBase = value;
                }
            }
        }


        public Plugin(string name)
        {
            this.Name = name;
        }

        public void OnLoad()
        {

        }

        public void OnUnload()
        {
            var a = "";
        }

        public abstract bool OnStart();
        public abstract bool OnStop();
    }
}
