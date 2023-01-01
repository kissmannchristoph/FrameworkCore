using FrameworkCore.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Module
{
    public enum ModuleType
    {
        WLan, Bluetooth
    }

    public enum BridgeType
    {
        Master, Slave
    }

    public class Module {
        public readonly ModuleType ModuleType;
        public readonly EventManager EventManager;
        public readonly string Name;
        public Module(ModuleType moduleType)
        {
            this.ModuleType = moduleType;
        }

    }

    public abstract class Bridge
    {
        public readonly Module Endpoint;
        public readonly string Name;
        public readonly BridgeType BridgeType;

        public Bridge(Module module, string listenName, BridgeType bridgeType) {
            this.Endpoint = module;
            this.Name = listenName;
            this.BridgeType = bridgeType;
        }

        public abstract void OnRecive(string data);
        
        public void Send(string data)
        {

        }
    }

    public class WLanBridge : Bridge
    {
        public WLanBridge(Module module, string listenName) : base(module, listenName)
        {
        }

        public override void OnRecive(string data)
        {
            throw new NotImplementedException();
        }
    }

    public class BluetoothBridge : Bridge
    {
        public BluetoothBridge(Module module, string listenName) : base(module, listenName)
        {
        }

        public override void OnRecive(string data)
        {
            throw new NotImplementedException();
        }
    }

    public class ModuleManager
    {
        private List<Module> modules = new List<Module>();
        private readonly Base fCore;

        public ModuleManager(Base fCore)
        {
            this.fCore = fCore;
        }

        public Module GetModule(string name)
        {
            return this.modules.Find((Module module) => module.Name.Equals(name))!;
        }



        public Module GetMasterModule()
        {

        }

        public void StartMaster()
        {

        }

        public void RegisterModule(Module module)
        {

        }

        public void ScanForModules()
        {

        }

        public Bridge GetModuleBridge(Module module, string listenName)
        {
            return new Bridge(module, listenName)
        }


        public void AddModule(Module module) { }
    }
}
