using System.Runtime.ConstrainedExecution;

namespace FC_Module
{
    public abstract class Loader
    {
        public List<ModuleClass> modules = new List<ModuleClass>();
    }

    public abstract class FrameworkCoreModule
    {
        public void registerEvent()
        {

        }

        public void 
    }

    public abstract class ModuleClass: FrameworkCoreModule
    {
        int id;
        string name;
        string art;

        
    }

}