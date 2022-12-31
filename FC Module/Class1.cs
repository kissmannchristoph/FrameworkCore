using FrameworkCore.Plugin;

namespace FC_Module
{
    public class Loader
    {
        private List<ModuleClass> modules = new List<ModuleClass>();

        public List<ModuleClass> Modules
        {
            get { return this.modules; }
        }

        public Loader()
        {
            this.load();
        }

        private void load()
        {

        }
    }

    public abstract class FrameworkCoreModule : Plugin
    {
        protected FrameworkCoreModule(string name) : base(name)
        {
        }

        public void registerEvent()
        {

        }

        public Loader getLoader()
        {
            return new Loader();
        }
    }

    public abstract class ModuleClass 
    {
        int id;
        string name;
        string art;

        protected ModuleClass(string name)
        {
        }
    }

}