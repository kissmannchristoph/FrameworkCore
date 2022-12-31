using FrameworkCore;
using FrameworkCore.Event;
using EventHandler = FrameworkCore.Event.EventHandler;
using Event = FrameworkCore.Event.Event;
namespace FrameworkCoreModuleHubServer
{
    class TestEvent: Event
    {
        public TestEvent() { }

        public override void After()
        {
            throw new NotImplementedException();
        }

        public override void Bevore()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
    internal class L1: Listener
    {
        [EventHandler]
        public void a(TestEvent _event)
        {
            _event.ToString();
        }
    }
    public partial class Form1 : Form
    {
        private readonly FCore fcore;
        public Form1()
        {
            this.fcore = FCore.Create();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.fcore.EventManagerContext.GetEventContext().
            MessageBox.Show(this.fcore.PluginManagerContext.ToString());
        }
    }
}