using FrameworkCore;
using FrameworkCore.Event;
using EventHandler = FrameworkCore.Event.EventHandler;
using Event = FrameworkCore.Event.Event;
using Listener = FrameworkCore.Event.Listener;
using FrameworkCore.Plugin;

namespace FrameworkCoreModuleHubServer
{
    class TestEvent: Event
    {
        public TestEvent() { }

        public override void After()
        {
            //throw new NotImplementedException();
        }

        public override void Bevore()
        {
            //throw new NotImplementedException();
        }

        public override void Run()
        {
           // throw new NotImplementedException();
        }
    }
    internal class L1: Listener
    {
        [EventHandler]
        public void a(TestEvent _event)
        {
            MessageBox.Show(_event.ToString());
        }
    }
    public partial class Form1 : Form
    {
        private readonly FCore fcore;
        private readonly EventContext defaultEventContext;

        public Form1()
        {
            this.fcore = FCore.Create();
            this.defaultEventContext = this.fcore.EventManager.GetEventContext();
            this.fcore.GetPlugin<Plugin>("Dart").OnUnload();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.defaultEventContext.RegisterListener(new L1());
 
            MessageBox.Show(this.fcore.PluginManager.ToString());
        }
    }
}