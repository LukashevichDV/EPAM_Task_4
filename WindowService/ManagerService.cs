using System.ServiceProcess;

namespace WindowService
{
    public partial class ManagerService : ServiceBase
    {
        private Watcher Watcher;
        public ManagerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Watcher = new Watcher();
        }

        protected override void OnStop()
        {
            Watcher.Dispose();
        }
    }
}