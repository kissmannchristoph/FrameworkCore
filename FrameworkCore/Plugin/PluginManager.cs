using Newtonsoft.Json;
using System.Reflection;
using System;
using System.Collections;
namespace FrameworkCore.Plugin
{
    public class PluginManager
    {
        List<Plugin> plugins = new List<Plugin>();

        private readonly Base FCoreBase;

        public PluginManager(Base fCoreBase)
        {
            this.FCoreBase = fCoreBase;
            this.loadPlugins(plugins);
           
        }

        public override string ToString()
        {
            return this.plugins.Count.ToString();
        }

        private void loadPlugins(List<Plugin> plugins)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "plugins");

            //check dir exists
           try
            {
if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return;
            }
            } catch (Exception sOE)
            {
                Directory.CreateDirectory(path);
                return;
            }
            

            string[] files = Directory.GetFiles(path, "*.dll");

            foreach (string file in files)
            {
                var asm = Assembly.LoadFile(file);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (typeof(Plugin).IsAssignableFrom(type.BaseType))
                    {
                        Plugin plugin = (Plugin) Activator.CreateInstance(type);
                        plugin.FCoreBase = this.FCoreBase;
                        plugin.OnLoad();
                        this.plugins.Add(plugin);
                        break;
                    }
                }
            }
        }

        public T GetPlugin<T>(string name)
        {
            object plugin = this.plugins.Find((Plugin plugin) => plugin.Name.Equals(name));

            if (plugin == null)
                return default(T);

            return (T)plugin;
        }
    }
}
