using FrameworkCore.Plugin;
using FrameworkCore;

namespace FCM_Dartspiel
{
    public class Dartspiel : Plugin
    {
        public Dartspiel() : base("Dart")
        {
            
        }

        public override bool OnStart()
        {
            this.FCoreBase.StateManager.GetStateContext();
            throw new NotImplementedException();
        }

        public override bool OnStop()
        {
            throw new NotImplementedException();
        }
    }
}