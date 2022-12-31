using System.Runtime.ConstrainedExecution;

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

    public abstract class FrameworkCoreModule
    {
        public void registerEvent()
        {

        }

        public Loader getLoader()
        {
            return new Loader();
        } 
    }

    public abstract class ModuleClass: FrameworkCoreModule
    {
        int id;
        string name;
        string art;

        
    }

}